using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Spirit
{
	public class SpiritSkull : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Spirit Skull";
			npc.width = 40;
			npc.height = 52;
			npc.damage = 35;
			npc.defense = 10;
			npc.knockBackResist = 0.2f;
			npc.lifeMax = 95;
			npc.soundHit = 2;
			npc.soundKilled = 2;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.npcSlots = 0.75f;
		}

		public override bool PreAI()
		{
			float velMax = 1f;
			float acceleration = 0.011f;
			npc.TargetClosest(true);
			Vector2 center = npc.Center;
			float deltaX = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - center.X;
			float deltaY = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - center.Y;
			float distance = (float)Math.Sqrt((double)deltaX * (double)deltaX + (double)deltaY * (double)deltaY);
			npc.ai[1] += 1f;
			if ((double)npc.ai[1] > 600.0)
			{
				acceleration *= 8f;
				velMax = 4f;
				if ((double)npc.ai[1] > 650.0)
				{
					npc.ai[1] = 0f;
				}
			}
			else if ((double)distance < 250.0)
			{
				npc.ai[0] += 0.9f;
				if (npc.ai[0] > 0f)
				{
					npc.velocity.Y = npc.velocity.Y + 0.019f;
				}
				else
				{
					npc.velocity.Y = npc.velocity.Y - 0.019f;
				}
				if (npc.ai[0] < -100f || npc.ai[0] > 100f)
				{
					npc.velocity.X = npc.velocity.X + 0.019f;
				}
				else
				{
					npc.velocity.X = npc.velocity.X - 0.019f;
				}
				if (npc.ai[0] > 200f)
				{
					npc.ai[0] = -200f;
				}
			}
			if ((double)distance > 350.0)
			{
				velMax = 5f;
				acceleration = 0.3f;
			}
			else if ((double)distance > 300.0)
			{
				velMax = 3f;
				acceleration = 0.2f;
			}
			else if ((double)distance > 250.0)
			{
				velMax = 1.5f;
				acceleration = 0.1f;
			}
			float stepRatio = velMax / distance;
			float velLimitX = deltaX * stepRatio;
			float velLimitY = deltaY * stepRatio;
			if (Main.player[npc.target].dead)
			{
				velLimitX = (float)((double)((float)npc.direction * velMax) / 2.0);
				velLimitY = (float)((double)(-(double)velMax) / 2.0);
			}
			if (npc.velocity.X < velLimitX)
			{
				npc.velocity.X = npc.velocity.X + acceleration;
			}
			else if (npc.velocity.X > velLimitX)
			{
				npc.velocity.X = npc.velocity.X - acceleration;
			}
			if (npc.velocity.Y < velLimitY)
			{
				npc.velocity.Y = npc.velocity.Y + acceleration;
			}
			else if (npc.velocity.Y > velLimitY)
			{
				npc.velocity.Y = npc.velocity.Y - acceleration;
			}
			if ((double)velLimitX > 0.0)
			{
				npc.spriteDirection = -1;
				npc.rotation = (float)Math.Atan2((double)velLimitY, (double)velLimitX);
			}
			if ((double)velLimitX < 0.0)
			{
				npc.spriteDirection = 1;
				npc.rotation = (float)Math.Atan2((double)velLimitY, (double)velLimitX) + 3.14f;
			}
			return false;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneSpirit ? 1f : 0f;
		}
	}
}
