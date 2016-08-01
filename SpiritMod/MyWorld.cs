using System.IO;
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
                Main.invasionWarn = 3600;

            if (NPC.downedMechBoss3 == true)
            {
			if (spiritBiome == false)
			{
			spiritBiome = true;
			Main.NewText("The ancient spirits have been revived.", Color.Orange.R, Color.Orange.G, Color.Orange.B);
			int Xvalue = WorldGen.genRand.Next(300, Main.maxTilesX - 600);
			int Yvalue = (int)Main.worldSurface - 300;
			int XvalueHigh = Xvalue + 300;
			int YvalueHigh = Yvalue + 600;
			int XvalueMid = Xvalue + 80;
			int YvalueMid = Yvalue + 160;
			for (int A = XvalueHigh; A > Xvalue; A--)
			{
				for (int B = Yvalue; B < YvalueHigh; B++)
				{
					/*	if (Main.tile[A,B].wall == 2)
						{ 
							WorldGen.KillWall(A, B);
							WorldGen.PlaceWall(A, B, mod.WallType("SpiritWall"));
						}
						if (Main.tile[A,B].wall == 1)
						{ 
							WorldGen.KillWall(A, B);
							WorldGen.PlaceWall(A, B, mod.WallType("SpiritWall"));
						}
						if (Main.tile[A,B].wall == 40)
						{ 
							WorldGen.KillWall(A, B);
							WorldGen.PlaceWall(A, B, mod.WallType("SpiritWall"));
						}
                        if (Main.tile[A,B].wall >= 48 && Main.tile[A,B].wall <= 65)
						{ 
							WorldGen.KillWall(A, B);
							WorldGen.PlaceWall(A, B, mod.WallType("SpiritWall"));
						}
						if (Main.tile[A,B].wall >= 188 && Main.tile[A,B].wall <= 222)
						{ 
							WorldGen.KillWall(A, B);
							WorldGen.PlaceWall(A, B, mod.WallType("SpiritWall"));
						}
						if (Main.tile[A,B].wall == 81 || Main.tile[A,B].wall == 3 || Main.tile[A,B].wall == 69 || Main.tile[A,B].wall == 70 || Main.tile[A,B].wall == 71 || Main.tile[A,B].wall == 83 || Main.tile[A,B].wall == 170 || Main.tile[A,B].wall == 171)
						{ 
							WorldGen.KillWall(A, B);
							WorldGen.PlaceWall(A, B, mod.WallType("SpiritWall"));
						}*/
						if (Main.rand.Next(30) == 5)
						{
						int J = WorldGen.PlaceChest(A, B, (ushort)mod.TileType("SpiritNaturalChest"), false, 0);
						}
					if (Main.tile[A,B].active())
					{
						if (Main.tile[A,B].type == TileID.Dirt)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritDirt"));
						}
						else if (Main.tile[A,B].type == TileID.Stone) // A = x, B = y.
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritStone"));
						}
						else if (Main.tile[A,B].type == 5)
						{ 
							WorldGen.KillTile(A, B);
						}
						else if (Main.tile[A,B].type == 199)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritGrass"));
						}
						else if (Main.tile[A,B].type == TileID.Sand)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("Spiritsand"));
						}
						else if (Main.tile[A,B].type == TileID.Grass)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritGrass"));
						}
						else if (Main.tile[A,B].type == 161)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritIce"));
						}
                        else if (Main.tile[A,B].type == TileID.CorruptGrass)
						{ 
							WorldGen.KillTile(A, B);
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritGrass"));
						}		
					}
				}
			} 
		}
		}
	}
}
}
