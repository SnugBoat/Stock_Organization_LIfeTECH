using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
    public class PestilentPikeProj : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Trident);
            projectile.name = "Pestilent Pike";
            aiType = ProjectileID.Trident;
            projectile.aiStyle = 19;
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