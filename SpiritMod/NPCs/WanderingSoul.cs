using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs
{
    public class WanderingSoul : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Wandering Soul";
            npc.displayName = "Wandering Soul";
            npc.width = 26;
            npc.height = 46;
            npc.damage = 37;
            npc.defense = 40;
            npc.lifeMax = 540;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .60f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.aiStyle = 22;
            aiType = NPCID.Wraith;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Wraith];
            aiType = NPCID.Wraith;
            animationType = NPCID.Wraith;
            npc.stepSpeed = .5f;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer ? 0.5f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_13"), 1f);
                for (int k = 0; k < 2; k++) ;
            }
        }
    }
}