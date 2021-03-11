using CalamityMod;
using DanksMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace DanksMod.Items.Weapons.RiftWeapons
{
    public class StaffOfVoid : RiftDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff Of Void");
            Tooltip.SetDefault("Fires Void Tentacles");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 200;
            item.rare = ItemRarityID.Red;
            item.Calamity().customRarity = CalamityRarity.Developer;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.shoot = ProjectileType<VoidTentacle>();
            item.shootSpeed = 12f;
            item.useTime = 20;
            item.useAnimation = 20;
            item.height = 72;
            item.width = 86;
            item.autoReuse = true;
        }
    }
}