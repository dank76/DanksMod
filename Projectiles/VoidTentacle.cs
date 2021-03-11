using System;
using CalamityMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;

namespace DanksMod.Projectiles
{
	public class VoidTentacle : ModProjectile
	{
		public int AlphaFade
		{
			get
			{
				return (int)base.projectile.localAI[0];
			}
			set
			{
				base.projectile.localAI[0] = (float)value;
			}
		}

		public Vector2 OffsetAcceleration
		{
			get
			{
				return new Vector2(base.projectile.ai[0], base.projectile.ai[1]);
			}
			set
			{
				base.projectile.ai[0] = value.X;
				base.projectile.ai[1] = value.Y;
			}
		}

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Void Tentacle");
			ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 75;
		}

		public override void SetDefaults()
		{
			projectile.width = (base.projectile.height = 20);
			base.projectile.friendly = true;
			base.projectile.penetrate = 2;
			base.projectile.MaxUpdates = 2;
			base.projectile.penetrate = -1;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 16;
		}

		public override void AI()
		{
			if (!base.projectile.tileCollide)
			{
				int alphaFade = this.AlphaFade;
				this.AlphaFade = alphaFade + 1;
				base.projectile.alpha = this.AlphaFade;
				if (base.projectile.alpha >= 255)
				{
					base.projectile.Kill();
					return;
				}
			}
			for (int i = 1; i < base.projectile.oldPos.Length; i++)
			{
				base.projectile.oldPos[i] = base.projectile.oldPos[i - 1] + Vector2.Normalize(base.projectile.oldPos[i] - base.projectile.oldPos[i - 1]) * 5f;
			}
			CalamityGlobalProjectile.ExpandHitboxBy(base.projectile, (int)(20f * base.projectile.scale));
			if (Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height) && base.projectile.tileCollide)
			{
				base.projectile.tileCollide = false;
			}
			NPC closestTarget = projectile.Center.ClosestNPCAt(1450f, true, true);
			if (closestTarget != null)
			{
				this.HomingMovement(closestTarget);
			}
			else
			{
				this.ArcingMovement();
			}
			base.projectile.scale -= ((closestTarget == null) ? 0.007f : 0.004f);
			if (base.projectile.scale <= 0.05f)
			{
				base.projectile.Kill();
			}
		}

		public void ArcingMovement()
		{
			base.projectile.velocity += this.OffsetAcceleration;
			if (base.projectile.velocity.Length() > 16f)
			{
				base.projectile.velocity.Normalize();
				base.projectile.velocity *= 16f;
			}
			this.OffsetAcceleration *= 1.035f;
		}

		public void HomingMovement(NPC closestTarget)
		{
			float angleOffset = MathHelper.WrapAngle(base.projectile.AngleTo(closestTarget.Center) - Utils.ToRotation(base.projectile.velocity));
			angleOffset = MathHelper.Clamp(angleOffset, -0.2f, 0.2f);
			if (base.projectile.Distance(closestTarget.Center) > 65f)
			{
				base.projectile.velocity = Utils.RotatedBy(base.projectile.velocity, (double)angleOffset, default(Vector2));
				base.projectile.velocity = Utils.SafeNormalize(base.projectile.velocity, Vector2.UnitY) * 18f;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			spriteBatch.End();
			spriteBatch.Begin((SpriteSortMode)1, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.instance.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
			if (base.projectile.scale < 1f)
			{
				for (int i = 10; i < base.projectile.oldPos.Length; i++)
				{
					MiscShaderData miscShaderData = GameShaders.Misc["CalamityMod:SubsumingTentacle"];
					miscShaderData.UseImage("Images/Misc/Perlin");
					Vector2 drawPos = base.projectile.oldPos[i] + Utils.Size(ModContent.GetTexture(this.Texture)) / 2f - Main.screenPosition + base.projectile.gfxOffY * Vector2.UnitY;
					float scale = MathHelper.Lerp(0.05f, 1.3f, (float)i / (float)base.projectile.oldPos.Length) * base.projectile.scale;
					scale = MathHelper.Clamp(scale, 0f, 2f);
					Color color = base.projectile.GetAlpha(lightColor) * (float)((base.projectile.oldPos.Length - i) / base.projectile.oldPos.Length);
					spriteBatch.Draw(ModContent.GetTexture(this.Texture), drawPos, null, color, base.projectile.rotation, Utils.Size(ModContent.GetTexture(this.Texture)) / 2f, scale, 0, 0f);
					miscShaderData.UseSaturation((float)i / (float)base.projectile.oldPos.Length);
					miscShaderData.UseOpacity(1f / (float)base.projectile.oldPos.Length);
					miscShaderData.Apply(null);
				}
			}
			return false;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			spriteBatch.End();
			spriteBatch.Begin(0, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.instance.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			for (int i = 1; i < base.projectile.oldPos.Length; i++)
			{
				float scale = MathHelper.Lerp(0.05f, 1f, (float)i / (float)base.projectile.oldPos.Length) * base.projectile.scale * 0.85f;
				if (targetHitbox.Intersects(new Rectangle((int)base.projectile.oldPos[i].X, (int)base.projectile.oldPos[i].Y, (int)((float)base.projectile.width * scale), (int)((float)base.projectile.height * scale))))
				{
					return new bool?(true);
				}
			}
			return new bool?(false);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.velocity = oldVelocity;
			return false;
		}

		public const float SegmentOffset = 5f;

		public const float MaxArcingSpeed = 16f;

		public const float MaxHomingSpeed = 18f;

		public const float MaxEnemyDistance = 1450f;
	}
}
