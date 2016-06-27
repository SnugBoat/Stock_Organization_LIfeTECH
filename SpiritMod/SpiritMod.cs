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
        public override void ChatInput(string text)
        {
            if (text == "/help")
            {
                Help();
            }
            else if (text == "/Spirit")
            {
                Spirit();
            }
        }
        private void Spirit()
        {
            NPC.downedMechBoss3 = true;
            MyWorld.spiritBiome = false;
        }

        private void Help()
        {
            Main.NewText("/BiomeReset to spawn / respawn the Spirit Biome");
            Main.NewText("");
        }
    }
}
