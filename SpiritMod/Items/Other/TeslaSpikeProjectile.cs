using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Other
{
    public class TeslaSpikeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Tesla Spike Projectile";
            projectile.width = 16;
            projectile.height = 158;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 20;
            projectile.alpha = 255;
            projectile.light = 0.5f;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Bullet;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(0) == 0)
            {
                target.AddBuff(mod.BuffType("ElectrifiedV2"), 540, true);
            }
        }
    }
}