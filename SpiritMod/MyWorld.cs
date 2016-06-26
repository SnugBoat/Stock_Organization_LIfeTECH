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

public static bool spiritBiome = false;

	public override void PostUpdate() 
	{
            if (NPC.downedMechBoss3 == true)
            {
			if (spiritBiome == false)
			{
			spiritBiome = true;
			Main.NewText("The ancient spirits have been revived.", Color.Orange.R, Color.Orange.G, Color.Orange.B);
			int Xvalue = WorldGen.genRand.Next(300, Main.maxTilesX - 600);
			int Yvalue = (int)Main.worldSurface - 300;
			int XvalueHigh = Xvalue + 160;
			int YvalueHigh = Yvalue + 600;
			int XvalueMid = Xvalue + 80;
			int YvalueMid = Yvalue + 300;
			for (int A = Xvalue; A < XvalueHigh; A++)
			{
				for (int B = Yvalue; B < YvalueHigh; B++)
				{
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
							WorldGen.PlaceTile(A, B, mod.TileType("SpiritWood"));
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