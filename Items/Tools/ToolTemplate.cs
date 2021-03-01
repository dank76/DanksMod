using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Items.Tools
{
    public class ToolTemplate : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.CopperAxe; //sets the texture to copper axe
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hoe(Tool)");
            Tooltip.SetDefault("Farm");
        }
        public override void SetDefaults()
        {
            item.pick = 200; //pickaxe power of the item
            item.hammer = 200; // hammer power of the item
            item.width = item.height = 24; //size of the hitbox
            item.damage = 20; //damage of the item
            item.knockBack = 0.4f; //knockback of the item, 0.4f is 40%
            item.autoReuse = true; //sets autoswing to true
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = item.useAnimation = 5;
            item.useTurn = true;
            item.melee = true; //sets the damage type to melee
            item.tileBoost += 6; //sets the range of the tool
        }
    }
}
