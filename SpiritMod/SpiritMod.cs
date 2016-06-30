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
		}

		private void LoadReferences()
		{
			Mounts.CandyCopter._ref = GetMount("CandyCopter");
			Item ccoutfit = new Item();
			ccoutfit.SetDefaults(ItemType("CandyCopterOutfit"));
			Mounts.CandyCopter._outfit = ccoutfit.legSlot;

			//Buffs.Diseased._ref = GetBuff("Diseased");
			//Items.Bismite.BismiteBodyguard._ref = GetItem("BismiteBodyguard");
			//Items.Bismite.BismiteGreaves._ref = GetItem("BismiteGreaves");
			//Items.Bismite.BismiteHelm._ref = GetItem("BismiteHelm");
			//Items.Bismite.BismiteKnife._ref = GetItem("BismiteKnife");
			//Items.Bismite.WrathShard._ref = GetItem("WrathShard");
		}

	}
}