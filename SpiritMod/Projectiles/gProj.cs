﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
    public class gProj : GlobalProjectile
    {
		 public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.aiStyle == 88 && (projectile.knockBack >= .2f && projectile.knockBack <= .5f))
            {
                target.immune[projectile.owner] = 6;
            }
        }
        public override bool? CanHitNPC(Projectile projectile, NPC target)
        {
            if (projectile.aiStyle == 88 && ((projectile.knockBack == .5f || projectile.knockBack == .4f) || (projectile.knockBack >= .4f && projectile.knockBack < .5f)) && target.immune[projectile.owner] > 0)
            {
                return false;
            }
            return null;
        }
		 public override void AI(Projectile projectile)
        {//todo - forking lightning in Kill(), kill projectile when far from player in AI(), homing in OnHitNPC()
            if (projectile.aiStyle == 88 && projectile.knockBack == .5f || (projectile.knockBack >= .2f && projectile.knockBack < .5f))
            {
                projectile.hostile = false;
                projectile.friendly = true;
                projectile.magic = true;
				projectile.penetrate = 1000;
            }
        }
    }
}
