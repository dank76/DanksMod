using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DanksMod.Items.Placeables;
using DanksMod.Items;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using DanksMod.Items.Weapons.RiftWeapons;
using DanksMod.Items.Weapons.Melee;
using CalamityMod;

namespace DanksMod.Items
{
	public class DanksGlobalItem : GlobalItem
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}
		public VoidRarity customRarity;

		public int postMoonLordRarity
		{
			get
			{
				return (int)this.customRarity;
			}
			set
			{
				this.customRarity = (VoidRarity)value;
			}
		}
		public override void SetDefaults(Terraria.Item item)
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
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			TooltipLine tt2 = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName" && x.mod == "Terraria");
			if (tt2 != null)
			{
				if (item.type == ModContent.ItemType<UHFMurasama>())
				{
					List<Color> colorSet = new List<Color>
					{
						new Color(12, 6, 28),
						new Color(182, 47, 245),
						new Color(154, 48, 219)
					};
					if (tt2 != null)
					{
						int colorIndex = (int)(Main.GlobalTime / 2f % (float)colorSet.Count);
						Color currentColor = colorSet[colorIndex];
						Color nextColor = colorSet[(colorIndex + 1) % colorSet.Count];
						tt2.overrideColor = new Color?(Color.Lerp(currentColor, nextColor, (Main.GlobalTime % 2f > 1f) ? 1f : (Main.GlobalTime % 1f)));
					}
					return;
				}

				VoidRarity voidRarity = this.customRarity;
				if (voidRarity != VoidRarity.ItemSpecific)
				{
					switch (voidRarity)
					{
						case VoidRarity.Void:
							tt2.overrideColor = new Color?(new Color(36, 14, 66));
							break;
						case VoidRarity.VoidHardmode:
							tt2.overrideColor = new Color?(new Color(28, 11, 51));
							break;
						case VoidRarity.VoidMoonlord:
							tt2.overrideColor = new Color?(new Color(12, 6, 28));
							break;
					}
				}
			}
		}
	}
}