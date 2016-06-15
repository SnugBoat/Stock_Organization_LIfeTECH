using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Bosses
{
    public class IlluminantMaster : ModNPC
    {
		private float XSpeed;
		private float YSpeed;
        public override void SetDefaults()
        {
            npc.name = "Illuminant Master";
            npc.displayName = "Illuminant Master";
            npc.width = 130;
            npc.height = 154;
            npc.damage = 32;
            npc.defense = 34;
            npc.lifeMax = 22000;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = 20f;
            Main.npcFrameCount[npc.type] = 7;
     
        }
		public override void AI()
        {
		if (npc.life < 11000)
		{ 
			float Xdis = Main.player[Main.myPlayer].Center.X - npc.Center.X;  // change myplayer to nearest player in full version
            float Ydis = Main.player[Main.myPlayer].Center.Y - npc.Center.Y; // change myplayer to nearest player in full version
            float Angle = (float)Math.Atan(Xdis / Ydis);
            float TrijectoryX = (float)(Math.Sin(Angle));
            float TrijectoryY = (float)(Math.Cos(Angle));
            npc.ai[0]++;
           if(npc.ai[0] % 250 <= 75) // X
            {
                XSpeed = TrijectoryX;
                YSpeed = TrijectoryY;
            }
            if(npc.ai[0] % 250 > 75) // X
            {
                npc.velocity.X = XSpeed;
                npc.velocity.Y = YSpeed;
            }
            if(npc.ai[0] % 250 == 0) // Y
            {
                npc.position.X = (Main.player[Main.myPlayer].position.X - 125) + Main.rand.Next(250);
                npc.position.Y = (Main.player[Main.myPlayer].position.Y - 125) + Main.rand.Next(250);
            }
            if(npc.ai[0] % 250 < 75) // Z
            {
                npc.velocity.X = 0;
                npc.velocity.Y = 0;
            }
            if (npc.ai[0]%8==0)
            {
                npc.frame.Y = (int)(npc.height * npc.frameCounter);
                npc.frameCounter = (npc.frameCounter+1) % 5;
            }
		}
		if (npc.life >= 11000)
		{
			//first phase stuff.
		}
		}
    }
}