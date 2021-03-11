using DanksMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace DanksMod.Items.Weapons.RiftWeapons
{
    public class RiftStaff : RiftDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rift Staff");
            Tooltip.SetDefault("Fires rifts at the cursor \n[c/000000:fire the void]");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 1000;
            item.rare = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.shoot = ProjectileType<Rift>();
            item.shootSpeed = 12f;
            item.useTime = 10;
            item.useAnimation = 10;
            item.height = 84;
            item.width = 80;
            item.autoReuse = true;
        }
    }
}