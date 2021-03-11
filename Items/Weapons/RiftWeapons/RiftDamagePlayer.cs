using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DanksMod.Items.Weapons.RiftWeapons
{

	public class RiftDamagePlayer : ModPlayer
	{
		public static RiftDamagePlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<RiftDamagePlayer>();
		}

		public float riftDamageAdd;
		public float riftDamageMult = 1f;
		public float riftKnockback;
		public int riftCrit;


		public int riftResourceCurrent;
		public const int DefaultRiftResourceMax = 200;
		public int riftResourceMax;
		public int riftResourceMax2;
		public float riftResourceRegenRate;
		internal int riftResourceRegenTimer = 0;
		public static readonly Color HealRiftResource = new Color(0, 0, 0);

		public override void Initialize()
		{
			riftResourceMax = DefaultRiftResourceMax;
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
			riftDamageAdd = 0f;
			riftDamageMult = 1f;
			riftKnockback = 0f;
			riftCrit = 0;
			riftResourceRegenRate = 1f;
			riftResourceMax2 = riftResourceMax;
		}

		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}

		private void UpdateResource()
		{
			riftResourceRegenTimer++; //Increase it by 60 per second, or 1 per tick.

			if (riftResourceRegenTimer > 180 * riftResourceRegenRate)
			{
				riftResourceCurrent += 1;
				riftResourceRegenTimer = 0;
			}

			riftResourceCurrent = Utils.Clamp(riftResourceCurrent, 0, riftResourceMax2);
		}
	}
}