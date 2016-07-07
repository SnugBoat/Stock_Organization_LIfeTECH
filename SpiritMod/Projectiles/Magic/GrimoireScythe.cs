using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class GrimoireScythe : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
			projectile.hostile = false;
			projectile.magic = true;
			projectile.name = "Grimoire Scythe";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 5;

        }
		
				public override bool PreAI()
		{
			projectile.rotation += 0.1f;
			timer++;
			if (timer >= 60)
			{
				projectile.velocity *= 1.2f;
			}
	
			return true;
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
