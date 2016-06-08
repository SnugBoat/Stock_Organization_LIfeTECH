using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Rune
{
    public class SwordRuneProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "SwordRuneProjectile";
            projectile.width = 20;
            projectile.height = 28;
            projectile.friendly = true;
            aiType = ProjectileID.DesertDjinnCurse;

        }
    }
}