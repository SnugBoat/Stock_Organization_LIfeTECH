using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
	public class PutridPick : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Putrid Pick";
			item.width = 36;
			item.height = 38;
			item.toolTip = "";
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 3;
			item.damage = 32;
			item.knockBack = 4f;
			item.useStyle = 1;
			item.useTime = 7;
			item.useAnimation = 16;
			item.pick = 200;
			item.melee = true;
			item.autoReuse = true;
			item.useSound = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "PutridPiece", 5);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
