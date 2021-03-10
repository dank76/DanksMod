using Terraria;
using Terraria.ModLoader;
using CalamityMod.CalPlayer;
using CalamityMod;
using Microsoft.Xna.Framework;

namespace DanksMod.Projectiles
{
    public class SurvivalKnifeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knife");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.Calamity().rogue = true;
            projectile.width = 14;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.aiStyle = 2;
            projectile.timeLeft = 600;
            this.aiType = 48;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2; // projectile sprite faces up
            // Loop through the 4 animation frames, spending 5 ticks on each.
            if (++projectile.frameCounter >= 10)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
                projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
                if (projectile.ai[0] >= 10f)
                {
                    projectile.ai[0] = 10f;
                    projectile.velocity.Y = projectile.velocity.Y + 0.1f;
                }
                if (projectile.velocity.Y > 41f)
                {
                    projectile.velocity.Y = 41f;
                }
            }
        }
    }
}
