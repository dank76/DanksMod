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
            Tooltip.SetDefault("When the steel is cosmic");
        }
		public override void SetDefaults()
		{
            item.width = 30;
            item.height = 24;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.rare = 5;
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
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