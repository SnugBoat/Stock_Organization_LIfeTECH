﻿using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon
{
    public class InfernalJavelin : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Infernal Javelin";
            item.width = item.height = 42;
            item.toolTip = "???";
            item.rare = 4;
            item.maxStack = 999;

            item.damage = 10;
            item.knockBack = 2;

            item.useStyle = 1;
            item.useTime = item.useAnimation = 25;

            item.melee = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.consumable = true;
            item.noUseGraphic = true;

            item.shoot = mod.ProjectileType("InfernalJavelin");
            item.shootSpeed = 10;

            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddIngredient(ItemID.HellstoneBar, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
