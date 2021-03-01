using System;
using CalamityMod.Projectiles.Melee;
using CalamityMod.World;
using CalamityMod.CalPlayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using CalamityMod;
using DanksMod.Projectiles;

namespace DanksMod.Items.Weapons
{
	public class UHFMurasama : ModItem
	{
		public override void SetStaticDefaults()
		{
				base.DisplayName.SetDefault("Catastrophe");
				base.Tooltip.SetDefault("I said my sword was a tool of justice. Not used in anger. Not used for vengeance. \nBut now... Now I'm not so sure. And besides, this isn't my sword.");
		}

		public override void SetDefaults()
		{
				base.item.height = 128;
				base.item.width = 56;
				base.item.damage = 15000;
				base.item.crit += 30;
				base.item.melee = true;
				base.item.noMelee = true;
				base.item.noUseGraphic = true;
				base.item.channel = true;
				base.item.useAnimation = 25;
				base.item.useStyle = 5;
				base.item.useTime = 5;
				base.item.knockBack = 6.5f;
				base.item.autoReuse = false;
				base.item.value = global::Terraria.Item.buyPrice(2, 50, 0, 0);
				base.item.rare = 10;
				base.item.shoot = ModContent.ProjectileType<UHFMurasamaSlash>();
				base.item.shootSpeed = 24f;
				base.item.Calamity().customRarity = global::CalamityMod.CalamityRarity.ItemSpecific;
		}

		public override bool CanUseItem(global::Terraria.Player player)
		{
			return player.ownedProjectileCounts[base.item.shoot] <= 0 && CalamityWorld.downedSCal || player.name == "Tyler";
		}

		public override bool Shoot(global::Terraria.Player player, ref global::Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			global::Terraria.Projectile.NewProjectile(position, new global::Microsoft.Xna.Framework.Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}

