using Terraria;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.CalPlayer;
using DanksMod.Projectiles;
using Terraria.ID;

namespace DanksMod.Items.Weapons
{
    public class SurvivalKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Survival Knife");
            Tooltip.SetDefault("Throws a survial knife at foes.");
        }
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 26;
            item.Calamity().rogue = true;
            item.thrown = true;
            item.useTime = item.useAnimation = 8;
            item.damage = 132;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.crit += 10;
            item.rare = 10;
            item.shoot = ModContent.ProjectileType<SurvivalKnifeProj>();
            item.shootSpeed = 24f;
            item.autoReuse = true;
            item.noUseGraphic = true;
        }
    }
}
