﻿using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class MedusaShield : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Shield);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Medusa Shield";
            item.toolTip = "Provides Immunity to Knockback and the Stoned Debuff.";
            item.toolTip2 = "As your health goes down, your life regen increases.";
            item.width = 28;
            item.height = 36;
            item.rare = 6;

            item.defense = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            float defBoost = (float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2 * 20f;
            player.statDefense += (int)defBoost;
            player.buffImmune[BuffID.Stoned] = true;
        }
    }
}
