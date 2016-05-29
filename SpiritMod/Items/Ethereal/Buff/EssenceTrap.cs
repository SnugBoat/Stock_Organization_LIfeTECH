using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ethereal.Buff
{
    public class EssenceTrap : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Essence Trap";
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 10;
            npc.defense -= 4;      
        }
    }
}