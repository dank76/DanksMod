using DanksMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Items.Weapons
{
	public class PrismWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Prism Wand");
			base.Tooltip.SetDefault("Casts a Prism Shard to follow cursor");
		}

		public override void SetDefaults()
		{
			base.item.damage = 15;
			base.item.knockBack = 5f;
			base.item.useTime = (base.item.useAnimation = 30);
			base.item.mana = 10;
			base.item.summon = true;
			base.item.channel = true;
			base.item.autoReuse = true;
			base.item.shootSpeed = 7f;
			base.item.shoot = ModContent.ProjectileType<SeaShard>();
			base.item.width = (base.item.height = 58);
			base.item.useStyle = 1;
			base.item.noMelee = true;
			base.item.UseSound = SoundID.Item20;
			base.item.value = Item.buyPrice(0, 1);
			base.item.rare = 4;
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
			modRecipe.AddIngredient(ModContent.ItemType <CalamityMod.Items.Placeables.SeaPrism>(), 5);
			modRecipe.AddTile(TileID.Furnaces);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
