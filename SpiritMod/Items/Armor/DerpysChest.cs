using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DerpysChest : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Derpy's Chest";
            item.width = 34;
            item.height = 30;
            item.value = 10;
            item.expert = true;
            
        }

        public override void UpdateEquip(Player player)
        {
            
        }
    }
}