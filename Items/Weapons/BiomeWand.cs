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
            DisplayName.SetDefault("Biome Wand");
            Tooltip.SetDefault("Casts a Biome Sword to follow cursor \nChanges depending on the biome");
		}

		public override void SetDefaults()
		{
            item.damage = 100;
            item.knockBack = 5f;
            item.useTime = (item.useAnimation = 10);
            item.mana = 10;
            item.summon = true;
            item.channel = true;
            item.autoReuse = true;
            item.shootSpeed = 7f;
            item.shoot = ModContent.ProjectileType<BiomeWandProj>();
            item.width = (item.height = 58);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.UseSound = SoundID.Item20;
            item.value = Item.buyPrice(0, 1);
            item.rare = ItemRarityID.LightRed;
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
				if (proj.active && proj.owner == player.whoAmI && proj.type == item.shoot && proj.ai[0] <= 0f)
				{
					projCount++;
				}
			}
			return projCount <= 0;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.LunarBar, 5);
			modRecipe.AddIngredient(ModContent.ItemType<GalacticaSingularity>(), 5);
			modRecipe.AddIngredient(ModContent.ItemType<UnholyEssence>(), 10);
			modRecipe.AddTile(TileID.LunarCraftingStation);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
