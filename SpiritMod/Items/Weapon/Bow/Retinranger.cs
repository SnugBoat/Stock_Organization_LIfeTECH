using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class Retinranger : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Retinranger";
            item.damage = 44;
            item.noMelee = true;
            item.ranged = true;
            item.width = 50;
            item.height = 42;
            item.useTime = 18;
            item.toolTip = "Turns Arrows into Lasers!";
            item.useAnimation = 14;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 3;
            item.value = 80000;
            item.rare = 6;
            item.useSound = 5;
            item.autoReuse = true;
            item.shootSpeed = 8.8f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int projectileFired = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.DeathLaser, item.damage, item.knockBack, item.owner);
            Main.projectile[projectileFired].friendly = true;
            Main.projectile[projectileFired].hostile = false;
            return false;
        }
    }
}