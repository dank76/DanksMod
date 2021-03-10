using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Projectiles
{
	public class BloodBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Beam");
		}

		public override void SetDefaults()
		{
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.extraUpdates = 2;
            projectile.alpha = 0;
            projectile.magic = true;
		}

		public override void AI()
		{
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
			float num29 = 5f;
			float num30 = 150f;
			float scaleFactor = 6f;
			Vector2 value7;
			value7 = Vector2.Zero;
			float num31 = 1f;
			int maxUpdates = projectile.MaxUpdates;
			int num32 = Utils.SelectRandom<int>(Main.rand, new int[]
			{
				235
			});
			int num33 = 261;
			if (projectile.ai[1] == 0f)
			{
                projectile.ai[1] = 1f;
                projectile.localAI[0] = -(float)Main.rand.Next(48);
			}
			else if (projectile.ai[1] == 1f && projectile.owner == Main.myPlayer)
			{
				int num34 = -1;
				float num35 = num30;
				for (int num36 = 0; num36 < 200; num36++)
				{
					if (Main.npc[num36].active && Main.npc[num36].CanBeChasedBy(projectile, false))
					{
						Vector2 center3 = Main.npc[num36].Center;
						float num37 = Vector2.Distance(center3, projectile.Center);
						if (num37 < num35 && num34 == -1 && Collision.CanHitLine(projectile.Center, 1, 1, center3, 1, 1))
						{
							num35 = num37;
							num34 = num36;
						}
					}
				}
				if (num35 < 8f)
				{
                    projectile.Kill();
					return;
				}
				if (num34 != -1)
				{
                    projectile.ai[1] = num29 + 1f;
                    projectile.ai[0] = (float)num34;
                    projectile.netUpdate = true;
				}
			}
			else if (projectile.ai[1] > num29)
			{
                projectile.ai[1] += 1f;
				int num38 = (int)projectile.ai[0];
				if (!Main.npc[num38].active || !Main.npc[num38].CanBeChasedBy(projectile, false))
				{
                    projectile.ai[1] = 1f;
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
				}
				else
				{
					Utils.ToRotation(projectile.velocity);
					Vector2 vector6 = Main.npc[num38].Center - projectile.Center;
					if (vector6.Length() < 20f)
					{
                        projectile.Kill();
						return;
					}
					if (vector6 != Vector2.Zero)
					{
						vector6.Normalize();
						vector6 *= scaleFactor;
					}
					float num39 = 30f;
                    projectile.velocity = (projectile.velocity * (num39 - 1f) + vector6) / num39;
				}
			}
			if (projectile.ai[1] >= 1f && projectile.ai[1] < num29)
			{
                projectile.ai[1] += 1f;
				if (projectile.ai[1] == num29)
				{
                    projectile.ai[1] = 1f;
				}
			}
            projectile.localAI[0] += 1f;
			if (projectile.localAI[0] == 48f)
			{
                projectile.localAI[0] = 0f;
			}
			else if (projectile.alpha == 0)
			{
				for (int num40 = 0; num40 < 2; num40++)
				{
					Vector2 value8 = Vector2.UnitX * -30f;
					value8 = -Utils.RotatedBy(Vector2.UnitY, (double)(projectile.localAI[0] * 0.1308997f + (float)num40 * 3.1415927f), default(Vector2)) * value7 - Utils.ToRotationVector2(projectile.rotation) * 10f;
					int num41 = Dust.NewDust(projectile.Center, 0, 0, 235, 0f, 0f, 160, default(Color), 1f);
					Main.dust[num41].scale = num31;
					Main.dust[num41].noGravity = true;
					Main.dust[num41].position = projectile.Center + value8 + projectile.velocity * 2f;
					Main.dust[num41].velocity = Vector2.Normalize(projectile.Center + projectile.velocity * 2f * 8f - Main.dust[num41].position) * 2f + projectile.velocity * 2f;
				}
			}
			if (Utils.NextBool(Main.rand, 12))
			{
				Vector2 value9 = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.2), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
				int num42 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 235, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num42].velocity *= 0.1f;
				Main.dust[num42].position = projectile.Center + value9 * (float)projectile.width / 2f + projectile.velocity * 2f;
				Main.dust[num42].fadeIn = 0.9f;
			}
			if (Utils.NextBool(Main.rand, 64))
			{
				Vector2 value10 = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.4), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
				int num43 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 235, 0f, 0f, 155, default(Color), 0.8f);
				Main.dust[num43].velocity *= 0.3f;
				Main.dust[num43].position = projectile.Center + value10 * (float)projectile.width / 2f;
				if (Utils.NextBool(Main.rand, 2))
				{
					Main.dust[num43].fadeIn = 1.4f;
				}
			}
			if (Utils.NextBool(Main.rand, 4))
			{
				for (int num44 = 0; num44 < 2; num44++)
				{
					Vector2 value11 = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.8), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
					int num45 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 235, 0f, 0f, 0, default(Color), 1.2f);
					Main.dust[num45].velocity *= 0.3f;
					Main.dust[num45].noGravity = true;
					Main.dust[num45].position = projectile.Center + value11 * (float)projectile.width / 2f;
					if (Utils.NextBool(Main.rand, 2))
					{
						Main.dust[num45].fadeIn = 1.4f;
					}
				}
			}
			if (Utils.NextBool(Main.rand, 3))
			{
				Vector2 value12 = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.2), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
				int num46 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 235, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num46].velocity *= 0.3f;
				Main.dust[num46].position = projectile.Center + value12 * (float)projectile.width / 2f;
				Main.dust[num46].fadeIn = 1.2f;
				Main.dust[num46].scale = 1.5f;
				Main.dust[num46].noGravity = true;
			}
			Lighting.AddLight(projectile.Center, (float)(255 - projectile.alpha) * 0.25f / 255f, (float)(255 - projectile.alpha) * 0f / 255f, (float)(255 - projectile.alpha) * 0.25f / 255f);
			for (int num47 = 0; num47 < 2; num47++)
			{
				int num48 = 14;
				int num49 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - num48 * 2, projectile.height - num48 * 2, 263, 0f, 0f, 100, default(Color), 1.35f);
				Main.dust[num49].noGravity = true;
				Main.dust[num49].velocity *= 0.1f;
				Main.dust[num49].velocity += projectile.velocity * 0.5f;
			}
			if (Utils.NextBool(Main.rand, 8))
			{
				int num50 = 16;
				int num51 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - num50 * 2, projectile.height - num50 * 2, 263, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num51].velocity *= 0.25f;
				Main.dust[num51].noGravity = true;
				Main.dust[num51].velocity += projectile.velocity * 0.5f;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D tex = Main.projectileTexture[projectile.type];
			spriteBatch.Draw(tex, projectile.Center - Main.screenPosition, null, projectile.GetAlpha(lightColor), projectile.rotation, Utils.Size(tex) / 2f, projectile.scale, 0, 0f);
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (target.type == NPCID.TargetDummy || !target.canGhostHeal || Main.player[projectile.owner].moonLeech)
			{
				return;
			}
			Player player = Main.player[projectile.owner];
			player.statLife++;
			player.statMana += 25;
			player.HealEffect(1, true);
			player.ManaEffect(25);
		}

		public override void Kill(int timeLeft)
		{
			int num47 = Utils.SelectRandom<int>(Main.rand, new int[]
			{
				235
			});
			int num48 = 263;
			int num49 = 263;
			int height = 50;
			float num50 = 1.7f;
			float num51 = 0.8f;
			float num52 = 2f;
			Vector2 value4 = Utils.ToRotationVector2(projectile.rotation - 1.5707964f) * projectile.velocity.Length() * (float)projectile.MaxUpdates;
			Main.PlaySound(SoundID.Item14, projectile.position);
            projectile.position = projectile.Center;
            projectile.width = (projectile.height = height);
            projectile.Center = projectile.position;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.Damage();
			for (int num53 = 0; num53 < 40; num53++)
			{
				num47 = Utils.SelectRandom<int>(Main.rand, new int[]
				{
					235
				});
				int num54 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num47, 0f, 0f, 200, default(Color), num50);
				Dust dust = Main.dust[num54];
				dust.position = projectile.Center + Utils.RotatedByRandom(Vector2.UnitY, 3.1415927410125732) * (float)Main.rand.NextDouble() * (float)projectile.width / 2f;
				dust.noGravity = true;
				dust.velocity *= 3f;
				dust.velocity += value4 * Utils.NextFloat(Main.rand);
				num54 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num48, 0f, 0f, 100, default(Color), num51);
				dust.position = projectile.Center + Utils.RotatedByRandom(Vector2.UnitY, 3.1415927410125732) * (float)Main.rand.NextDouble() * (float)projectile.width / 2f;
				dust.velocity *= 2f;
				dust.noGravity = true;
				dust.fadeIn = 1f;
				dust.color = Color.Crimson * 0.5f;
				dust.velocity += value4 * Utils.NextFloat(Main.rand);
			}
			for (int num55 = 0; num55 < 20; num55++)
			{
				int num56 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num49, 0f, 0f, 0, default(Color), num52);
				Dust dust2 = Main.dust[num56];
				dust2.position = projectile.Center + Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 3.1415927410125732), (double)Utils.ToRotation(projectile.velocity), default(Vector2)) * (float)projectile.width / 3f;
				dust2.noGravity = true;
				dust2.velocity *= 0.5f;
				dust2.velocity += value4 * (0.6f + 0.6f * Utils.NextFloat(Main.rand));
			}
		}
	}
}
