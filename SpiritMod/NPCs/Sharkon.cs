using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Sharkon : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Sharkon";
            npc.displayName = "Sharkon";
            npc.width = 118;
            npc.height = 42;
            npc.damage = 70;
            npc.defense = 12;
            npc.lifeMax = 600;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .55f;
            npc.aiStyle = 16;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Shark];
            aiType = NPCID.Shark;
            animationType = NPCID.Shark;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer ? 0.5f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}