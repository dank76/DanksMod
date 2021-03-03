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
            DisplayName.SetDefault("Sunken Slash");
            Tooltip.SetDefault("slash");
		}

		public override void SetDefaults()
		{
            item.width = 72;
            item.damage = 60;
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
            item.height = 78;
            item.value = Item.buyPrice(0, 50);
            item.rare = ItemRarityID.Red;
            item.shoot = ModContent.ProjectileType<SunkenSlash>();
            item.shootSpeed = 24f;

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
