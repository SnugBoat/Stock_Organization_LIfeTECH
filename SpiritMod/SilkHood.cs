using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class SilkHood : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Silk Hood";
            item.width = 22;
            item.height = 22;
            item.toolTip = "Increases Minion Damage by 4%";
            item.value = 20000;
            item.rare = 2;
            item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.04f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("SilkRobe") && legs.type == mod.ItemType("SilkLegs");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "Increases Minion Damage and Knockback";
            player.minionKB += 0.05f;
            player.minionDamage += 0.05f;

        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddIngredient(ItemID.GoldBar, 1);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}