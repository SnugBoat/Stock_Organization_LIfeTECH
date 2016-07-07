using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Projectiles.Arrow
{
    public class PestilentArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "PestilentArrow";
            projectile.width = 9;
            projectile.height = 17;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.WoodenArrowFriendly;
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