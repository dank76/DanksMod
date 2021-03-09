using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace DanksMod.Item.Weapons
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
			item.useStyle = 1;
			item.shoot = ProjectileType<BloodBeam>();
			item.damage = 300;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < Main.rand.Next(5, 9); i++)
			{
				Vector2 velocity = new Vector2(speedX, speedY) * Utils.NextFloat(Main.rand, 0.9f, 1.1f);
				float angle = Utils.NextFloat(Main.rand, -1f, 1f) * MathHelper.ToRadians(30f);
				Projectile.NewProjectile(position, Utils.RotatedBy(velocity, angle, default(Vector2)), type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
		public class BloodBeam : ModProjectile
		{
			public override string Texture
			{
				get
				{
					return "CalamityMod/Projectiles/InvisibleProj";
				}
			}

			public override void SetStaticDefaults()
			{
				base.DisplayName.SetDefault("Beam");
			}

			public override void SetDefaults()
			{
				base.projectile.width = 4;
				base.projectile.height = 4;
				base.projectile.extraUpdates = 100;
				base.projectile.friendly = true;
				base.projectile.timeLeft = 90;
				base.projectile.magic = true;
			}

			public override void AI()
			{
				Vector2 vector33 = base.projectile.position;
				vector33 -= base.projectile.velocity * 0.25f;
				int num448 = Dust.NewDust(vector33, 1, 1, 235, 0f, 0f, 0, default(Color), 1.25f);
				Main.dust[num448].position = vector33;
				Main.dust[num448].scale = (float)Main.rand.Next(70, 110) * 0.013f;
				Main.dust[num448].velocity *= 0.1f;
			}
		}
	}
}
