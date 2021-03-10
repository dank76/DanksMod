using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using DanksMod.Projectiles;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace DanksMod.Items.Weapons.Magic
{
	public class BloodstoneEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodstone Eye");
			Tooltip.SetDefault("Fire Bloodstone energy");
		}
		public override void SetDefaults()
		{
			item.magic = true;
			item.useTime = item.useAnimation = 15;
			item.height = 50;
			item.width = 70;
			item.mana = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.shoot = ProjectileType<BloodBeam>();
			item.shootSpeed = 12f;
			item.damage = 300;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < Main.rand.Next(5, 9); i++)
			{
				Vector2 velocity = new Vector2(speedX, speedY) * Utils.NextFloat(Main.rand, 0.9f, 1.1f);
				float angle = Utils.NextFloat(Main.rand, -1f, 1f) * MathHelper.ToRadians(10f);
				Projectile.NewProjectile(position, Utils.RotatedBy(velocity, angle, default(Vector2)), type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-15f, 0f));
		}
	}
}