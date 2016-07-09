using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class PestilentPlatemail : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Pestilent Platemail";
            item.width = 34;
            item.height = 30;
            AddTooltip("Increases ranged damage, ranged critical strike chance, and 25% chance to not consume ammo");
            item.value = 10;
            item.rare = 8;
            item.defense = 21;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.05f;
            player.rangedCrit += 15;
            player.ammoCost75 = true;
        }
    }
}