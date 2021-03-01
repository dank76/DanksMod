using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DanksMod.Projectiles.Minions;
using DanksMod.Buffs.Summons;

namespace DanksMod.Items.Weapons
{
	public class EutrophicRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eutrophic Rod");
			Tooltip.SetDefault("Summons a Sunken Ram");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; //for controllers
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 105;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;

			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<RamMinionBuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			item.shoot = ModContent.ProjectileType<SunkenRamMinion>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes()
		{
			Mod CalamityMod = ModLoader.GetMod("CalamityMod");
			ModRecipe recipe = new ModRecipe(mod);
			if (CalamityMod != null)
			{
				recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Placeables.PrismShard>(), 20);
				recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Placeables.SeaPrism>(), 5);
				//uses souls of might because i hate balancing against destroyer
				recipe.AddIngredient(ItemID.SoulofMight, 10);
				recipe.AddIngredient(ItemID.WaterBucket, 2);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}