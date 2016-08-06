using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Summon
{
    public class ProbeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Probe Minion Buff";
            Main.buffTip[Type] = "A Probe will fight for you!";
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("Probe")] > 0)
            {
                modPlayer.ProbeMinion = true;
            }
            if (!modPlayer.ProbeMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}