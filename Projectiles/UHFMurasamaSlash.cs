using System;
using CalamityMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Projectiles
{
	public class UHFMurasamaSlash : ModProjectile
	{
		public int CurrentFrame
		{
			get
			{
				return frameX * 7 + frameY;
			}
			set
			{
				frameX = value / 7;
				frameY = value % 7;
			}
		}

		public bool Slashing
		{
			get
			{
				return CurrentFrame % 7 == 0 && projectile.frameCounter % 3 == 2;
			}
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("U.H.F Slash");
		}

		public override void SetDefaults()
		{
			projectile.width = 236;
			projectile.height = 180;
			projectile.scale = 2.2f;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.melee = true;
			projectile.ownerHitCheck = true;
			projectile.usesIDStaticNPCImmunity = true;
			projectile.idStaticNPCHitCooldown = 5;
			projectile.Calamity().trueMelee = true;
			projectile.frameCounter = 0;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (projectile.frameCounter <= 1)
			{
				return false;
			}
			Texture2D texture = Main.projectileTexture[projectile.type];
			Vector2 origin = Utils.Size(texture) / new Vector2(2f, 7f) * 0.5f;
			Rectangle frame = Utils.Frame(texture, 2, 7, frameX, frameY);
			SpriteEffects spriteEffects = (projectile.spriteDirection == 1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new global::Microsoft.Xna.Framework.Rectangle?(frame), Color.White, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);
			return false;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.frameCounter++;
			if (projectile.frameCounter % 3 == 0)
			{
				int currentFrame = CurrentFrame;
				CurrentFrame = currentFrame + 1;
				if (frameX >= 2)
				{
					CurrentFrame = 0;
				}
			}
			if (Slashing)
			{
				Main.PlaySound(SoundID.Item15, projectile.Center);
			}
			Vector2 origin = projectile.Center + projectile.velocity * 3f;
			Lighting.AddLight(origin, 3f, 0.2f, 0.2f);
			if (Utils.NextBool(Main.rand, 3))
			{
				int redDust = Dust.NewDust(origin - projectile.Size / 2f, projectile.width, projectile.height, 71, projectile.velocity.X, projectile.velocity.Y, 100, default, 2f);
				Main.dust[redDust].noGravity = true;
				Main.dust[redDust].position -= projectile.velocity;
			}
			Vector2 playerRotatedPoint = player.RotatedRelativePoint(player.MountedCenter, true);
			if (Main.myPlayer == projectile.owner)
			{
				if (player.channel && !player.noItems && !player.CCed)
				{
					HandleChannelMovement(player, playerRotatedPoint);
				}
				else
				{
					projectile.Kill();
				}
			}
			float velocityAngle = Utils.ToRotation(projectile.velocity);
			projectile.rotation = velocityAngle + (float)Utils.ToInt(projectile.spriteDirection == -1) * 3.1415927f;
			projectile.direction = Utils.ToDirectionInt(Math.Cos((double)velocityAngle) > 0.0);
			float offset = 80f * projectile.scale;
			projectile.position = playerRotatedPoint - projectile.Size * 0.5f + Utils.ToRotationVector2(velocityAngle) * offset;
			projectile.spriteDirection = projectile.direction;
			player.ChangeDir(projectile.direction);
			projectile.timeLeft = 2;
			player.itemRotation = Utils.ToRotation(projectile.velocity * (float)projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
		}

		public void HandleChannelMovement(Player player, Vector2 playerRotatedPoint)
		{
			float speed = 1f;
			if (player.ActiveItem().shoot == projectile.type)
			{
				speed = player.ActiveItem().shootSpeed * projectile.scale;
			}
			Vector2 newVelocity = Utils.SafeNormalize(Main.MouseWorld - playerRotatedPoint, Vector2.UnitX * (float)player.direction) * speed;
			if (projectile.velocity.X != newVelocity.X || projectile.velocity.Y != newVelocity.Y)
			{
				projectile.netUpdate = true;
			}
			projectile.velocity = newVelocity;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new global::Microsoft.Xna.Framework.Color?(new Color(30, 0, 100, 0));
		}

		public int frameX;

		public int frameY;
	}
}

