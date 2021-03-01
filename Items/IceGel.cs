using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DanksMod.Items
{
    public class IceGel : ModItem
    {
        public override string Texture => "CalamityMod/Items/Materials/PurifiedGel";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Gel");
            Tooltip.SetDefault("Frozen Gel used for The Dry Ice Blaster");
        }
        public override void SetDefaults()
        {
            item.height = item.width = 32;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 10;
            item.ammo = item.type;
            item.maxStack = 9999;
            item.consumable = true;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(ItemID.IceBlock, 1);
            modRecipe.AddIngredient(ItemID.Gel, 20);
            modRecipe.AddTile(TileID.IceMachine);
            modRecipe.SetResult(this, 20);
            modRecipe.AddRecipe();
        }
    }
}
