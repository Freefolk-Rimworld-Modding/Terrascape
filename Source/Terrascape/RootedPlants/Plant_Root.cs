using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using UnityEngine;

namespace Terrascape
{
    [StaticConstructorOnStartup]
    public class Plant_Root : Plant
    {

		public bool growsWithoutParent = false;

		private bool livingParent = true;

		public bool LivingParent
        {
            get
            {
				return livingParent;
            }
            set
            {
				livingParent = value;
            }
        }

		// If growsWithoutParent is false, roots will not continue to grow if their parent tree has despawned.
		public override float GrowthRate
		{
			get
			{
				if (Blighted)
				{
					return 0f;
				}
				if (base.Spawned && !PlantUtility.GrowthSeasonNow(base.Position, base.Map))
				{
					return 0f;
				}
				if (!LivingParent && !growsWithoutParent)
                {
					return 0f;
                }
				return GrowthRateFactor_Fertility * GrowthRateFactor_Temperature * GrowthRateFactor_Light;
			}
		}

		//private static Color32[] workingColors = new Color32[4];

		//public override void Print(SectionLayer layer)
  //      {
		//	CompRootedPlant rootComp = this.GetComp<CompRootedPlant>();


		//	if (rootComp != null && !rootComp.Props.offsetTowardsParent)
  //          {
  //              base.Print(layer);
  //              return;
  //          }
   //         else
   //         {
			//	Vector3 vector = this.TrueCenter();
			//	Rand.PushState();
			//	Rand.Seed = base.Position.GetHashCode();
			//	int num = Mathf.CeilToInt(growthInt * (float)def.plant.maxMeshCount);
			//	if (num < 1)
			//	{
			//		num = 1;
			//	}
			//	float num2 = def.plant.visualSizeRange.LerpThroughRange(growthInt);
			//	float num3 = def.graphicData.drawSize.x * num2;
			//	Vector3 center = Vector3.zero;
			//	int num4 = 0;
			//	int[] positionIndices = PlantPosIndices.GetPositionIndices(this);
			//	bool flag = false;
			//	foreach (int num5 in positionIndices)
			//	{
			//		if (def.plant.maxMeshCount == 1)
			//		{
			//			center = vector + Gen.RandomHorizontalVector(0.05f);
			//			float num6 = base.Position.z;
			//			if (center.z - num2 / 2f < num6)
			//			{
			//				center.z = num6 + num2 / 2f;
			//				flag = true;
			//			}
			//		}
			//		else
			//		{
			//			int num7 = 1;
			//			switch (def.plant.maxMeshCount)
			//			{
			//				case 1:
			//					num7 = 1;
			//					break;
			//				case 4:
			//					num7 = 2;
			//					break;
			//				case 9:
			//					num7 = 3;
			//					break;
			//				case 16:
			//					num7 = 4;
			//					break;
			//				case 25:
			//					num7 = 5;
			//					break;
			//				default:
			//					Log.Error(string.Concat(def, " must have plant.MaxMeshCount that is a perfect square."));
			//					break;
			//			}
			//			float num8 = 1f / (float)num7;
			//			center = base.Position.ToVector3();
			//			center.y = def.Altitude;
			//			center.x += 0.5f * num8;
			//			center.z += 0.5f * num8;
			//			int num9 = num5 / num7;
			//			int num10 = num5 % num7;
			//			center.x += (float)num9 * num8;
			//			center.z += (float)num10 * num8;
			//			float max = num8 * 0.3f;
			//			center += Gen.RandomHorizontalVector(max);
			//		}
			//		bool @bool = Rand.Bool;
			//		Material matSingle = Graphic.MatSingle;
			//		PlantUtility.SetWindExposureColors(workingColors, this);
			//		Printer_Plane.PrintPlane(size: new Vector2(num3, num3), layer: layer, center: center, mat: matSingle, rot: 0f, flipUv: @bool, uvs: null, colors: workingColors, topVerticesAltitudeBias: 0.1f, uvzPayload: this.HashOffset() % 1024);
			//		num4++;
			//		if (num4 >= num)
			//		{
			//			break;
			//		}
			//	}
			//	if (def.graphicData.shadowData != null)
			//	{
			//		Vector3 center2 = vector + def.graphicData.shadowData.offset * num2;
			//		if (flag)
			//		{
			//			center2.z = base.Position.ToVector3Shifted().z + def.graphicData.shadowData.offset.z;
			//		}
			//		center2.y -= 3f / 70f;
			//		Vector3 volume = def.graphicData.shadowData.volume * num2;
			//		Printer_Shadow.PrintShadow(layer, center2, volume, Rot4.North);
			//	}
			//	Rand.PopState();
			//}
        //}
	}
}
