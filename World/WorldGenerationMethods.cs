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
using Terraria.Localization;

namespace DanksMod.World
{
	public class WorldGenerationMethods : ModWorld //most of this code is taken from spirit
	{
		public static bool CosmoliteOre = false;
		public static bool voidBiome = false;


		private int WillGenn = 0;
		private int Meme;

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
							WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)TileType<CosmicRock>());
						}
						else if (Main.tile[EEXX, WHHYY].type == 163)
						{
							WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)TileType<CosmicRock>());
						}
						else if (Main.tile[EEXX, WHHYY].type == 164)
						{
							WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)TileType<CosmicRock>());
						}
						else if (Main.tile[EEXX, WHHYY].type == 200)
						{
							WorldGen.OreRunner(EEXX, WHHYY, (double)WorldGen.genRand.Next(5, 6), WorldGen.genRand.Next(5, 6), (ushort)TileType<CosmicRock>());
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
				if (NPC.downedMechBoss3 || NPC.downedMechBoss2 || NPC.downedMechBoss1)
				{
					if (!voidBiome)
					{
						voidBiome = true;
						if (Main.netMode == NetmodeID.Server)
						{
							NetMessage.SendData(MessageID.WorldData);
						}
						if (Main.netMode == NetmodeID.SinglePlayer)
						{
							Main.NewText("The Dark Spirits of The Void have been released", Color.Black);
						}
						else if (Main.netMode == NetmodeID.Server)
						{
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Dark Spirits of The Void have been released"), Color.Black, -1);
						}
						Random rand = new Random();
						int XTILE;
						if (Terraria.Main.dungeonX > Main.maxTilesX / 2) //rightside dungeon
						{
							XTILE = WorldGen.genRand.Next((Main.maxTilesX / 2) + 300, Main.maxTilesX - 500);
						}
						else //leftside dungeon
						{
							XTILE = WorldGen.genRand.Next(75, (Main.maxTilesX / 2) - 600);
						}
						int xAxis = XTILE;
						int xAxisMid = xAxis + 70;
						int xAxisEdge = xAxis + 380;
						int yAxis = 0;
						for (int y = 0; y < Main.maxTilesY; y++)
						{
							yAxis++;
							xAxis = XTILE;
							for (int i = 0; i < 450; i++)
							{
								xAxis++;
								if (Main.tile[xAxis, yAxis] != null)
								{
									if (Main.tile[xAxis, yAxis].active())
									{
										int[] TileArray = { 0 };
										if (TileArray.Contains(Main.tile[xAxis, yAxis].type))
										{
											if (Main.tile[xAxis, yAxis + 1] == null)
											{
												if (Main.rand.Next(0, 50) == 1)
												{
													WillGenn = 0;
													if (xAxis < xAxisMid - 1)
													{
														Meme = xAxisMid - xAxis;
														WillGenn = Main.rand.Next(Meme);
													}
													if (xAxis > xAxisEdge + 1)
													{
														Meme = xAxis - xAxisEdge;
														WillGenn = Main.rand.Next(Meme);
													}
													if (WillGenn < 10)
													{
														Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<DarkVoidstoneBlock>();
													}
												}
											}
											else
											{
												WillGenn = 0;
												if (xAxis < xAxisMid - 1)
												{
													Meme = xAxisMid - xAxis;
													WillGenn = Main.rand.Next(Meme);
												}
												if (xAxis > xAxisEdge + 1)
												{
													Meme = xAxis - xAxisEdge;
													WillGenn = Main.rand.Next(Meme);
												}
												if (WillGenn < 10)
												{
													Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<DarkVoidstoneBlock>();
												}
											}
										}
										int[] TileArray84 = { 2, 23, 109, 199 };
										if (TileArray84.Contains(Main.tile[xAxis, yAxis].type))
										{
											if (Main.tile[xAxis, yAxis + 1] == null)
											{
												if (rand.Next(0, 50) == 1)
												{
													WillGenn = 0;
													if (xAxis < xAxisMid - 1)
													{
														Meme = xAxisMid - xAxis;
														WillGenn = Main.rand.Next(Meme);
													}
													if (xAxis > xAxisEdge + 1)
													{
														Meme = xAxis - xAxisEdge;
														WillGenn = Main.rand.Next(Meme);
													}
													if (WillGenn < 18)
													{
														Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<DarkVoidstoneBlock>();
													}
												}
											}
											else
											{
												WillGenn = 0;
												if (xAxis < xAxisMid - 1)
												{
													Meme = xAxisMid - xAxis;
													WillGenn = Main.rand.Next(Meme);
												}
												if (xAxis > xAxisEdge + 1)
												{
													Meme = xAxis - xAxisEdge;
													WillGenn = Main.rand.Next(Meme);
												}
												if (WillGenn < 18)
												{
													Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<DarkVoidstoneBlock>();
												}
											}
										}
										int[] TileArray1 = { 161, 163, 164, 200 };
										if (TileArray1.Contains(Main.tile[xAxis, yAxis].type))
										{
											if (Main.tile[xAxis, yAxis + 1] == null)
											{
												if (rand.Next(0, 50) == 1)
												{
													WillGenn = 0;
													if (xAxis < xAxisMid - 1)
													{
														Meme = xAxisMid - xAxis;
														WillGenn = Main.rand.Next(Meme);
													}
													if (xAxis > xAxisEdge + 1)
													{
														Meme = xAxis - xAxisEdge;
														WillGenn = Main.rand.Next(Meme);
													}
													if (WillGenn < 18)
													{
														Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<DarkVoidstoneBlock>();
													}
												}
											}
											else
											{
												WillGenn = 0;
												if (xAxis < xAxisMid - 1)
												{
													Meme = xAxisMid - xAxis;
													WillGenn = Main.rand.Next(Meme);
												}
												if (xAxis > xAxisEdge + 1)
												{
													Meme = xAxis - xAxisEdge;
													WillGenn = Main.rand.Next(Meme);
												}
												if (WillGenn < 18)
												{
													Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<DarkVoidstoneBlock>();
												}
											}
										}
										int[] TileArray2 = { 1, 25, 117, 203 };
										if (TileArray2.Contains(Main.tile[xAxis, yAxis].type))
										{
											if (Main.tile[xAxis, yAxis + 1] == null)
											{
												if (rand.Next(0, 50) == 1)
												{
													WillGenn = 0;
													if (xAxis < xAxisMid - 1)
													{
														Meme = xAxisMid - xAxis;
														WillGenn = Main.rand.Next(Meme);
													}
													if (xAxis > xAxisEdge + 1)
													{
														Meme = xAxis - xAxisEdge;
														WillGenn = Main.rand.Next(Meme);
													}
													if (WillGenn < 18)
													{
														Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<SpiritStone>();
													}
												}
											}
											else
											{
												WillGenn = 0;
												if (xAxis < xAxisMid - 1)
												{
													Meme = xAxisMid - xAxis;
													WillGenn = Main.rand.Next(Meme);
												}
												if (xAxis > xAxisEdge + 1)
												{
													Meme = xAxis - xAxisEdge;
													WillGenn = Main.rand.Next(Meme);
												}
												if (WillGenn < 18)
												{
													Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<SpiritStone>();
												}
											}
										}

										int[] TileArray89 = { 3, 24, 110, 113, 115, 201, 205, 52, 62, 32, 165 };
										if (TileArray89.Contains(Main.tile[xAxis, yAxis].type))
										{
											if (Main.tile[xAxis, yAxis + 1] == null)
											{
												if (rand.Next(0, 50) == 1)
												{
													WillGenn = 0;
													if (xAxis < xAxisMid - 1)
													{
														Meme = xAxisMid - xAxis;
														WillGenn = Main.rand.Next(Meme);
													}
													if (xAxis > xAxisEdge + 1)
													{
														Meme = xAxis - xAxisEdge;
														WillGenn = Main.rand.Next(Meme);
													}
													if (WillGenn < 18)
													{
														Main.tile[xAxis, yAxis].active(false);
													}
												}
											}
											else
											{
												WillGenn = 0;
												if (xAxis < xAxisMid - 1)
												{
													Meme = xAxisMid - xAxis;
													WillGenn = Main.rand.Next(Meme);
												}
												if (xAxis > xAxisEdge + 1)
												{
													Meme = xAxis - xAxisEdge;
													WillGenn = Main.rand.Next(Meme);
												}
												if (WillGenn < 18)
												{
													Main.tile[xAxis, yAxis].active(false);
												}
											}
										}


										int[] TileArray3 = { 53, 116, 112, 234 };
										if (TileArray3.Contains(Main.tile[xAxis, yAxis].type))
										{
											if (Main.tile[xAxis, yAxis + 1] == null)
											{
												if (rand.Next(0, 50) == 1)
												{
													WillGenn = 0;
													if (xAxis < xAxisMid - 1)
													{
														Meme = xAxisMid - xAxis;
														WillGenn = Main.rand.Next(Meme);
													}
													if (xAxis > xAxisEdge + 1)
													{
														Meme = xAxis - xAxisEdge;
														WillGenn = Main.rand.Next(Meme);
													}
													if (WillGenn < 18)
													{
														Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<Spiritsand>();
													}
												}
											}
											else
											{
												WillGenn = 0;
												if (xAxis < xAxisMid - 1)
												{
													Meme = xAxisMid - xAxis;
													WillGenn = Main.rand.Next(Meme);
												}
												if (xAxis > xAxisEdge + 1)
												{
													Meme = xAxis - xAxisEdge;
													WillGenn = Main.rand.Next(Meme);
												}
												if (WillGenn < 18)
												{
													Main.tile[xAxis, yAxis].type = (ushort)ModContent.TileType<Spiritsand>();
												}
											}
										}
									}
									if (Main.tile[xAxis, yAxis].type == mod.TileType("SpiritStone") && yAxis > (int)((Main.rockLayer + Main.maxTilesY - 500) / 2f) && Main.rand.Next(1500) == 5)
									{
										WorldGen.TileRunner(xAxis, yAxis, (double)WorldGen.genRand.Next(5, 7), 1, mod.TileType("SpiritOreTile"), false, 0f, 0f, true, true);
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
 