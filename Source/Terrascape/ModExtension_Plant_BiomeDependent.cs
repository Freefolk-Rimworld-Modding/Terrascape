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
    [StaticConstructorOnStartup]
    public class ModExtension_Plant_BiomeDependent : DefModExtension
    {
        public string dryVariantPath = null;
    }
}
