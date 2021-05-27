using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using HarmonyLib;
using Verse;
using UnityEngine;

namespace Terrascape
{
    internal class BiomeVariantDef : Def
    {
        public List<string> biomes;
        public string biomeVariantLabel;
    }
}
