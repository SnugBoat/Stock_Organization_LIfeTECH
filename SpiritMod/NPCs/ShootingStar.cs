using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class ShootingStar : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Shooting Star";
            npc.displayName = "Shooting Star";
            npc.width = 24;
            npc.height = 30;
            npc.damage = 50;
            npc.defense = 20;
            npc.lifeMax = 400;
            npc.soundHit = 1;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 56;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.ChaosBall];
            aiType = NPCID.ChaosBall;
            animationType = NPCID.ChaosBall;
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