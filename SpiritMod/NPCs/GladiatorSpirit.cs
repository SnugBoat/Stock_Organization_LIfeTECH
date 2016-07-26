using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs
{
    public class GladiatorSpirit : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Gladiator Spirit";
            npc.displayName = "Gladiator Spirit";
            npc.width = 32;
            npc.height = 56;
            npc.damage = 51;
            npc.defense = 20;
            npc.lifeMax = 280;
            npc.soundHit = 4;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.knockBackResist = .60f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.aiStyle = 22;
            aiType = NPCID.Wraith;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.IceElemental];
            aiType = NPCID.Wraith;
            animationType = NPCID.Wraith;
            npc.stepSpeed = .5f;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
            return  (tile == 367) && Main.hardMode && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient Rune"), 3 + Main.rand.Next(3));
		}

	}
}
