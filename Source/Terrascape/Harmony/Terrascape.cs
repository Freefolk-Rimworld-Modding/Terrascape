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
    [StaticConstructorOnStartup]
    public static class Terrascape
    {
        static Terrascape()
        {
            // applying all patches
            new Harmony("tidal.terrascape").PatchAll();
        }
    }

 //   [StaticConstructorOnStartup]
	//public static class HarmonyPatches
	//{
	//	static HarmonyPatches()
	//	{
			
	//		HarmonyPatches.MapFieldInfo = typeof(SteadyEnvironmentEffects).GetField("map", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
	//		if (HarmonyPatches.MapFieldInfo == null)
	//		{
	//			throw new Exception("Could not get FieldInfo!");
	//		}
	//		HarmonyPatches.PawnFieldInfo_FilthTracker = typeof(Pawn_FilthTracker).GetField("pawn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
	//		if (HarmonyPatches.PawnFieldInfo_FilthTracker == null)
	//		{
	//			throw new Exception("Could not get FieldInfo!");
	//		}
	//		HarmonyPatches.PawnFieldInfo_Renderer = typeof(PawnRenderer).GetField("pawn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
	//		if (HarmonyPatches.PawnFieldInfo_Renderer == null)
	//		{
	//			throw new Exception("Could not get FieldInfo!");
	//		}
	//		HarmonyPatches.PawnFieldInfo_StoryTracker = typeof(Pawn_StoryTracker).GetField("pawn", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
	//		if (HarmonyPatches.PawnFieldInfo_StoryTracker == null)
	//		{
	//			throw new Exception("Could not get FieldInfo!");
	//		}
	//	}

	//	public static FieldInfo MapFieldInfo;

	//	public static FieldInfo PawnFieldInfo_FilthTracker;

	//	public static FieldInfo PawnFieldInfo_Renderer;

	//	public static FieldInfo PawnFieldInfo_StoryTracker;

	//	public static FieldInfo JobFieldInfo_CleanFilth;

	//	public static Graphic poolCue = GraphicDatabase.Get(typeof(Graphic_Single), "Pool/Cue", ShaderDatabase.DefaultShader, Vector2.one, Color.white, Color.white);
	//}


}