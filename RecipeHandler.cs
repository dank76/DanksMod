﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Materials;
using DanksMod.Items.Placeables;
using static Terraria.ModLoader.ModContent;
using CalamityMod.Tiles.Furniture.CraftingStations;

namespace DanksMod
{
    public static class RecipeHandler
    {
        public static void AddRecipes()
        {
            #region Ores/Bars
            ModRecipe recipe = new ModRecipe(GetInstance<DanksMod>());
            recipe.AddIngredient(ItemType<CosmicOre>(), 5); //adds Cosmic ore as a ingredient
            recipe.AddTile(TileType<DraedonsForge>()); //sets crafting station to draedons forge
            recipe.SetResult(ItemType<CosmiliteBar>(), 1); //sets result
            recipe.AddRecipe();
            #endregion
        }
    }
}
 