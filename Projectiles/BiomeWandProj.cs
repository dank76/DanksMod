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
			base.DisplayName.SetDefault("True Biome Orb");
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }

		public override void SetDefaults()
		{
            Player player = Main.player[base.projectile.owner];
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
                this.dustType = global::Terraria.ModLoader.ModContent.DustType<global::CalamityMod.Dusts.AstralOrange>();
                this.color = new global::Microsoft.Xna.Framework.Color(255, 127, 80);
            }
            else if (jungle)
            {
                this.dustType = 39;
                this.color = new global::Microsoft.Xna.Framework.Color(128, 255, 128);
            }
            else if (snow)
            {
                this.dustType = 51;
                this.color = new global::Microsoft.Xna.Framework.Color(128, 255, 255);
            }
            else if (beach)
            {
                this.dustType = 33;
                this.color = new global::Microsoft.Xna.Framework.Color(0, 0, 128);
            }
            else if (corrupt)
            {
                this.dustType = 14;
                this.color = new global::Microsoft.Xna.Framework.Color(128, 64, 255);
            }
            else if (crimson)
            {
                this.dustType = 5;
                this.color = new global::Microsoft.Xna.Framework.Color(128, 0, 0);
            }
            else if (dungeon)
            {
                this.dustType = 29;
                this.color = new global::Microsoft.Xna.Framework.Color(64, 0, 128);
            }
            else if (desert)
            {
                this.dustType = 32;
                this.color = new global::Microsoft.Xna.Framework.Color(255, 255, 128);
            }
            else if (glow)
            {
                this.dustType = 56;
                this.color = new global::Microsoft.Xna.Framework.Color(0, 255, 255);
            }
            else if (hell)
            {
                this.dustType = 6;
                this.color = new global::Microsoft.Xna.Framework.Color(255, 128, 0);
            }
            else if (sky)
            {
                this.dustType = 213;
                this.color = new global::Microsoft.Xna.Framework.Color(255, 255, 255);
            }
            else if (holy)
            {
                this.dustType = 57;
                this.color = new global::Microsoft.Xna.Framework.Color(255, 255, 0);
            }
            else
            {
                this.color = new global::Microsoft.Xna.Framework.Color(0, 128, 0);
            }
            int num458 = global::Terraria.Dust.NewDust(new global::Microsoft.Xna.Framework.Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, this.dustType, 0f, 0f, 100, default(global::Microsoft.Xna.Framework.Color), 1.2f);
            global::Terraria.Main.dust[num458].noGravity = true;
            global::Terraria.Main.dust[num458].velocity *= 0.5f;
            global::Terraria.Main.dust[num458].velocity += base.projectile.velocity * 0.1f;

            if (Main.myPlayer == base.projectile.owner && base.projectile.ai[0] <= 0f)
            {
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

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (base.projectile.timeLeft > 295)
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
				float num796 = base.projectile.oldVelocity.X * (30f / (float)num795);
				float num797 = base.projectile.oldVelocity.Y * (30f / (float)num795);
				int num798 = global::Terraria.Dust.NewDust(new global::Microsoft.Xna.Framework.Vector2(base.projectile.oldPosition.X - num796, base.projectile.oldPosition.Y - num797), 8, 8, this.dustType, base.projectile.oldVelocity.X, base.projectile.oldVelocity.Y, 100, default(global::Microsoft.Xna.Framework.Color), 1.8f);
				global::Terraria.Main.dust[num798].noGravity = true;
				global::Terraria.Main.dust[num798].velocity *= 0.5f;
				num798 = global::Terraria.Dust.NewDust(new global::Microsoft.Xna.Framework.Vector2(base.projectile.oldPosition.X - num796, base.projectile.oldPosition.Y - num797), 8, 8, this.dustType, base.projectile.oldVelocity.X, base.projectile.oldVelocity.Y, 100, default(global::Microsoft.Xna.Framework.Color), 1.4f);
				global::Terraria.Main.dust[num798].velocity *= 0.05f;
				num799 = num795;
			}
		}

		public override void OnHitNPC(global::Terraria.NPC target, int damage, float knockback, bool crit)
		{
			global::Terraria.Player player = global::Terraria.Main.player[base.projectile.owner];
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
				target.AddBuff(global::Terraria.ModLoader.ModContent.BuffType<Plague>(), 360, false);
				return;
			}
			if (snow)
			{
				target.AddBuff(global::Terraria.ModLoader.ModContent.BuffType<GlacialState>(), 360, false);
				return;
			}
			if (beach)
			{
				target.AddBuff(global::Terraria.ModLoader.ModContent.BuffType<CrushDepth>(), 360, false);
				return;
			}
			if (dungeon)
			{
				target.AddBuff(44, 360, false);
				return;
			}
			if (desert)
			{
				target.AddBuff(global::Terraria.ModLoader.ModContent.BuffType<HolyFlames>(), 360, false);
				return;
			}
			if (glow)
			{
				target.AddBuff(global::Terraria.ModLoader.ModContent.BuffType<TemporalSadness>(), 360, false);
				return;
			}
			if (hell)
			{
				target.AddBuff(global::Terraria.ModLoader.ModContent.BuffType<global::CalamityMod.Buffs.DamageOverTime.BrimstoneFlames>(), 360, false);
				return;
			}
			if (holy)
			{
				target.AddBuff(global::Terraria.ModLoader.ModContent.BuffType<global::CalamityMod.Buffs.DamageOverTime.HolyFlames>(), 360, false);
				return;
			}
			target.AddBuff(global::Terraria.ModLoader.ModContent.BuffType<global::CalamityMod.Buffs.StatDebuffs.ArmorCrunch>(), 360, false);
		}

		private int dustType = 3;

		private global::Microsoft.Xna.Framework.Color color;
	}
}
