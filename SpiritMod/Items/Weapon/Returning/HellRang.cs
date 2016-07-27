using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Returning
{
	public class HellRang : ModItem
	{
		public override void SetDefaults()
		{
            item.name = "Hellstone Chakram";
            item.damage = 20;            
            item.melee = true;
            item.width = 38;
            item.height = 38;
			item.toolTip = "Hot. Hot. Hot. Hot!";
			item.useTime = 27;
			item.useAnimation = 25;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.knockBack = 6;
			item.value = 8;
			item.rare = 3;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType ("HellP");
			item.useSound = 1;
			item.autoReuse = true;
		}
        public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.HellstoneBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
		}
    }
}