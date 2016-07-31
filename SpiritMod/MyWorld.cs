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

        public static bool spiritBiome = false;

        public override void TileCountsAvailable(int[] tileCounts)
        {
            SpiritTiles = tileCounts[mod.TileType("SpiritDirt")] + tileCounts[mod.TileType("SpiritStone")] + tileCounts[mod.TileType("Spiritsand")] + tileCounts[mod.TileType("SpiritIce")];
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
