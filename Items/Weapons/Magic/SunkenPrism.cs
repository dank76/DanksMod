using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using DanksMod.Projectiles;

namespace DanksMod.Items.Weapons.Magic
{
	public class SunkenPrism : ModItem
	{
		
		public override string Texture => "Terraria/Item_" + ItemID.LastPrism;
		public static Color OverrideColor = new Color(0, 0, 221);

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunken Prism");
			Tooltip.SetDefault("Fires a concetrated Sunken Beam.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LastPrism);
			item.mana = 4;
			item.damage = 30;
			item.shoot = ModContent.ProjectileType<SunkenPrismHoldout>();
			item.shootSpeed = 30f;

			item.color = OverrideColor;
		}

		public override void AddRecipes()
		{
			Mod CalamityMod = ModLoader.GetMod("CalamityMod");
			ModRecipe recipe = new ModRecipe(mod);
			if (CalamityMod != null)
			{
				recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Placeables.PrismShard>(), 30);
				recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Placeables.SeaPrism>(), 10);
				recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.MolluskHusk>(), 3);
				//uses souls of might because i hate balancing against destroyer, fuck destroyer
				recipe.AddIngredient(ItemID.SoulofMight, 10);
				recipe.AddIngredient(ItemID.Glass, 10);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}

		// Because this weapon fires a holdout projectile, it needs to block usage if its projectile already exists.
		public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<SunkenPrismHoldout>()] <= 0;
	}
}