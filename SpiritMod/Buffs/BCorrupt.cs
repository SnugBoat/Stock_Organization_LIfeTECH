using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class BCorrupt : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Blood Corruption";
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
                npc.lifeRegen = 0;
            npc.lifeRegen -= 4;
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 5);
            }
        }
    }
}