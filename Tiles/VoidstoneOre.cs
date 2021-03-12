using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using CalamityMod.Sounds.Item;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Audio;

namespace DanksMod.Tiles
{
	public class VoidstoneOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 500;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Voidstone ore");
			AddMapEntry(new Color(3, 4, 43), name);

			dustType = 84;
			drop = ModContent.ItemType<Items.Placeables.VoidstoneOreItem>();
			soundType = SoundID.MoonLord;
			soundStyle = 1;
			mineResist = 16f;
		}
	}
}