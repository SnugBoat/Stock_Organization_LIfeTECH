using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.Mounts;

namespace SpiritMod
{
	class PlayerHook : ModPlayer
	{
		public bool onGround = false;
		public bool moving = false;
		public bool flying = false;
		public bool swimming = false;
		
		public bool copterBrake = false;
		public bool copterFiring = false;
		public int copterFireFrame = 1000;

		public bool bismiteSet = false;

		public override void FrameEffects()
		{
			////Supposed to make players legs disappear, but only makes them skin-colored.
			//if (player.mount.Active && player.mount.Type == CandyCopter._data.Type)
			//{
			//	player.legs = CandyCopter._outfit;
			//}
		}

		public override void PostUpdateRunSpeeds()
		{
			if (copterBrake && player.mount.Active && player.mount.Type == CandyCopter._ref.Type)
			{
				//Prevent horizontal movement
				player.maxRunSpeed = 0f;
				player.runAcceleration = 0f;
				//Deplete horizontal velocity
				if (player.velocity.X > CandyCopter.groundSlowdown)
				{
					player.velocity.X -= CandyCopter.groundSlowdown;
				} else if (player.velocity.X < -CandyCopter.groundSlowdown)
				{
					player.velocity.X += CandyCopter.groundSlowdown;
				} else
				{
					player.velocity.X = 0f;
				}
				//Prevent further depletion by game engine
				player.runSlowdown = 0f;
			}
		}

		//public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		//{
		//	if (bismiteSet)
		//	{
		//		target.AddBuff(Buffs.Diseased._ref.Type, 3600);
		//	}
		//}

		//public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		//{
		//	if (bismiteSet)
		//	{
		//		target.AddBuff(Buffs.Diseased._ref.Type, 3600);
		//	}
		//}

		public override void PreUpdate()
		{
			//Reset all
			bismiteSet = false;

			copterFireFrame++;

			onGround = false;
			moving = false;
			flying = false;
			swimming = false;

			if (player.velocity.Y != 0f)
			{
				if (player.mount.Active && player.mount.FlyTime > 0 && player.jump == 0 && player.controlJump && !player.mount.CanHover)
				{
					flying = true;
				} else if (player.wet)
				{
					swimming = true;
				}
			} else
			{
				onGround = true;
			}
			if (player.velocity.X != 0f)
			{
				moving = true;
			}
		}
	}
}
