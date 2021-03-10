using CalamityMod.World;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.DraedonMisc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using CalamityMod;
using DanksMod.Projectiles;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using CalamityMod.Tiles.Furniture.CraftingStations;

namespace DanksMod.Items.Weapons
{
    public class UHFMurasama : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Catastrophe");
            Tooltip.SetDefault("stabby :)");
		}

		public override void SetDefaults()
		{
            item.height = 128;
            item.width = 56;
            item.damage = 15000;
            item.crit += 30;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 5;
            item.rare = 10;
            item.knockBack = 6.5f;
            item.autoReuse = false;
            item.value = Item.buyPrice(2, 50, 0, 0);
            item.shoot = ProjectileType<UHFMurasamaSlash>();
            item.shootSpeed = 24f;
            item.Calamity().customRarity = CalamityRarity.Developer;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 14));
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frameI, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = GetTexture(this.Texture);
            spriteBatch.Draw(texture, position, new Microsoft.Xna.Framework.Rectangle?(item.GetCurrentFrame(ref this.frame, ref this.frameCounter, (this.frame == 0) ? 36 : ((this.frame == 8) ? 24 : 6), 13, true)), Color.White, 0f, origin, scale, 0, 0f);
            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = GetTexture(this.Texture);
            spriteBatch.Draw(texture, item.position - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(item.GetCurrentFrame(ref this.frame, ref this.frameCounter, (this.frame == 0) ? 36 : ((this.frame == 8) ? 24 : 6), 13, true)), lightColor, 0f, Vector2.Zero, 1f, 0, 0f);
            return false;
        }

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] <= 0 && CalamityWorld.downedSCal || player.name == "Tyler";
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(ItemType<MysteriousCircuitry>(), 5);
            modRecipe.AddIngredient(ItemType<DubiousPlating>(), 5);
            modRecipe.AddIngredient(ItemType<EncryptedSchematic>(), 1);
            modRecipe.AddIngredient(ItemType<Murasama>(), 1);
            modRecipe.AddIngredient(ItemType<ShadowspecBar>(), 10);
            modRecipe.AddIngredient(ItemID.Amethyst, 5);
            modRecipe.AddTile(TileType<DraedonsForge>());
            modRecipe.SetResult(this, 1);
        }
        public int frameCounter;

        public int frame;
    }
}

