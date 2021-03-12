using Terraria.ModLoader;
using Terraria;
using DanksMod.NPCs;

namespace DanksMod.Buffs.DoTDebuffs
{
    public class BurningVoid : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Burning Void");
			Description.SetDefault("The Void burns You");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
        public override void Update(Player player, ref int buffIndex)
        {
			player.GetModPlayer<DanksPlayer>().burningVoid = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<DanksGlobalNPC>().burningVoid = true;
        }
    }
}
