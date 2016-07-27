using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon
{
    public class SpazLung : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "SpazLung";
            item.damage = 32;
            item.noMelee = true;
            item.ranged = true;
            item.width = 58;
            item.height = 20;
            item.useTime = 34;
            item.toolTip = "Turns Arrows into Lasers!";
            item.useAnimation = 14;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 23;
            item.knockBack = 3;
            item.value = 80000;
            item.rare = 6;
            item.useSound = 34;
            item.autoReuse = true;
            item.shootSpeed = 7f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int projectileFired = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.EyeFire, item.damage, item.knockBack, item.owner);
            Main.projectile[projectileFired].friendly = true;
            Main.projectile[projectileFired].hostile = false;
            return false;
        }
    }
}