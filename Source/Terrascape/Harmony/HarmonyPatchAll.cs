using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using HarmonyLib;

namespace Terrascape
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatchAll
    {
        static HarmonyPatchAll()
        {
            // applying all patches
            new Harmony("tidal.terrascape").PatchAll();
        }
    }





}
