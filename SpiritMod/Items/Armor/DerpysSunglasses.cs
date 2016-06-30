using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DerpysSunglasses : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {

            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            
            item.name = "Derpy's Sunglasses";
            item.width = 34;
            item.height = 30;
            item.expert = true;
            item.vanity = true;
            
        }
        public override bool DrawHead()
        {
            return true;
        }
    }
}