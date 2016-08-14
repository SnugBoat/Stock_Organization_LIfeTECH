using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class TitaniumStaffProj2 : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.hostile = false;
			projectile.magic = true;
			projectile.name = "Titanium Staff";
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;

        }
		
				public override bool PreAI()
		{
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 36, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);      
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;		
	
			return true;
		}

    }
}
