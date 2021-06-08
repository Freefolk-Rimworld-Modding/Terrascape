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
    //public class GenStep_RootedPlants : GenStep
    //{
    //    // Not working but no errors yet
    //    public override int SeedPart => 578425222;

    //    public override void Generate(Map map, GenStepParams parms)
    //    {
    //        map.regionAndRoomUpdater.Enabled = false;
    //        foreach (IntVec3 cell in map.cellsInRandomOrder.GetAll())
    //        {
    //            List<Thing> list = cell.GetThingList(map);
    //            foreach (Thing item in list)
    //            {
    //                CompRootedPlant comp = item.TryGetComp<CompRootedPlant>();
    //                if (comp != null)
    //                {
    //                    for (int i = 0; i < Rand.RangeInclusive(0, comp.Props.maxRoots); i++)
    //                    {
    //                        comp.GrowRoot();
    //                    }                        
    //                }
    //            }
    //        }
    //        map.regionAndRoomUpdater.Enabled = true;
    //    }
    //}
}

