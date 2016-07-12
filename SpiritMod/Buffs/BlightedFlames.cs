using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class BlightedFlames : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffName[this.Type] = "Blighted Flames";
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 30;
            npc.defense -= 20;

            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 61);      
				Main.dust[dust].scale = 3f;
				Main.dust[dust].noGravity = true;		
            }
        }
    }
}