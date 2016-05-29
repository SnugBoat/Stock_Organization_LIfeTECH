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
        private const int saveVersion = 0;
        public bool minionName = false;
        public static bool hasProjectile;

        public override void ResetEffects()
        {
            minionName = false;
        }

        public override void PostUpdateEquips()
        {

        }
    }
}