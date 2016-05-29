using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ethereal
{
	public class EtherealArrow : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.name = "EtherealArrow";
			projectile.width = 6;
			projectile.height = 16;
		}


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(0) == 0)
            {
                target.AddBuff(mod.BuffType("EssenceTrap"), 540, true);
            }
        }
    }
}