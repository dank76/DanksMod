using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DanksMod.Projectiles.Minions;

namespace DanksMod.Buffs.Summons
{
	public class RamMinionBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Ram Minion");
			Description.SetDefault("Sunken Ram");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ModContent.ProjectileType<SunkenRamMinion>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}