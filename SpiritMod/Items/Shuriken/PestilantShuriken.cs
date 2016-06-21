using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Shuriken
{
    public class PestilantShuriken : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.name = "Pestilant Shuriken";
            item.width = 26;
            item.height = 26;           
            item.shoot = mod.ProjectileType("PestilantShurikenProjectile");
            item.useAnimation = 18;
            item.useTime = 18;
            item.shootSpeed = 11f;
            item.damage = 73;
            item.knockBack = 0f;
            item.value = Item.buyPrice(0, 0, 0, 50);
            item.crit = 4;
            item.rare = 1;
        }

    }
}