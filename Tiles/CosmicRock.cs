using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using CalamityMod.Sounds.Custom;
using Microsoft.Xna.Framework;
using DanksMod;

namespace DanksMod.Tiles
{
    public class CosmicRock : ModTile
    {
        public override void SetDefaults()
        {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cosmic Ore");
			AddMapEntry(new Color(139, 38, 150), name);

			dustType = 84;
			drop = ModContent.ItemType<Items.Placeables.CosmicOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 12f;
			minPick = 200;
		}
	}
}