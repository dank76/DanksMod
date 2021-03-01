using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Items
{
    public class DanksGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
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
    }
}
