using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	public class SpiritBoom : ModProjectile
	{
		public override void SetDefaults()
        { 
			projectile.name = "UnstableOrb";
            projectile.width = 43;
            projectile.height = 53;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.hostile = false;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 7;
        }

        public override bool PreAI()
        {
            if (projectile.ai[0] == 0f)
            {
                projectile.Damage();
                projectile.ai[0] = 1f;
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame > Main.projFrames[projectile.type])
                {
                    projectile.Kill();
                }
            }
            return false;
        }
    }
}