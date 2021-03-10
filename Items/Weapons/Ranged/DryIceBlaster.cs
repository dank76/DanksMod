using DanksMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.World;
using System;

namespace DanksMod.Items.Weapons.Ranged
{
    public class DryIceBlaster : ModItem
	{
		public const int CooldownTime = 420;
		
		public const double AltFireDamageMult = 4.27;
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Dry Ice Blaster");
            Tooltip.SetDefault("Uses frozen gel as ammon \n50% chance to not consume  frozen gel\nFires a spread of dry ice dust \nRight click fires clouds of dust");
		}

		public override void SetDefaults()
		{
            item.damage = 56;
            item.ranged = true;
            item.width = 64;
            item.height = 34;
            item.useTime = 7;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3.5f;
            item.UseSound = SoundID.Item34;
            item.value = Item.buyPrice(1, 20);
            item.rare = ItemRarityID.Red;
            item.autoReuse = true;
            item.useAmmo = ModContent.ItemType<IceGel>();
			item.shootSpeed = 10f;
            item.Calamity().customRarity = CalamityRarity.Turquoise;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10f, 0f);
		}


		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
                item.shoot = ModContent.ProjectileType<DryIceCloud>();
                item.useTime = (item.useAnimation = 90);
				item.shootSpeed = 2f;
			}
			else
			{
                item.shoot = ModContent.ProjectileType<DryIceFire>();
				item.shootSpeed = 10f;
				item.useTime = 7;
				item.useAnimation = 14;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Vector2 velocity3 = new Vector2(speedX, speedY);
				position += velocity3.ToRotation().ToRotationVector2() * 80f;
				Projectile.NewProjectile(position, velocity3.SafeNormalize(Vector2.Zero) * 1f, ModContent.ProjectileType<DryIceCloud>(), (int)((double)damage * 2), knockBack, player.whoAmI);
			}
			else
			{
				for (int j = 0; j < 2; j++)
				{
					Vector2 velocity = new Vector2(speedX, speedY).RotatedByRandom(0);
					Projectile.NewProjectile(position, velocity, type, damage, knockBack, player.whoAmI);
				}
				if (Main.rand.NextBool(8))
				{
					for (int i = 0; i < 2; i++)
					{
						Vector2 velocity2 = new Vector2(speedX, speedY) * 0.02f;
						position += velocity2.ToRotation().ToRotationVector2() * 64f;
						int yDirection = (i == 0).ToDirectionInt();
						velocity2 = velocity2.RotatedBy(0.2f * (float)yDirection);
						Projectile projectile = Projectile.NewProjectileDirect(position, velocity2, ModContent.ProjectileType<DryIceFire>(), damage, knockBack, player.whoAmI);
						projectile.localAI[1] = yDirection;
						projectile.netUpdate = true;
					}
				}
			}
			return false;
		}

		public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(0, 100) < 0)
			{
				return false;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.EnchantedMetal>(), 5);
			modRecipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.CryoBar>(), 10);
			modRecipe.AddIngredient(ModContent.ItemType<IceGel>(), 10);
			modRecipe.AddIngredient(ItemID.LunarBar, 5);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
