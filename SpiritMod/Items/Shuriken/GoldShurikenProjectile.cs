using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Shuriken
{
    public class GoldShurikenProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Shuriken);
            projectile.name = "Gold Shuriken";         
            projectile.width = 26;
            projectile.height = 26;


        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(15) == 0)
            {
                target.AddBuff(BuffID.BrokenArmor, 200, true);
            }            
        }
    }
}