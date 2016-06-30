using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class CelestialStarbow : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.DaedalusStormbow);
            item.name = "Celestial Starbow";
            item.damage = 30;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.toolTip = "Help from above!";
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.shoot = 9;
            item.useAmmo = 0;
            item.knockBack = 0;
            item.value = 1000;
            item.rare = 1;
            item.useSound = 1;
            item.autoReuse = true;
            item.shootSpeed = 20f;
        }
        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
        {
            var posArray = new Vector2[num];
            float spread = (float)(angle * 0.05274532925);
            float baseSpeed = (float)System.Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = System.Math.Atan2(speedX, speedY);
            double randomAngle;
            for (int i = 0; i < num; ++i)
            {
                randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                posArray[i] = new Vector2(baseSpeed * (float)System.Math.Sin(randomAngle), baseSpeed * (float)System.Math.Cos(randomAngle));
            }
            return (Vector2[])posArray;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2[] speeds = randomSpread(speedX, speedY, 8, 6);
            for (int i = 0; i < 5; ++i)
            {
				Terraria.Projectile.NewProjectile(position.X, position.Y, speeds[i].X, speeds[i].Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}