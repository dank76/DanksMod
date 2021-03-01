using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DanksMod.Projectiles
{
    public class DryIceCloud : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dry Ice");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.height = 36;
            projectile.width = 34;
            projectile.scale = 2f;
            projectile.friendly = true;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            
        }
        public override void AI()
        {
            int frameSpeed = 5;
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<CalamityMod.Buffs.StatDebuffs.GlacialState>(), 60);
            target.AddBuff(BuffID.Frostburn, 120);
        }
    }
}
