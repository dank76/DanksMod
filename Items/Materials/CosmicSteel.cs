using System;
using Terraria;
using Terraria.ModLoader;
using DanksMod.Items.Placeables;
using static Terraria.ModLoader.ModContent;

namespace DanksMod.Items.Materials
{

public class CosmicSteel : ModItem
{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Steel");
            Tooltip.SetDefault("When the steel is cosmic😳");
        }
		public override void SetDefaults()
		{
			base.item.width = 30;
			base.item.height = 24;
			base.item.maxStack = 999;
			base.item.value = Item.buyPrice(0, 3, 0, 0);
			base.item.rare = 5;
			base.item.useStyle = 1;
			base.item.useTurn = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.autoReuse = true;
		}
        public override void AddRecipes()
        {
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemType<CosmicOre>(), 10);
			modRecipe.AddTile(TileType<CalamityMod.Tiles.Furniture.CraftingStations.DraedonsForge>());
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
        }
    }
}