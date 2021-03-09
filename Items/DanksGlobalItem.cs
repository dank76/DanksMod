using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DanksMod.Items.Placeables;
using static Terraria.ModLoader.ModContent;

namespace DanksMod.Items
{
    public class DanksGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.NightsEdge)
			{
				item.shoot = ProjectileID.DemonScythe;
				item.shootSpeed = 2f;
				item.useTime = 25;
			}
			if (item.type == ItemID.InfernoFork)
			{
				item.autoReuse = true;
			}
		}
		public void DeleteRecipes(int item)
		{
			RecipeFinder val = new RecipeFinder();
			val.SetResult(item);
			foreach (Recipe item2 in val.SearchRecipes()) new RecipeEditor(item2).DeleteRecipe();
		}
		public override void AddRecipes()
		{
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			DeleteRecipes(ItemType<CosmiliteBar>());
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<CosmicOre>(), 10);
			recipe.AddTile(TileType<DraedonsForge>());
			recipe.SetResult(ItemType<CosmiliteBar>(), 1);
			recipe.AddRecipe();
		}
	}
}