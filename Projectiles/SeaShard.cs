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
            base.DisplayName.SetDefault("Sea Shard");
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 18;
            base.projectile.height = 18;
            base.projectile.friendly = true;
            base.projectile.penetrate = 2;
            base.projectile.minion = true;
            base.projectile.extraUpdates = 2;
            projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Electrified, 60);
        }

        public override void AI()
        {
            if (base.projectile.soundDelay == 0 && Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) > 2f)
            {
                base.projectile.soundDelay = 10;
                Main.PlaySound(SoundID.Item20, base.projectile.Center);
            }
            int sand = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 99, 0f, 0f, 100, default(Color), 2f);
            Dust obj = Main.dust[sand];
            obj.velocity *= 0.3f;
            obj.position.X = base.projectile.Center.X + 4f + (float)Main.rand.Next(-4, 5);
            obj.position.Y = base.projectile.Center.Y + (float)Main.rand.Next(-4, 5);
            obj.noGravity = true;
            if (Main.myPlayer == base.projectile.owner && base.projectile.ai[0] <= 0f)
            {
                Player player = Main.player[base.projectile.owner];
                if (player.channel)
                {
                    float speed = 18f;
                    float mouseDistX2 = (float)Main.mouseX + Main.screenPosition.X - base.projectile.Center.X;
                    float mouseDistY2 = (float)Main.mouseY + Main.screenPosition.Y - base.projectile.Center.Y;
                    if (player.gravDir == -1f)
                    {
                        mouseDistY2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - base.projectile.Center.Y;
                    }
                    Vector2 mouseVec = new Vector2(mouseDistX2, mouseDistY2);
                    float mouseDist2 = mouseVec.Length();
                    if (base.projectile.ai[0] < 0f)
                    {
                        base.projectile.ai[0] += 1f;
                    }
                    if (mouseDist2 > speed)
                    {
                        mouseDist2 = speed / mouseDist2;
                        mouseVec.X *= mouseDist2;
                        mouseVec.Y *= mouseDist2;
                        int num = (int)(mouseVec.X * 1000f);
                        int projSpeedX2 = (int)(base.projectile.velocity.X * 1000f);
                        int mouseSpeedY2 = (int)(mouseVec.Y * 1000f);
                        int projSpeedY2 = (int)(base.projectile.velocity.Y * 1000f);
                        if (num != projSpeedX2 || mouseSpeedY2 != projSpeedY2)
                        {
                            base.projectile.netUpdate = true;
                        }
                        base.projectile.velocity.X = mouseVec.X;
                        base.projectile.velocity.Y = mouseVec.Y;
                    }
                    else
                    {
                        int num2 = (int)(mouseVec.X * 1000f);
                        int projSpeedX = (int)(base.projectile.velocity.X * 1000f);
                        int mouseSpeedY = (int)(mouseVec.Y * 1000f);
                        int projSpeedY = (int)(base.projectile.velocity.Y * 1000f);
                        if (num2 != projSpeedX || mouseSpeedY != projSpeedY)
                        {
                            base.projectile.netUpdate = true;
                        }
                        base.projectile.velocity.X = mouseVec.X;
                        base.projectile.velocity.Y = mouseVec.Y;
                    }
                }
                else if (base.projectile.ai[0] <= 0f)
                {
                    base.projectile.netUpdate = true;
                    Vector2 projCenter = base.projectile.Center;
                    float mouseDistX = (float)Main.mouseX + Main.screenPosition.X - projCenter.X;
                    float mouseDistY = (float)Main.mouseY + Main.screenPosition.Y - projCenter.Y;
                    if (player.gravDir == -1f)
                    {
                        mouseDistY = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - projCenter.Y;
                    }
                    Vector2 mouseVec2 = new Vector2(mouseDistX, mouseDistY);
                    float mouseDist = mouseVec2.Length();
                    if (mouseDist == 0f || base.projectile.ai[0] < 0f)
                    {
                        projCenter = player.Center;
                        mouseVec2 = base.projectile.Center - projCenter;
                        mouseDist = mouseVec2.Length();
                    }
                    mouseDist = 12f / mouseDist;
                    mouseVec2.X *= mouseDist;
                    mouseVec2.Y *= mouseDist;
                    base.projectile.velocity.X = mouseVec2.X;
                    base.projectile.velocity.Y = mouseVec2.Y;
                    if (base.projectile.velocity.X == 0f && base.projectile.velocity.Y == 0f)
                    {
                        base.projectile.Kill();
                    }
                    base.projectile.ai[0] = 1f;
                }
            }
            if (base.projectile.velocity.X != 0f || base.projectile.velocity.Y != 0f)
            {
                base.projectile.rotation = base.projectile.velocity.ToRotation() + (float)Math.PI / 2f;
            }
            if (base.projectile.velocity.Y > 16f)
            {
                base.projectile.velocity.Y = 16f;
            }
        }

        public override void Kill(int timeLeft)
        {
            base.projectile.position = base.projectile.Center;
            base.projectile.width = (base.projectile.height = 64);
            base.projectile.Center = base.projectile.position;
            base.projectile.maxPenetrate = -1;
            base.projectile.penetrate = -1;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 10;
            base.projectile.Damage();
            Main.PlaySound(SoundID.Item14, base.projectile.Center);
            int dustAmt = 36;
            for (int index = 0; index < dustAmt; index++) ;
        }
    }
}