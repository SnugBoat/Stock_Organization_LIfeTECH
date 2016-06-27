using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod
{
    public class MyPlayer : ModPlayer
    {
        private bool loaded = false;
        private const int saveVersion = 0;
        public bool minionName = false;
        public static bool hasProjectile;

        public bool ZoneSpirit = false;


        public override void UpdateBiomes()
        {
            ZoneSpirit = (MyWorld.SpiritTiles > 500);
        }

        public override void ResetEffects()
        {
            minionName = false;
        }

        public override void PostUpdateEquips()
        {

        }


        public override void PreUpdate()
        {
            if (!loaded)
            {
                Main.NewText("Thanks for using the Spirit Mod", 0, 191, 255);
                Main.NewText("Mod Website: ", 0, 191, 255);
                Main.NewText("http://forums.terraria.org/index.php?threads/the-spirit-mod.41395/", 0, 191, 255);
                loaded = true;
            }
        }
    }
}
