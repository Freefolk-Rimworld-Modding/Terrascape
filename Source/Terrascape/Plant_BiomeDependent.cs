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
    public class Plant_BiomeDependent : Plant
    {
        private static Graphic GraphicSowing = GraphicDatabase.Get<Graphic_Single>("Things/Plant/Plant_Sowing", ShaderDatabase.Cutout, Vector2.one, Color.white);
           
        // Gets graphic based on biome
        public Graphic GetBiomeVariant()
        {
            ModExtension_Plant_BiomeDependent ext = def.GetModExtension<ModExtension_Plant_BiomeDependent>();
            string mapDefName = base.Map.Biome.defName;
            Graphic graphic = def.graphic;
            if (ext != null && mapDefName != null && ext.dryVariantPath != null)
            {
                List<String> Biomes = DefDatabase<BiomeVariantDef>.GetNamed("TS_BiomeDry").biomes;
                if (!Biomes.NullOrEmpty())
                {
                    foreach (string biome in Biomes)
                    {
                        if (String.IsNullOrEmpty(biome))
                        {
                            break;
                        }
                        if (mapDefName == biome)
                        {
                            graphic = GraphicDatabase.Get(def.graphicData.graphicClass, ext.dryVariantPath, def.graphic.Shader, def.graphicData.drawSize, def.graphicData.color, base.Graphic.colorTwo);
                        }                            
                    }
                }
                    
            }
            return graphic;
        }
        
        public override Graphic Graphic
        {
            get
            {
                if (LifeStage == PlantLifeStage.Sowing)
                {
                    return GraphicSowing;
                }
                if (def.plant.leaflessGraphic != null && base.LeaflessNow && (!sown || !HarvestableNow))
                {
                    return def.plant.leaflessGraphic;
                }
                if (def.plant.immatureGraphic != null && !HarvestableNow)
                {
                    return def.plant.immatureGraphic;
                }
                if (def.HasModExtension<ModExtension_Plant_BiomeDependent>())
                {
                    return GetBiomeVariant();
                }
                return base.Graphic;
            }
        }
    }
}
