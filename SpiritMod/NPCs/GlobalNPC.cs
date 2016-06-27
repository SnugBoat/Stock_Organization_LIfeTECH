using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
	public class SpiritGlobalNPC : GlobalNPC
	{
		public override void ResetEffects(NPC npc)
		{
			GlobalNPCInfo info = (GlobalNPCInfo)npc.GetModInfo(mod, "GlobalNPCInfo");
			info.DoomDestiny = false;
		}
		
		public override void NPCLoot(NPC npc)
		{
		  if (npc.type == NPCID.Plantera)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThornbloomKnife"), Main.rand.Next(40, 60));
			}
		}

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.GetModInfo<GlobalNPCInfo>(mod).DoomDestiny)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 16;
                if (damage < 10)
                {
                    damage = 10;
                }
            }
        }
    }
}
