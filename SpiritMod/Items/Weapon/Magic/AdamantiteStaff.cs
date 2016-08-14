using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class AdamantiteStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Adamantite Staff";
			item.damage = 50;
			item.magic = true;
			item.mana = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 0;
			item.value = 0200;
			item.rare = 2;
			item.useSound = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("AdamantiteStaffProj");
			item.shootSpeed = 30f;
		}
		
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
