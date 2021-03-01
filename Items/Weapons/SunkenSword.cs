using DanksMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DanksMod.Items.Weapons
{
	public class SunkenSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Sunken Slash");
			base.Tooltip.SetDefault("slash");
		}

		public override void SetDefaults()
		{
			base.item.width = 72;
			base.item.damage = 60;
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
			base.item.height = 78;
			base.item.value = Item.buyPrice(0, 50);
			base.item.rare = 10;
			base.item.shoot = ModContent.ProjectileType<SunkenSlash>();
			base.item.shootSpeed = 24f;

		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}

        public override void AddRecipes()
		{
			Mod CalamityMod = ModLoader.GetMod("CalamityMod");
			ModRecipe recipe = new ModRecipe(mod);
			if (CalamityMod != null)
			recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Placeables.SeaPrism>(), 10);
			recipe.AddIngredient(ModContent.ItemType<CalamityMod.Items.Placeables.PrismShard>(), 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
