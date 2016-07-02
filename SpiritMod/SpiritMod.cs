using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod
{
    class SpiritMod : Mod
    {
        public SpiritMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void UpdateMusic(ref int music)
        {
            if (Main.myPlayer != -1 && !Main.gameMenu)
            {
            }
            if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneSpirit && Main.player[Main.myPlayer].position.Y < Main.rockLayer)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/SpiritOverworld");
            }
            if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneSpirit && Main.player[Main.myPlayer].position.Y >= Main.rockLayer)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/SpiritUnderground");
            }
        }

		public override void PostSetupContent()
		{
			LoadReferences();
			Item ccoutfit = new Item();
			ccoutfit.SetDefaults(ItemType("CandyCopterOutfit"));
			Mounts.CandyCopter._outfit = ccoutfit.legSlot;
		}

		/// <summary>
		/// Scans all classes deriving from any Mod type
		/// for a field called _ref
		/// and populates it, if it exists.
		/// </summary>
		private void LoadReferences()
		{
			foreach (Type type in Code.GetTypes())
			{
				if (type.IsAbstract)
				{
					continue;
				}

				System.Reflection.FieldInfo field = type.GetField("_ref");
				if (field == null || !field.IsStatic)
				{
					continue;
				}

				if (type.IsSubclassOf(typeof(ModItem)))
				{
					if (field.FieldType == typeof(ModItem))
					{
						field.SetValue(null, GetItem(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModNPC)))
				{
					if (field.FieldType == typeof(ModNPC))
					{
						field.SetValue(null, GetNPC(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModProjectile)))
				{
					if (field.FieldType == typeof(ModProjectile))
					{
						field.SetValue(null, GetProjectile(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModDust)))
				{
					if (field.FieldType == typeof(ModDust))
					{
						field.SetValue(null, GetDust(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModTile)))
				{
					if (field.FieldType == typeof(ModTile))
					{
						field.SetValue(null, GetTile(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModWall)))
				{
					if (field.FieldType == typeof(ModWall))
					{
						field.SetValue(null, GetWall(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModBuff)))
				{
					if (field.FieldType == typeof(ModBuff))
					{
						field.SetValue(null, GetBuff(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModMountData)))
				{
					if (field.FieldType == typeof(ModMountData))
					{
						field.SetValue(null, GetMount(type.Name));
					}
				}
			}
		}

	}
}