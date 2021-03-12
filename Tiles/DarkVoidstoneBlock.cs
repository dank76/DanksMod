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
    public class DarkVoidstoneBlock : ModTile
    {
		public override void SetDefaults()
		{
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Abyssal Voidstone");
			AddMapEntry(new Color(10, 4, 32), name);

			dustType = 84;
			drop = ModContent.ItemType<Items.Placeables.DarkVoidstone>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 16f;
		}
	}
}