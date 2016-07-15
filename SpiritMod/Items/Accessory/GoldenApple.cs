using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class GoldenApple : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Golden Apple";
			item.width = 18;
			item.height = 18;
			item.toolTip = "";
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = 8;
			item.defense = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			float defBoost = (float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2 * 20f;
			player.statDefense += (int)defBoost;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(2, 1);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
