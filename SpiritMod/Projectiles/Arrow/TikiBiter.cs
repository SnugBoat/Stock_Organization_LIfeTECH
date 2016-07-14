﻿using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
	class TikiBiter : ModProjectile
	{
		public static ModProjectile _ref;

		public override void SetDefaults()
		{
			projectile.name = "Tiki Spirit";
			projectile.width = 18;
			projectile.height = 18;
			//projectile.alpha = 0;
			//projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 1;
		}

		public override bool PreAI()
		{
			int i = Main.rand.Next(10);
			if (i < 5)
			{
				float offsetX = projectile.velocity.X * 0.2f * (float)i;
				float offsetY = -(projectile.velocity.Y * 0.2f) * (float)i;
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 2, 0f, 0f, 100);
				Main.dust[dust].position.X -= offsetX;
				Main.dust[dust].position.Y -= offsetY;
				Main.dust[dust].velocity -= projectile.velocity * 0.25f;
			}

			projectile.ai[1] += 1f;
			bool chasing = false;
			if (projectile.ai[1] >= 30f)
			{
				chasing = true;

				projectile.friendly = true;
				NPC target = null;
				if (projectile.ai[0] == -1f)
				{
					target = ProjectileExtras.FindRandomNPC(projectile.Center, 960f, false);
				} else
				{
					target = Main.npc[(int)projectile.ai[0]];
					if (!target.active || !target.CanBeChasedBy())
					{
						target = ProjectileExtras.FindRandomNPC(projectile.Center, 960f, false);
					}
				}

				if (target == null)
				{
					chasing = false;
					projectile.ai[0] = -1f;
				} else
				{
					projectile.ai[0] = (float)target.whoAmI;
					this.HomingAI(target, 4f, 0.05f);
				}
			}

			this.LookAlongVelocity();
			if (!chasing)
			{
				Vector2 dir = projectile.velocity;
				float vel = projectile.velocity.Length();
				if (vel != 0f && vel < 4f)
				{
					dir *= 1 / vel;
					projectile.velocity += dir * 0.0625f;
				}
			}

			return false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//projectile.penetrate--;
			//if (projectile.penetrate <= 0)
			//{
			//	projectile.Kill();
			//} else
			//{
				this.Bounce(oldVelocity);
				projectile.ai[0] = -1f;
			//	//Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			//}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			NPCs.NPCData modNPC = target.GetModInfo<NPCs.NPCData>(mod);
			if (target.life <= 0)
			{
				//Workaround: OnHitNPC gets called after NPCLoot for some reason.
				Vector2 pos = target.Center;
				float vX = Main.rand.Next(-16, 17) * 0.125f;
				float vY = Main.rand.Next(-16, 17) * 0.125f;
				Projectile.NewProjectile(pos.X, pos.Y, vX, vY, _ref.projectile.type, projectile.damage, 0f, projectile.owner, -1f);
			} else
			{
				target.AddBuff(Buffs.TikiInfestation._ref.Type, (int)(Buffs.TikiInfestation.duration * 0.5f));
				modNPC.AddTikiSource(projectile);
			}
		}

	}
}
