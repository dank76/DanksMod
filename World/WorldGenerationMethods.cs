using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.World.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DanksMod.Tiles;
using static Terraria.ModLoader.ModContent;
using CalamityMod.World;

namespace DanksMod.World
{
	public class WorldGenerationMethods : ModWorld //most of this code is taken from spirit
	{
		public static bool CosmoliteOre = false;

		public override void Initialize()
		{
			if (CalamityWorld.downedDoG == true)
			{
                CosmoliteOre = false;
			}
		}
        public override void PostWorldGen()
        {
			for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 15E-05); k++)
			{
				int EEXX = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
				int WHHYY = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 300);
				if (Main.tile[EEXX, WHHYY] != null)
				{
					if (Main.tile[EEXX, WHHYY].active())
					{
						if (Main.tile[EEXX, WHHYY].type == 161)
						{
							WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)ModContent.TileType<CosmicRock>());
						}
						else if (Main.tile[EEXX, WHHYY].type == 163)
						{
							WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)ModContent.TileType<CosmicRock>());
						}
						else if (Main.tile[EEXX, WHHYY].type == 164)
						{
							WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)ModContent.TileType<CosmicRock>());
						}
						else if (Main.tile[EEXX, WHHYY].type == 200)
						{
							WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)ModContent.TileType<CosmicRock>());
						}
					}
				}
			}
		}
        public override void PostUpdate()
		{
			if (CalamityWorld.downedDoG)
			{
				if (CosmoliteOre)
				{
					for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY * 1.13f) * 15E-05); k++)
					{
						int EEXX = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
						int WHHYY = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 500);
						if (Main.tile[EEXX, WHHYY] != null)
						{
							if (Main.tile[EEXX, WHHYY].active())
							{
								if (Main.tile[EEXX, WHHYY].type == 1)
								{
									WorldGen.OreRunner(EEXX, WHHYY, WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)TileType<CosmicRock>());
								}
							}
						}
					}
					Main.NewText("A rift has left chunks of ore in The Caverns", 139, 38, 150);
					CosmoliteOre = true;
				}
			}
		}
	}
}
 