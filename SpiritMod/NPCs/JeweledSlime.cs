using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class JeweledSlime : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Jeweled Slime";
            npc.displayName = "Jeweled Slime";
            npc.width = 16;
            npc.height = 12;
            npc.damage = 40;
            npc.defense = 12;
            npc.lifeMax = 180;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .25f;
            npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
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