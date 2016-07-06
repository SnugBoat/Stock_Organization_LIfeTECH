using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
	public class NPCHook : GlobalNPC
	{
		public override void ResetEffects(NPC npc)
		{
			NPCData info = npc.GetModInfo<NPCData>(mod);
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
            if (npc.GetModInfo<NPCData>(mod).DoomDestiny)
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
