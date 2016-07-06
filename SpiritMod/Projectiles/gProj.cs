using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
    public class gProj : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {//todo - forking lightning in Kill(), kill projectile when far from player in AI(), homing in OnHitNPC()
            if (projectile.aiStyle == 88 && projectile.knockBack == .5f || (projectile.knockBack >= .2f && projectile.knockBack < .5f))
            {
                projectile.hostile = false;
                projectile.friendly = true;
                projectile.magic = true;
            }
        }
    }
}
