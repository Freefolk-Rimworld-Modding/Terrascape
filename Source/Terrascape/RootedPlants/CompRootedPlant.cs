using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using Verse.AI;
using UnityEngine;

namespace Terrascape
{
	public class CompRootedPlant : ThingComp
	{
		public CompProperties_RootedPlant Props => (CompProperties_RootedPlant)props;

		private List<Thing> roots = new List<Thing>();

		private float progressToNewRoot;

		// Returns true if the plant has reached the max amount of roots, else returns false.
		public bool HasMaxRoots()
		{
			if (!roots.NullOrEmpty())
            {
				return roots.Count >= Props.maxRoots;
			}
			return false;
		}

		// Returns amount of progress added per long tick.
		public float ProgressPerTickLong()
		{		
			Plant p = (Plant)parent;
			if (p != null)
            {
				return 1f / (30f * Props.growthCycleDays) * p.GrowthRate;
			}
			return 0f;
		}

		public void AddProgress(float progress)
		{
			progressToNewRoot += progress;
			TryGrowRoot();
		}

		public override void CompTickLong()
		{
			Plant p = (Plant)parent;
			if (p != null && p.LifeStage == PlantLifeStage.Growing && !HasMaxRoots())
			{
				AddProgress(ProgressPerTickLong());
			}
		}

		public override void PostDeSpawn(Map map)
		{
			if (Props.removeOnDespawn)
			{
				roots.RemoveAll((Thing p) => !p.Spawned);
			}
			else
			{
				foreach (Thing i in roots)
				{
					Plant_Root p = (Plant_Root)i;
					if (p != null)
					{
						p.LivingParent = false;
					}
				}
			}
		}

		private void TryGrowRoot()
		{
			while (progressToNewRoot >= 1f)
			{
				GrowRoot();
				progressToNewRoot -= 1f;
			}
		}

		public void GrowRoot()
		{
			int num = GenRadial.NumCellsInRadius(Props.rootGrowthRadius);
			List<IntVec3> positions = new List<IntVec3>();
			for (int i = 0; i < num; i++)
			{
				IntVec3 c = parent.Position + GenRadial.RadialPattern[i];
				if (c.InBounds(parent.Map) || WanderUtility.InSameRoom(parent.Position, c, parent.Map))
				{
					TerrainDef terrain = c.GetTerrain(parent.Map);
					bool flag = false;
                    switch (Props.rootType)
                    {
						case "Wet":
							if (terrain != null && (terrain.IsWater || terrain == TerrascapeDefOf.Mud || parent.Map.fertilityGrid.FertilityAt(c) >= Props.root.plant?.fertilityMin))
							{
								List<Thing> list = parent.Map.thingGrid.ThingsListAt(c);
								foreach (Thing item in list)
								{
									if (item.def == Props.root)
									{
										flag = true;
										break;
									}
								}
								if (!flag)
								{
									positions.Add(c);
								}
							}
							break;
						case "Dry":
							if (terrain != null && parent.Map.fertilityGrid.FertilityAt(c) >= Props.root.plant?.fertilityMin)
							{
								List<Thing> list = parent.Map.thingGrid.ThingsListAt(c);
								foreach (Thing item in list)
								{
									if (item.def == Props.root)
									{
										flag = true;
										break;
									}
								}
								if (!flag)
								{
									positions.Add(c);
								}
							}
							break;
						default:
							Log.Error(string.Concat(parent.def, " has a rootType that is missing or incorrect in Terrascape.CompProperties_RootedPlant; rootType must be either \"Wet\" or \"Dry\"."));
							break;
					}
				}
			}
			if (!positions.NullOrEmpty())
            {
				roots.Add(GenSpawn.Spawn(Props.root, positions.RandomElement<IntVec3>(), parent.Map));
				Plant_Root recentRoot = (Plant_Root)roots[roots.Count - 1];
				recentRoot.LivingParent = true;
            }
		}
			



				//for (int num = thingList.Count - 1; num >= 0; num--)
				//{
				//	if (thingList[num].def.category == ThingCategory.Plant)
				//	{
				//		thingList[num].Destroy();
				//	}
				//}
				//Plant_Root spawnedRoot = (Plant_Root)roots[roots.Count - 1];
				//if (spawnedRoot != null && Props.offsetTowardsParent)
    //            {					
					
				//}

		public override IEnumerable<Gizmo> CompGetGizmosExtra()
		{
			if (Prefs.DevMode)
			{
				// Adds 100% progress if the number of roots is less than max roots
				Command_Action command_Action = new Command_Action();
				command_Action.defaultLabel = "DEV: Add 100% progress to next root";
				command_Action.action = delegate
				{
					if (!HasMaxRoots())
                    {
						AddProgress(1f);
					}		
				};
				yield return command_Action;

				// Adds a single long tick of progress if the number of roots is less than max roots
				Command_Action command_Action2 = new Command_Action();
				command_Action2.defaultLabel = "DEV: Add long tick of progress";
				command_Action2.action = delegate
				{
					if (!HasMaxRoots())
					{
						AddProgress(ProgressPerTickLong());
					}
				};
				yield return command_Action2;
			}
		}

		public override void PostExposeData()
		{
			Scribe_Values.Look(ref progressToNewRoot, "progressToNewRoot", 0f);
			Scribe_Collections.Look(ref roots, "roots", LookMode.Reference);
			if (Scribe.mode == LoadSaveMode.PostLoadInit)
			{
				roots.RemoveAll((Thing x) => x == null);
			}
		}
	}

	public class CompProperties_RootedPlant : CompProperties
	{
		// The type of root to spawn. Must be a Terrascape.Plant_Root thingclass.
		public ThingDef root;

		// The max number of roots a rooted plant can produce.
		public int maxRoots;

		// The radius the roots will grow in.
		public float rootGrowthRadius;

		// The number of days it takes a new root to grow
		public float growthCycleDays = 5f;

		// If true, will remove all roots when the parent despawns.
		public bool removeOnDespawn = false;

		// rootType can be "Wet" or "Dry" - wet roots will grow in mud and water terrain in addition to regular ground.
		public string rootType;

		public CompProperties_RootedPlant()
		{
			compClass = typeof(CompRootedPlant);
		}
	}

}

