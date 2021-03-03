using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Projectiles
{
    public class SeaShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Shard");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.minion = true;
            projectile.extraUpdates = 2;
            projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Electrified, 60);
        }

        public override void AI()
        {
            if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
            {
                projectile.soundDelay = 10;
                Main.PlaySound(SoundID.Item20, projectile.Center);
            }
            int sand = Dust.NewDust(projectile.position, projectile.width, projectile.height, 99, 0f, 0f, 100, default(Color), 2f);
            Dust obj = Main.dust[sand];
            obj.velocity *= 0.3f;
            obj.position.X = projectile.Center.X + 4f + (float)Main.rand.Next(-4, 5);
            obj.position.Y = projectile.Center.Y + (float)Main.rand.Next(-4, 5);
            obj.noGravity = true;
            if (Main.myPlayer == projectile.owner && projectile.ai[0] <= 0f)
            {
                Player player = Main.player[projectile.owner];
                if (player.channel)
                {
                    float speed = 18f;
                    float mouseDistX2 = (float)Main.mouseX + Main.screenPosition.X - projectile.Center.X;
                    float mouseDistY2 = (float)Main.mouseY + Main.screenPosition.Y - projectile.Center.Y;
                    if (player.gravDir == -1f)
                    {
                        mouseDistY2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - projectile.Center.Y;
                    }
                    Vector2 mouseVec = new Vector2(mouseDistX2, mouseDistY2);
                    float mouseDist2 = mouseVec.Length();
                    if (projectile.ai[0] < 0f)
                    {
                        projectile.ai[0] += 1f;
                    }
                    if (mouseDist2 > speed)
                    {
                        mouseDist2 = speed / mouseDist2;
                        mouseVec.X *= mouseDist2;
                        mouseVec.Y *= mouseDist2;
                        int num = (int)(mouseVec.X * 1000f);
                        int projSpeedX2 = (int)(projectile.velocity.X * 1000f);
                        int mouseSpeedY2 = (int)(mouseVec.Y * 1000f);
                        int projSpeedY2 = (int)(projectile.velocity.Y * 1000f);
                        if (num != projSpeedX2 || mouseSpeedY2 != projSpeedY2)
                        {
                            projectile.netUpdate = true;
                        }
                        projectile.velocity.X = mouseVec.X;
                        projectile.velocity.Y = mouseVec.Y;
                    }
                    else
                    {
                        int num2 = (int)(mouseVec.X * 1000f);
                        int projSpeedX = (int)(projectile.velocity.X * 1000f);
                        int mouseSpeedY = (int)(mouseVec.Y * 1000f);
                        int projSpeedY = (int)(projectile.velocity.Y * 1000f);
                        if (num2 != projSpeedX || mouseSpeedY != projSpeedY)
                        {
                            projectile.netUpdate = true;
                        }
                        projectile.velocity.X = mouseVec.X;
                        projectile.velocity.Y = mouseVec.Y;
                    }
                }
                else if (projectile.ai[0] <= 0f)
                {
                    projectile.netUpdate = true;
                    Vector2 projCenter = projectile.Center;
                    float mouseDistX = (float)Main.mouseX + Main.screenPosition.X - projCenter.X;
                    float mouseDistY = (float)Main.mouseY + Main.screenPosition.Y - projCenter.Y;
                    if (player.gravDir == -1f)
                    {
                        mouseDistY = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - projCenter.Y;
                    }
                    Vector2 mouseVec2 = new Vector2(mouseDistX, mouseDistY);
                    float mouseDist = mouseVec2.Length();
                    if (mouseDist == 0f || projectile.ai[0] < 0f)
                    {
                        projCenter = player.Center;
                        mouseVec2 = projectile.Center - projCenter;
                        mouseDist = mouseVec2.Length();
                    }
                    mouseDist = 12f / mouseDist;
                    mouseVec2.X *= mouseDist;
                    mouseVec2.Y *= mouseDist;
                    projectile.velocity.X = mouseVec2.X;
                    projectile.velocity.Y = mouseVec2.Y;
                    if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                    {
                        projectile.Kill();
                    }
                    projectile.ai[0] = 1f;
                }
            }
            if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
            {
                projectile.rotation = projectile.velocity.ToRotation() + (float)Math.PI / 2f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }

        public override void Kill(int timeLeft)
        {
            projectile.position = projectile.Center;
            projectile.width = (projectile.height = 64);
            projectile.Center = projectile.position;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.Damage();
            Main.PlaySound(SoundID.Item14, projectile.Center);
            int dustAmt = 36;
            for (int index = 0; index < dustAmt; index++) ;
        }
    }
}