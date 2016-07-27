using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class CoiledLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Coiled Leggings";
            item.width = 22;
            item.height = 18;
            AddTooltip("Increases Throwing Damage by 12%");
            item.value = 16000;
            item.rare = 2;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.12f;
        }
    }
}