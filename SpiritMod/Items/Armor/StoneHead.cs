using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class StoneHead : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Stone Helmet";
            item.width = 18;
            item.height = 22;
            item.toolTip = "Decreases Movement Speed by 4%";
            item.value = 0000;
            item.rare = 1;
            item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed -= 0.04f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("StoneBody") && legs.type == mod.ItemType("StoneLegs");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "Increases Melee Damage by 5%";
            player.meleeDamage += 0.05f;

        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 40);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}