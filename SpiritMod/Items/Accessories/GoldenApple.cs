using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessories
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
			SPlayer sPlayer = (SPlayer)player.GetModPlayer(mod, "SPlayer");
			sPlayer.goldenApple = true;
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
