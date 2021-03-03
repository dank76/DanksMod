using System;
using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.Buffs.StatDebuffs;
using CalamityMod.Dusts;
using CalamityMod.Projectiles;
using CalamityMod.World;
using CalamityMod.CalPlayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Projectiles
{
	public class BiomeWandProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("True Biome Orb");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

		public override void SetDefaults()
		{
            Player player = Main.player[projectile.owner];
            bool jungle = player.ZoneJungle;
            bool snow = player.ZoneSnow;
            bool beach = player.ZoneBeach;
            bool corrupt = player.ZoneCorrupt;
            bool crimson = player.ZoneCrimson;
            bool dungeon = player.ZoneDungeon;
            bool desert = player.ZoneDesert;
            bool glow = player.ZoneGlowshroom;
            bool hell = player.ZoneUnderworldHeight;
            bool sky = player.ZoneSkyHeight;
            bool holy = player.ZoneHoly;
            projectile.width = 21;
            projectile.height = 21;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.extraUpdates = 2;
 
            if (jungle)
            {
                projectile.maxPenetrate = 4;
                projectile.penetrate = 1;
                projectile.tileCollide = false;
            }
            else if (snow)
            {
                projectile.maxPenetrate = 2;
                projectile.penetrate = 1;
            }
            else if (beach)
            {
                projectile.maxPenetrate = 3;
                projectile.penetrate = 1;
                projectile.tileCollide = false;
            }
            else if (corrupt)
            {
                projectile.maxPenetrate = -1;
                projectile.penetrate = -1;
            }
            else if (crimson)
            {
                projectile.maxPenetrate = 2;
                projectile.penetrate = 1;
                projectile.tileCollide = false;
            }
            else if (dungeon)
            {
                projectile.maxPenetrate = 5;
                projectile.penetrate = 1;
            }
            else if (desert)
            {
                projectile.maxPenetrate = 2;
                projectile.penetrate = 1;
                projectile.tileCollide = false;
            }
            else if (glow)
            {
                projectile.tileCollide = false; 
            }
            else if (hell)
            {
                projectile.maxPenetrate = 7;
                projectile.penetrate = 1;
            }
            else if (sky)
            {
                projectile.tileCollide = false;
            }
            else if (holy)
            {
                projectile.tileCollide = false;
                projectile.maxPenetrate = 4;
                projectile.penetrate = 1;
            }
		}

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            bool astral = player.Calamity().ZoneAstral;
            bool jungle = player.ZoneJungle;
            bool snow = player.ZoneSnow;
            bool beach = player.ZoneBeach;
            bool corrupt = player.ZoneCorrupt;
            bool crimson = player.ZoneCrimson;
            bool dungeon = player.ZoneDungeon;
            bool desert = player.ZoneDesert;
            bool glow = player.ZoneGlowshroom;
            bool hell = player.ZoneUnderworldHeight;
            bool sky = player.ZoneSkyHeight;
            bool holy = player.ZoneHoly;
            if (astral)
            {
                dustType = ModContent.DustType<AstralOrange>();
                color = new Color(255, 127, 80);
            }
            else if (jungle)
            {
                dustType = 39;
                color = new Color(128, 255, 128);
            }
            else if (snow)
            {
                dustType = 51;
                color = new Color(128, 255, 255);
            }
            else if (beach)
            {
                dustType = 33;
                color = new Color(0, 0, 128);
            }
            else if (corrupt)
            {
                dustType = 14;
                color = new Color(128, 64, 255);
            }
            else if (crimson)
            {
                dustType = 5;
                color = new Color(128, 0, 0);
            }
            else if (dungeon)
            {
                dustType = 29;
                color = new Color(64, 0, 128);
            }
            else if (desert)
            {
                dustType = 32;
                color = new Color(255, 255, 128);
            }
            else if (glow)
            {
                dustType = 56;
                color = new Color(0, 255, 255);
            }
            else if (hell)
            {
                dustType = 6;
                color = new Color(255, 128, 0);
            }
            else if (sky)
            {
                dustType = 213;
                color = new Color(255, 255, 255);
            }
            else if (holy)
            {
                dustType = 57;
                color = new Color(255, 255, 0);
            }
            else
            {
                color = new Color(0, 128, 0);
            }
            int num458 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[num458].noGravity = true;
            Main.dust[num458].velocity *= 0.5f;
            Main.dust[num458].velocity += projectile.velocity * 0.1f;

            if (Main.myPlayer == projectile.owner && projectile.ai[0] <= 0f)
            {
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

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.timeLeft > 295)
            {
                return false;
            }
            return false;
        }

		public override void Kill(int timeLeft)
		{
			int num799;
			for (int num795 = 4; num795 < 31; num795 = num799 + 1)
			{
				float num796 = projectile.oldVelocity.X * (30f / (float)num795);
				float num797 = projectile.oldVelocity.Y * (30f / (float)num795);
				int num798 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num796, projectile.oldPosition.Y - num797), 8, 8, dustType, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.8f);
                Main.dust[num798].noGravity = true;
                Main.dust[num798].velocity *= 0.5f;
				num798 = Dust.NewDust(new Vector2(projectile.oldPosition.X - num796, projectile.oldPosition.Y - num797), 8, 8, dustType, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.4f);
                Main.dust[num798].velocity *= 0.05f;
				num799 = num795;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            Player player = Main.player[projectile.owner];
			bool astral = player.Calamity().ZoneAstral;
			bool jungle = player.ZoneJungle;
			bool snow = player.ZoneSnow;
			bool beach = player.ZoneBeach;
			bool dungeon = player.ZoneDungeon;
			bool desert = player.ZoneDesert;
			bool glow = player.ZoneGlowshroom;
			bool hell = player.ZoneUnderworldHeight;
			bool holy = player.ZoneHoly;
			if (astral)
			{
				target.AddBuff(ModContent.BuffType<AstralInfectionDebuff>(), 360, false);
				return;
			}
			if (jungle)
			{
				target.AddBuff(ModContent.BuffType<Plague>(), 360, false);
				return;
			}
			if (snow)
			{
				target.AddBuff(ModContent.BuffType<GlacialState>(), 360, false);
				return;
			}
			if (beach)
			{
				target.AddBuff(ModContent.BuffType<CrushDepth>(), 360, false);
				return;
			}
			if (dungeon)
			{
				target.AddBuff(44, 360, false);
				return;
			}
			if (desert)
			{
				target.AddBuff(ModContent.BuffType<HolyFlames>(), 360, false);
				return;
			}
			if (glow)
			{
				target.AddBuff(ModContent.BuffType<TemporalSadness>(), 360, false);
				return;
			}
			if (hell)
			{
				target.AddBuff(ModContent.BuffType<BrimstoneFlames>(), 360, false);
				return;
			}
			if (holy)
			{
				target.AddBuff(ModContent.BuffType<HolyFlames>(), 360, false);
				return;
			}
			target.AddBuff(ModContent.BuffType<ArmorCrunch>(), 360, false);
		}

		private int dustType = 3;

		private Color color;
	}
}
