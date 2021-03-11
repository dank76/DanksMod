using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace DanksMod.Items.Weapons.RiftWeapons
{
	public abstract class RiftDamageItem : ModItem
	{
		public override bool CloneNewInstances => true;

		public virtual void SafeSetDefaults()
		{
		}

		public virtual void SecondarySetDefaults()
		{
		}

		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			SecondarySetDefaults();
			item.melee = false;
			item.magic = false;
			item.thrown = false;
			item.summon = false;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			mult *= RiftDamagePlayer.ModPlayer(player).riftDamage;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			knockback += RiftDamagePlayer.ModPlayer(player).riftKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			crit += RiftDamagePlayer.ModPlayer(player).riftCrit;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				string[] source = tt.text.Split(' ');
				string damageValue = source.First();
				string damageWord = source.Last();
				tt.text = damageValue + " rift " + damageWord;
			}
			int tooltipLocation = tooltips.FindIndex((TooltipLine TooltipLine) => TooltipLine.Name.Equals("ItemName"));
			{
				tooltips.Insert(tooltipLocation + 1, new TooltipLine(((ModItem)this).mod, "IsDruid", "[c/000000:-Rift Damage-]"));
			}
		}
	}
}