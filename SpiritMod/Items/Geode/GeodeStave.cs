using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Geode
{
	public class GeodeStave : ModItem
	{
		public override void SetDefaults()
		{
            
			item.name = "Geode Staff";
			item.damage = 42;
			item.magic = true;
			item.mana = 20;
			item.width = 22;
			item.height = 34;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 4;
			item.useSound = 20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("GeodeStaveProjectile");
			item.shootSpeed = 4;
            item.crit = 6;
        }
        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

        }

	}
}