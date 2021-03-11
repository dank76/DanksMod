using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace DanksMod.Items.Weapons.RiftWeapons
{
	// This class handles everything for our custom damage class
	// Any class that we wish to be using our custom damage class will derive from this class, instead of ModItem
	public abstract class RiftDamageItem : ModItem
	{
		public override bool CloneNewInstances => true;
		public int riftResourceCost = 0;

		public virtual void SafeSetDefaults()
		{
		}

		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.thrown = false;
			item.summon = false;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			add += RiftDamagePlayer.ModPlayer(player).riftDamageAdd;
			mult *= RiftDamagePlayer.ModPlayer(player).riftDamageMult;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			// Adds knockback bonuses
			knockback += RiftDamagePlayer.ModPlayer(player).riftKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			// Adds crit bonuses
			crit += RiftDamagePlayer.ModPlayer(player).riftCrit;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				// Change the tooltip text
				tt.text = damageValue + " rift " + damageWord;
			}

			if (riftResourceCost > 0)
			{
				tooltips.Add(new TooltipLine(mod, "Rift Cost", $"Uses {riftResourceCost} rift resource"));
			}
		}

		// Make sure you can't use the item if you don't have enough resource and then use 10 resource otherwise.
		public override bool CanUseItem(Player player)
		{
			var riftDamagePlayer = player.GetModPlayer<RiftDamagePlayer>();

			if (riftDamagePlayer.riftResourceCurrent >= riftResourceCost)
			{
				riftDamagePlayer.riftResourceCurrent -= riftResourceCost;
				return true;
			}
			return false;
		}
	}
}
