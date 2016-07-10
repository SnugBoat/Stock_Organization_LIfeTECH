using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
    public class CursedFlame : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Cursed Flame";
            projectile.friendly = true;
            projectile.aiStyle = 27;
			projectile.width = 100;
			projectile.height = 100;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.timeLeft = 30;
        }
		
			    public override bool PreAI()
		{
			for (int i = 0; i < 5; ++i)
			{
				projectile.tileCollide = false;
				int dust;
				dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, 0f, 0f);
				Main.dust[dust].scale = 1.5f;
			}
			return false;
}
			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
                target.AddBuff(BuffID.CursedInferno, 120, false);
        }
    }
}