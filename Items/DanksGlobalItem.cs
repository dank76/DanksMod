using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using CalamityMod;
using CalamityMod.Items.Weapons.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using DanksMod.Items.Weapons;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Armor;

namespace DanksMod.Items
{
	public class DanksGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.NightsEdge)
			{
				item.shoot = ProjectileID.DemonScythe;
				item.shootSpeed = 2f;
				item.useTime = 25;
			}
			if (item.type == ItemID.InfernoFork)
			{
				item.autoReuse = true;
			}
		}
	}
}