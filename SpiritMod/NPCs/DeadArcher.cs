using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class DeadArcher : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Deadeye Marksman";
            npc.displayName = "Deadeye Marksman";
            npc.width = 44;
            npc.height = 52;
            npc.damage = 22;
            npc.defense = 13;
            npc.lifeMax = 80;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CultistArcherBlue];
            aiType = NPCID.CultistArcherBlue;
            animationType = NPCID.CultistArcherBlue;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneCorrupt && spawnInfo.spawnTileY < Main.rockLayer ? 0.5f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(mod.BuffType("BCorrupt"), 180);
            }
        }
    }
}
