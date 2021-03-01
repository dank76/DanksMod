using DanksMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod.Items.Materials;
using System;
using System.Collections.Generic;

namespace DanksMod.Items.Weapons
{
	public class BiomeWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Biome Wand");
			base.Tooltip.SetDefault("Casts a Biome Sword to follow cursor \nChanges depending on the biome");
		}

		public override void SetDefaults()
		{
			base.item.damage = 100;
			base.item.knockBack = 5f;
			base.item.useTime = (base.item.useAnimation = 10);
			base.item.mana = 10;
			base.item.summon = true;
			base.item.channel = true;
			base.item.autoReuse = true;
			base.item.shootSpeed = 7f;
			base.item.shoot = ModContent.ProjectileType<BiomeWandProj>();
			base.item.width = (base.item.height = 58);
			base.item.useStyle = 1;
			base.item.noMelee = true;
			base.item.UseSound = SoundID.Item20;
			base.item.value = Item.buyPrice(0, 1);
			base.item.rare = 4;
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Weapons/BiomeWand_Glowmask");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}

		public override bool CanUseItem(Player player)
		{
			int projCount = 0;
			for (int x = 0; x < 1000; x++)
			{
				Projectile proj = Main.projectile[x];
				if (proj.active && proj.owner == player.whoAmI && proj.type == base.item.shoot && proj.ai[0] <= 0f)
				{
					projCount++;
				}
			}
			return projCount <= 0;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(ItemID.LunarBar, 5);
			modRecipe.AddIngredient(ModContent.ItemType<GalacticaSingularity>(), 5);
			modRecipe.AddIngredient(ModContent.ItemType<UnholyEssence>(), 10);
			modRecipe.AddTile(TileID.LunarCraftingStation);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
