using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class GNPC : GlobalNPC
    {
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.fireStacks > 0)
            {
                if (npc.HasBuff(mod.BuffType("StackingFireBuff")) < 0)
                {
                    info.fireStacks = 0;
                    return;
                }

                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 16;
                damage = info.fireStacks * 5;
            }
        }
    }
}
