﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalamityMod;
using CalamityMod.CalPlayer;
using DanksMod.Tiles;

namespace DanksMod.Items.Placeables
{
    public class CosmicOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmolite Ore");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.createTile = ModContent.TileType<CosmicRock>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.maxStack = 999;
            item.rare = 10;
            item.Calamity().customRarity = CalamityRarity.DarkBlue;
        }
    }
}
