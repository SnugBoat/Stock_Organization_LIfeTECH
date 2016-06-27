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
    }
}