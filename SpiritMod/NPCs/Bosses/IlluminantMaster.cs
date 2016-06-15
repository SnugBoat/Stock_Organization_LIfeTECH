using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Bosses
{
    public class IlluminantMaster : ModNPC
    {
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
			int Xdis = Main.player[Main.myPlayer].Center.X - npc.Center.X;  // change myplayer to nearest player in full version
			int Ydis = Main.player[Main.myPlayer].Center.Y - npc.Center.Y; // change myplayer to nearest player in full version
			float Hypotanuse = (float)Math.Sqrt((Xdis * Xdis) + (Ydis * Ydis));
			float TrijectoryX = (float)Math.Acos(Xdis / Hypotanuse) * 3;
			float TrijectoryY = (float)Math.Asin(Ydis / Hypotanuse) * 3;
			npc.ai[0]++;
			if(npc.ai[0] % 250 >= 75) // X
			{
				npc.speedX = TrijectoryX * (175 / npc.ai[0] % 200);
				npc.speedY = TrijectoryY * (175 / npc.ai[0] % 200);
			}
			if(npc.ai[0] % 250 == 0) // Y
			{
				npc.position.X = (Main.player[Main.myPlayer].position.X - 250) + Main.rand.Next(500);
				npc.position.Y = (Main.player[Main.myPlayer].position.Y - 250) + Main.rand.Next(500);
			}
			if(npc.ai[0] % 250 <= 75) // Z
			{
				npc.speedX = TrijectoryX / 20;
				npc.speedY = TrijectoryX / 20;
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