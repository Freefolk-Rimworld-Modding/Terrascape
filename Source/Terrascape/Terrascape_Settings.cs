using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;
using HarmonyLib;

namespace Terrascape
{
	public class Terrascape_Settings : ModSettings
	{
		// Biomes

		public static bool spawnMangroveSwamp = true;

		public static bool spawnTemperateRainforest = true;

		// Natural Objects

		public static bool spawnInsectNests = true;

		public static bool spawnPlantRoots = true;

		public static bool spawnFireflies = true;

		public static bool spawnBoulders = true;

		public static bool spawnLogs = true;

		public static bool treeCanopy = true;

		public static bool spawnTidepools = true;

		public static bool beachDebris = true;

		public static bool geothermalVariation = true;

		// Weather

		public static bool morningJungleFog = true;

		public static bool ashDuringVolcanicWinter = true;

		// Incidents

		public static bool eventHurricane = true;

		public static bool eventRedTide = true;

		public static bool eventFishMigration = true;

		public static bool eventGeothermalActivity = true;

		public static bool eventBeaching = true;


		public override void ExposeData()
		{
			Scribe_Values.Look(ref spawnMangroveSwamp, "spawnMangroveSwamp", defaultValue: true);
			Scribe_Values.Look(ref spawnTemperateRainforest, "spawnTemperateRainforest", defaultValue: true);
		}
	}	
}
