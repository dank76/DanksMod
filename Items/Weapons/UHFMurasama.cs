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
using Terraria.ID;

namespace DanksMod.Items.Weapons
{
	public class UHFMurasama : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Catastrophe");
            Tooltip.SetDefault("stabby :)");
		}

		public override void SetDefaults()
		{
            item.height = 128;
            item.width = 56;
            item.damage = 15000;
            item.crit += 30;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 5;
            item.knockBack = 6.5f;
            item.autoReuse = false;
            item.value = Item.buyPrice(2, 50, 0, 0);
            item.rare = ItemRarityID.Red;
            item.shoot = ModContent.ProjectileType<UHFMurasamaSlash>();
            item.shootSpeed = 24f;
            item.Calamity().customRarity = CalamityRarity.ItemSpecific;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] <= 0 && CalamityWorld.downedSCal || player.name == "Tyler";
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}

