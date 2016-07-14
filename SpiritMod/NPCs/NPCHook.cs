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
			NPCData data = npc.GetModInfo<NPCData>(mod);
			data.DoomDestiny = false;

			if (npc.HasBuff(Buffs.TikiInfestation._ref.Type) < 0)
			{
				data.TikiStacks = 0;
				data.TikiSlot = 0;
			}
		}

		public override void NPCLoot(NPC npc)
		{
			NPCData data = npc.GetModInfo<NPCData>(mod);
			if (npc.type == NPCID.Plantera)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThornbloomKnife"), Main.rand.Next(40, 60));
			}
			
		}

		public override bool PreNPCLoot(NPC npc)
		{
			NPCData data = npc.GetModInfo<NPCData>(mod);
			if (npc.HasBuff(Buffs.TikiInfestation._ref.Type) >= 0)
			{
				Vector2 pos = npc.Center;
				for (int i = data.TikiStacks - 1; i >= 0; i--)
				{
					TikiData source = data.TikiSources[i];
					//Spawn Tiki Spirits
					float vY = Main.rand.Next(-16, 17) * 0.125f;
					float vX = Main.rand.Next(-16, 17) * 0.125f;
					vX += vX > 0 ? Math.Abs(vY) : -Math.Abs(vY);
					Projectile.NewProjectile(pos.X, pos.Y, vX, vY, Projectiles.Arrow.TikiBiter._ref.projectile.type, source.wasSpirit ? source.damage : (int)(source.damage * 0.75f), 0f, source.owner, -1f);
				}
			}
			return true;
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
