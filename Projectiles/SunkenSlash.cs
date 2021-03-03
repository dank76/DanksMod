using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Projectiles
{
	public class SunkenSlash : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Sunken Slash");
			Main.projFrames[projectile.type] = 28;
		}

		public override void SetDefaults()
		{
			Mod CalamityMod = ModLoader.GetMod("CalamityMod");
			if (CalamityMod != null)
			{
                projectile.width = 148;
                projectile.height = 68;
                projectile.friendly = true;
                projectile.penetrate = -1;
                projectile.tileCollide = false;
                projectile.melee = true;
                projectile.ownerHitCheck = true;
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 5;
			}
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			float num = 0f;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter);
			if (projectile.spriteDirection == -1)
			{
				num = (float)Math.PI;
			}
			if (++projectile.frame >= Main.projFrames[projectile.type])
			{
                projectile.frame = 0;
			}
            projectile.soundDelay--;
			if (projectile.soundDelay <= 0)
			{
				Main.PlaySound(SoundID.Item15, projectile.Center);
                projectile.soundDelay = 24;
			}
			if (Main.myPlayer == projectile.owner)
			{
				if (player.channel && !player.noItems && !player.CCed)
				{
					float scaleFactor6 = 1f;
					if (player.inventory[player.selectedItem].shoot == projectile.type)
					{
						scaleFactor6 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
					}
					Vector2 vector2 = Main.MouseWorld - vector;
					vector2.Normalize();
					if (vector2.HasNaNs())
					{
						vector2 = Vector2.UnitX * player.direction;
					}
					vector2 *= scaleFactor6;
					if (vector2.X != projectile.velocity.X || vector2.Y != projectile.velocity.Y)
					{
                        projectile.netUpdate = true;
					}
                    projectile.velocity = vector2;
				}
				else
				{
                    projectile.Kill();
				}
			}
			Vector2 vector3 = projectile.Center + projectile.velocity * 3f;
			Lighting.AddLight(vector3, 0.2f, 0.2f, 3f);
			if (Main.rand.NextBool(3))
			{
				int num2 = Dust.NewDust(vector3 - projectile.Size / 2f, projectile.width, projectile.height, 99, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 2f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].position -= projectile.velocity;
			}
            projectile.position = player.RotatedRelativePoint(player.MountedCenter) - projectile.Size / 2f;
            projectile.rotation = projectile.velocity.ToRotation() + num;
            projectile.spriteDirection = projectile.direction;
            projectile.timeLeft = 2;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * (float)projectile.direction, projectile.velocity.X * (float)projectile.direction);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(0, 0, 200, 0);
		}
	}
}