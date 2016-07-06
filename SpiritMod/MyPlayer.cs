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
		public Entity LastEnemyHit = null;
public bool hpRegenRing = false;
public bool TiteRing = false;
        private bool loaded = false;
        private const int saveVersion = 0;
        public bool minionName = false;
        public static bool hasProjectile;
        public bool DoomDestiny = false;
        public int HitNumber;
public bool SRingOn = true;
        public bool ZoneSpirit = false;
		
        public override void UpdateBiomes()
        {
            ZoneSpirit = (MyWorld.SpiritTiles > 500);
        }

        public override void ResetEffects()
        {
            minionName = false;
			hpRegenRing = false;
			TiteRing = false;
			SRingOn = true;
        }

		public override void OnHitAnything(float x, float y, Entity victim)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (modPlayer.TiteRing && modPlayer.LastEnemyHit == victim && Main.rand.Next(10) == 2)
            {
                player.AddBuff(59, 145);
            }
			if (modPlayer.hpRegenRing && modPlayer.LastEnemyHit == victim && Main.rand.Next(3) == 2)
            {
                player.AddBuff(58, 120);
            }
            LastEnemyHit = victim;
            base.OnHitAnything(x, y, victim);
        }

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (SRingOn == true)
			{
				for (int h = 0; h < 3; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 2f;
				int proj = Projectile.NewProjectile(Main.player[Main.myPlayer].Center.X, Main.player[Main.myPlayer].Center.Y, vel.X, vel.Y, 297, 45, 0, Main.myPlayer);
			}
			}
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
        
                public override void UpdateBadLifeRegen()
        {
            if (DoomDestiny)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 16;
            }
        }
        		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
{
    if (SRingOn == true)
    {
        int newProj = Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y, (2 * 3), 2 * 3, 356, 40, 0f, Main.myPlayer);
        
        int dist = 800;
        int target = -1;
        for(int i = 0; i < 200; ++i)
        {
            if(Main.npc[i].active && Main.npc[i].CanBeChasedBy(Main.projectile[newProj], false))
            {
                if( (Main.npc[i].Center - Main.projectile[newProj].Center).Length() < dist )
                {
                    target = i;
                    break;
                }
            }
        }
        
        Main.projectile[newProj].ai[0] = target;
    }
}
    }
}
