using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DanksMod.Items.Weapons.RiftWeapons
{

	public class RiftDamagePlayer : ModPlayer
	{
		public float riftDamage = 1f;

		public float riftKnockback;

		public int riftCrit;

		public static RiftDamagePlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<RiftDamagePlayer>();
		}

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
			riftDamage = 1f;
			riftKnockback = 0f;
			riftCrit = 0;
		}
	}
}