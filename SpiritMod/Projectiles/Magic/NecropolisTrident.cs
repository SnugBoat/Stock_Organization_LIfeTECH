using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class NecropolisTrident : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.name = "Necropolis Trident";
            projectile.friendly = true;
            projectile.aiStyle = 27;
			projectile.width = 24;
			projectile.height = 24;
			projectile.penetrate = -1;
        }
		
			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.CursedInferno, 60, false);
            }
        }
	
    }
}