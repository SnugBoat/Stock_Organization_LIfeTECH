using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class PutridKnife : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Putrid Knife";
            item.useStyle = 1;
            item.width = 30;
            item.height = 50;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("PutridKnifeProjectile");
            item.useAnimation = 11;
			item.useTime = 11;
            item.consumable = true;
            item.maxStack = 999;
            item.shootSpeed = 10f;
            item.damage = 72;
            item.knockBack = 1;
			item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.autoReuse = true;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
    }
}