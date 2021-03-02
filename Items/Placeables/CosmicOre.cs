using Terraria;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.CalPlayer;
using DanksMod.Tiles;

namespace DanksMod.Items.Placeables
{
    public class CosmicOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Ore");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.createTile = ModContent.TileType<CosmicRock>();
        }
    }
}
