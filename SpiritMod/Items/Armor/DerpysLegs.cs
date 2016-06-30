using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DerpysLegs : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Derpy's Legs";
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