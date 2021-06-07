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
    [DefOf]
    public class TerrascapeDefOf
    {
        public static TerrainDef Mud;
        static TerrascapeDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(TerrascapeDefOf));
        }
    }
}
