using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Paladin
{
    public class PaladinsHammer : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.PaladinsHammer)
            {
                item.thrown = true;
                item.autoReuse = true;
                item.useTime = 16;
                item.useAnimation = 16;
                item.damage = 90;
                item.melee = false;
                item.damage = 80;
                
            }
        }
    }
}