using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
	public class ShootingStar : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Shooting Star";
			npc.width = 24;
			npc.height = 24;
			npc.damage = 50;
			npc.defense = 20;
			npc.lifeMax = 400;
			npc.soundHit = 1;
			npc.soundKilled = 1;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = 3;
		}

		public override bool PreAI()
		{
			npc.noGravity = true;
			if (!npc.noTileCollide)
			{
				if (npc.collideX)
				{
					npc.velocity.X = npc.oldVelocity.X * -0.5f;
					if (npc.direction == -1 && (double)npc.velocity.X > 0.0 && (double)npc.velocity.X < 2.0)
					{
						npc.velocity.X = 2f;
					}
					if (npc.direction == 1 && (double)npc.velocity.X < 0.0 && (double)npc.velocity.X > -2.0)
					{
						npc.velocity.X = -2f;
					}
				}
				if (npc.collideY)
				{
					npc.velocity.Y = npc.oldVelocity.Y * -0.5f;
					if ((double)npc.velocity.Y > 0.0 && (double)npc.velocity.Y < 1.0)
					{
						npc.velocity.Y = 1f;
					}
					if ((double)npc.velocity.Y < 0.0 && (double)npc.velocity.Y > -1.0)
					{
						npc.velocity.Y = -1f;
					}
				}
			}
			npc.TargetClosest(true);
			float velScaleX = 10f;
			float velScaleY = 1.5f;
			float maxVelX = velScaleX * (2f - npc.scale);
			float maxVelY = velScaleY * (2f - npc.scale);
			if (npc.direction == -1 && (double)npc.velocity.X > -(double)maxVelX)
			{
				npc.velocity.X = npc.velocity.X - 0.1f;
				if ((double)npc.velocity.X > (double)maxVelX)
				{
					npc.velocity.X = npc.velocity.X - 0.1f;
				}
				else if ((double)npc.velocity.X > 0.0)
				{
					npc.velocity.X = npc.velocity.X + 0.05f;
				}
				if ((double)npc.velocity.X < -(double)maxVelX)
				{
					npc.velocity.X = -maxVelX;
				}
			}
			else if (npc.direction == 1 && (double)npc.velocity.X < (double)maxVelX)
			{
				npc.velocity.X = npc.velocity.X + 0.1f;
				if ((double)npc.velocity.X < -(double)maxVelX)
				{
					npc.velocity.X = npc.velocity.X + 0.1f;
				}
				else if ((double)npc.velocity.X < 0.0)
				{
					npc.velocity.X = npc.velocity.X - 0.05f;
				}
				if ((double)npc.velocity.X > (double)maxVelX)
				{
					npc.velocity.X = maxVelX;
				}
			}
			if (npc.directionY == -1 && (double)npc.velocity.Y > -(double)maxVelY)
			{
				npc.velocity.Y = npc.velocity.Y - 0.04f;
				if ((double)npc.velocity.Y > (double)maxVelY)
				{
					npc.velocity.Y = npc.velocity.Y - 0.05f;
				}
				else if ((double)npc.velocity.Y > 0.0)
				{
					npc.velocity.Y = npc.velocity.Y + 0.03f;
				}
				if ((double)npc.velocity.Y < -(double)maxVelY)
				{
					npc.velocity.Y = -maxVelY;
				}
			}
			else if (npc.directionY == 1 && (double)npc.velocity.Y < (double)maxVelY)
			{
				npc.velocity.Y = npc.velocity.Y + 0.04f;
				if ((double)npc.velocity.Y < -(double)maxVelY)
				{
					npc.velocity.Y = npc.velocity.Y + 0.05f;
				}
				else if ((double)npc.velocity.Y < 0.0)
				{
					npc.velocity.Y = npc.velocity.Y - 0.03f;
				}
				if ((double)npc.velocity.Y > (double)maxVelY)
				{
					npc.velocity.Y = maxVelY;
				}
			}
			if ((double)npc.velocity.X > 0.0)
			{
				npc.spriteDirection = 1;
				npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + (float)(Math.PI / 2d);
			}
			if ((double)npc.velocity.X < 0.0)
			{
				npc.spriteDirection = -1;
				npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + (float)(Math.PI / 2d);
			}
			if (!npc.wet)
			{
				return false;
			}
			if ((double)npc.velocity.Y > 0.0)
			{
				npc.velocity.Y = npc.velocity.Y * 0.95f;
			}
			npc.velocity.Y = npc.velocity.Y - 0.5f;
			if ((double)npc.velocity.Y < -4.0)
			{
				npc.velocity.Y = -4f;
			}
			npc.TargetClosest(true);
			return false;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.10000000149011612;
			if ((int)npc.frameCounter >= Main.npcFrameCount[npc.type])
			{
				npc.frameCounter -= (double)Main.npcFrameCount[npc.type];
			}
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
			npc.spriteDirection = npc.direction;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			if (!spawnInfo.sky)
			{
				return 0f;
			}
			if (!NPC.downedMechBossAny)
			{
				return 1.5f;
			}
			return 3f;
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(20) == 0)
			{
				Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarPiece"));
			}
		}
	}
}
