using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using UnityEngine;
using System.Reflection;
using HarmonyLib;

namespace Terrascape
{
    [HarmonyPatch(typeof(ThingDefGenerator_Meat), "ImpliedMeatDefs")]
    class BiomesCoreMeatGenerator
    {
        static IEnumerable<ThingDef> Postfix(IEnumerable<ThingDef> meatThings)
        {
            foreach (var thingDef in meatThings)
            {
                if (thingDef.defName == "Meat_BiomesIslands_WhiteShark")
                {
                    thingDef.graphicData.texPath = "BiomesIslands_Things/Item/Meat/Meat_Fish";
                }
                yield return thingDef;
            }
        }
    }
}