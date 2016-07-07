using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class BlightedBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Blighted Bow";
            item.damage = 50;
            item.noMelee = true;
            item.ranged = true;
            item.width = 24;
            item.height = 46;
            item.useTime = 18;
            item.toolTip = "Arrows turn into pestilent arrows";
            item.useAnimation = 18;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 8;
            item.useSound = 5;
            item.autoReuse = true;
            item.shootSpeed = 6f;
        }
            public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("PestilentArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
