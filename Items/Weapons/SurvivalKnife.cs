using Terraria;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.CalPlayer;
using DanksMod.Projectiles;

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
            item.damage = 100;
            item.crit += 10;
            item.shoot = ModContent.ProjectileType<SurvivalKnifeProj>();
            item.shootSpeed = 3f;
        }
    }
}
