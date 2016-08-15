using System.IO;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace SpiritMod
{
	public class MyWorld : ModWorld
	{
		private int WillGenn = 0;
				private int Meme;
        public static int SpiritTiles = 0;
		public static int VerdantTiles = 0;

        public static bool spiritBiome = false;

        public override void TileCountsAvailable(int[] tileCounts)
        {
            SpiritTiles = tileCounts[mod.TileType("SpiritDirt")] + tileCounts[mod.TileType("SpiritStone")] + tileCounts[mod.TileType("Spiritsand")] + tileCounts[mod.TileType("SpiritIce")];
			 VerdantTiles = tileCounts[mod.TileType("VeridianDirt")] + tileCounts[mod.TileType("VeridianStone")];
        }

        public override void Initialize()
        {
            if (NPC.downedMechBoss3 == true)
            {
                spiritBiome = true;
            }
            else
            {
                spiritBiome = false;
            }
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				// Shinies pass removed by some other mod.
				return;
			}
			tasks.Insert(ShiniesIndex +  2, new PassLegacy("MysticBiomeGen", delegate(GenerationProgress progress)
			{
                progress.Message = "Thinking of text to go here";
               
                for (int i = 0; i < (int)Main.maxTilesX / 250; i++)
				{
					int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
					int Yvalue = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 300);
					int XvalueHigh = Xvalue + 240;
					int YvalueHigh = Yvalue + 160;
					int XvalueMid = Xvalue + 120;
					int YvalueMid = Yvalue + 80;
					 if (Main.tile[XvalueMid,YvalueMid] != null)
                    {
                    if (Main.tile[XvalueMid,YvalueMid].type ==  1) // A = x, B = y.
                    { 
					WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(80,80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true); //c = x, d = y
                    WorldGen.TileRunner(XvalueMid + 20, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true); //c = x, d = y
                    WorldGen.TileRunner(XvalueMid + 40, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true); //c = x, d = y
                    WorldGen.TileRunner(XvalueMid + 60, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true);
                    WorldGen.TileRunner(XvalueMid + 80, YvalueMid, (double)WorldGen.genRand.Next(80, 80), 1, mod.TileType("VeridianDirt"), false, 0f, 0f, true, true);//c = x, d = y
                                                                                                                                                                     /*		for (int A = Xvalue; A < XvalueHigh; A++)
                                                                                                                                                                             {
                                                                                                                                                                                 for (int B = Yvalue; B < YvalueHigh; B++)
                                                                                                                                                                                 {
                                                                                                                                                                                     if (Main.tile[A,B] != null)
                                                                                                                                                                                     {
                                                                                                                                                                                         if (Main.tile[A,B].type ==  mod.TileType("CrystalBlock")) // A = x, B = y.
                                                                                                                                                                                         { 
                                                                                                                                                                                             WorldGen.KillWall(A, B);
                                                                                                                                                                                             WorldGen.PlaceWall(A, B, mod.WallType("CrystalWall"));
                                                                                                                                                                                         }
                                                                                                                                                                                     }
                                                                                                                                                                                 }
                                                                                                                                                                             }*/

                    WorldGen.digTunnel(XvalueMid, YvalueMid, WorldGen.genRand.Next(0, 360),WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(10, 11), WorldGen.genRand.Next(8, 10), false);
                    WorldGen.digTunnel(XvalueMid + 50, YvalueMid, WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(0, 360), WorldGen.genRand.Next(10, 11), WorldGen.genRand.Next(8, 10), false);
					for (int Ore = 0; Ore < 250; Ore++)
                    {
                        int Xore = XvalueMid + Main.rand.Next(100);
                        int Yore = YvalueMid + Main.rand.Next(-70, 70);
                        if (Main.tile[Xore, Yore].type == mod.TileType("VeridianDirt")) // A = x, B = y.
                        {
                            WorldGen.TileRunner(Xore, Yore, (double)WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(3, 6), mod.TileType("VeridianStone"), false, 0f, 0f, false, true);
                        }
                    }
				}}}
			}));
		}
	public override void PostUpdate() 
	{
            if (InvasionHandler.currentInvasion != null)
			{
                Main.invasionWarn = 3600;
			}

            if (NPC.downedMechBoss3 == true)
            {
			if (spiritBiome == false)
			{
			spiritBiome = true;
			Main.NewText("The Spirits spread through the Land...", Color.Orange.R, Color.Orange.G, Color.Orange.B);
			Random rand = new Random();
			int XTILE = WorldGen.genRand.Next(75, Main.maxTilesX - 600);
            int xAxis = XTILE;
			int xAxisMid = xAxis + 50;
			int xAxisEdge = xAxis + 350;
            int yAxis = 0;
			for (int y = 0; y < Main.maxTilesY; y++)
                {
                    yAxis++;
                    xAxis = XTILE;

                for (int i = 0; i < 400; i++)
                {
                    xAxis++;


                        if (Main.tile[xAxis, yAxis] != null)
                        {
                            if (Main.tile[xAxis, yAxis].active())
                            {
                                int[] TileArray = { 0, 28};
                                for (int BiomeDirtReplace = 0; BiomeDirtReplace < 2; BiomeDirtReplace++)
                                {
                                    if (Main.tile[xAxis, yAxis].type == (ushort)TileArray[BiomeDirtReplace])
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
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritGrass");
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
                                            Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritGrass");
											}
                                        }

                                        
                                    }
                                }

                                int[] TileArray1 = { 2, 23, 109, 199 };
                                for (int BiomeGrassReplace = 0; BiomeGrassReplace < 4; BiomeGrassReplace++)
                                {
                                    if (Main.tile[xAxis, yAxis].type == (ushort)TileArray1[BiomeGrassReplace])
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
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritGrass");
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
                                            Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritGrass");
											}
                                        }
                                    }

                                }
								 int[] TileArray2 = { 1, 25, 117, 203 };
                                for (int BiomeStoneReplace = 0; BiomeStoneReplace < 4; BiomeStoneReplace++)
                                {
                                    if (Main.tile[xAxis, yAxis].type == (ushort)TileArray2[BiomeStoneReplace])
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
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritStone");
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
                                            Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritStone");
											}
                                        }
                                    }

                                }
								 int[] TileArray3 = { 53, 116, 112, 234 };
                                for (int BiomeSandReplace = 0; BiomeSandReplace < 4; BiomeSandReplace++)
                                {
                                    if (Main.tile[xAxis, yAxis].type == (ushort)TileArray3[BiomeSandReplace])
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
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritSand");
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
                                            Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritStone");
											}
                                        }
                                    }

                                }
								 int[] TileArray4 = { 161, 163, 200, 164 };
                                for (int BiomeIceReplace = 0; BiomeIceReplace < 4; BiomeIceReplace++)
                                {
                                    if (Main.tile[xAxis, yAxis].type == (ushort)TileArray4[BiomeIceReplace])
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
                                                Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritIce");
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
                                            Main.tile[xAxis, yAxis].type = (ushort)mod.TileType("SpiritIce");
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
			}
}
}
