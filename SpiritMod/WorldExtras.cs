using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace SpiritMod
{
	public static class WorldExtras
	{
		public static void Explode(float posX, float posY, float radius = 3, bool wallDamage = true)
		{
			int xBegin = (int)(posX / 16f - radius);
			int xEnd = (int)(posX / 16f + radius);
			int yBegin = (int)(posY / 16f - radius);
			int yEnd = (int)(posY / 16f + radius);
			if (xBegin < 0)
			{
				xBegin = 0;
			}
			if (xEnd > Main.maxTilesX)
			{
				xEnd = Main.maxTilesX;
			}
			if (yBegin < 0)
			{
				yBegin = 0;
			}
			if (yEnd > Main.maxTilesY)
			{
				yEnd = Main.maxTilesY;
			}
			bool breakWall = false;
			if (wallDamage)
			{
				for (int x = xBegin; x <= xEnd; x++)
				{
					for (int y = yBegin; y <= yEnd; y++)
					{
						float deltaX = Math.Abs((float)x - posX / 16f);
						float deltaY = Math.Abs((float)y - posY / 16f);
						double dist = Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
						if (dist < (double)radius && Main.tile[x, y] != null && Main.tile[x, y].wall == 0)
						{
							breakWall = true;
							break;
						}
					}
				}
			}
			AchievementsHelper.CurrentlyMining = true;
			for (int x = xBegin; x <= xEnd; x++)
			{
				for (int y = yBegin; y <= yEnd; y++)
				{
					float deltaX = Math.Abs((float)x - posX / 16f);
					float deltaY = Math.Abs((float)y - posY / 16f);
					double dist = Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
					if (dist < (double)radius)
					{
						bool destroyTile = true;
						if (Main.tile[x, y] != null && Main.tile[x, y].active())
						{
							destroyTile = true;
							ushort tile = Main.tile[x, y].type;
							if (Main.tileDungeon[(int)tile] || tile == 88 || tile == 21 || tile == 26 || tile == 107 || tile == 108 || tile == 111 || tile == 226 || tile == 237 || tile == 221 || tile == 222 || tile == 223 || tile == 211 || tile == 404)
							{
								destroyTile = false;
							}
							//patch file: x, y
							if (!Main.hardMode && tile == 58)
							{
								destroyTile = false;
								//patch file: x, y
							}
							if (!TileLoader.CanExplode(x, y))
							{
								destroyTile = false;
							}
							if (destroyTile)
							{
								WorldGen.KillTile(x, y, false, false, false);
								if (!Main.tile[x, y].active() && Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)x, (float)y, 0f, 0, 0, 0);
								}
							}
						}
						if (destroyTile && breakWall)
						{
							for (int wallX = x - 1; wallX <= x + 1; wallX++)
							{
								for (int wallY = y - 1; wallY <= y + 1; wallY++)
								{
									if (Main.tile[wallX, wallY] != null && Main.tile[wallX, wallY].wall > 0)
									{
										WorldGen.KillWall(wallX, wallY, false);
										if (Main.tile[wallX, wallY].wall == 0 && Main.netMode != 0)
										{
											NetMessage.SendData(17, -1, -1, "", 2, (float)wallX, (float)wallY, 0f, 0, 0, 0);
										}
									}
								}
							}
						}
					}
				}
			}
			AchievementsHelper.CurrentlyMining = false;
		}
	}
}
