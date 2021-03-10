using DanksMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Items.Weapons.Summoner
{
	public class LeafWand : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Leaf Wand");
            Tooltip.SetDefault("Casts a leaf to follow cursor");
		} 

		public override void SetDefaults()
		{
            item.damage = 10;
            item.knockBack = 5f;
            item.useTime = (item.useAnimation = 30);
            item.mana = 10;
            item.summon = true;
            item.channel = true;
            item.autoReuse = true;
            item.shootSpeed = 7f;
            item.shoot = ModContent.ProjectileType<Leaf>();
            item.width = (item.height = 58);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.UseSound = SoundID.Item20;
            item.value = Item.buyPrice(0, 1);
            item.rare = ItemRarityID.LightRed;
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
			modRecipe.AddIngredient(ItemID.Wood, 15);
			modRecipe.AddTile(TileID.LivingLoom);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
