using System;
using CalamityMod.Projectiles;
using CalamityMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Projectiles
{
	public class Rift : ModProjectile
	{
		public float TargetCheckCooldown
		{
			get
			{
				return projectile.localAI[0];
			}
			set
			{
                projectile.localAI[0] = value;
			}
		}

		public float Time
		{
			get
			{
				return projectile.localAI[1];
			}
			set
			{
                projectile.localAI[1] = value;
			}
		}

		public int TargetIndex
		{
			get
			{
				return (int)projectile.ai[0];
			}
			set
			{
                projectile.ai[0] = (float)value;
			}
		}

		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Rift");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
            projectile.width = 60;
            projectile.height = 60;
            projectile.alpha = 255;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.extraUpdates = 4;
            projectile.timeLeft = 115 * projectile.extraUpdates;
            projectile.ignoreWater = true;
		}

		public override void AI()
		{
			if (this.Time == 0f)
			{
				this.TargetIndex = -1;
			}
			float time = this.Time;
			this.Time = time + 1f;
			if (projectile.localAI[1] > 10f && Utils.NextBool(Main.rand, 3))
			{
				this.VisualEffects();
			}
			this.Movement(this.HandleTargeting());
            projectile.rotation += projectile.velocity.X * 0.1f;
		}

		public bool HandleTargeting()
		{
			float targetCheckDistance = 350f * projectile.ai[1];
			if (this.TargetCheckCooldown > 0f)
			{
				float targetCheckCooldown = this.TargetCheckCooldown;
				this.TargetCheckCooldown = targetCheckCooldown - 1f;
			}
			if (this.TargetIndex == -1 && this.TargetCheckCooldown <= 0f)
			{
				NPC potentialTarget = projectile.Center.ClosestNPCAt(targetCheckDistance, true, true);
				if (potentialTarget != null)
				{
					this.TargetIndex = potentialTarget.whoAmI;
				}
                projectile.netUpdate = true;
			}
			if (this.TargetCheckCooldown <= 0f && this.TargetIndex == -1)
			{
				this.TargetCheckCooldown = 30f;
			}
			bool stillCanReachTarget = false;
			if (this.TargetIndex != -1)
			{
				stillCanReachTarget = (projectile.Distance(Main.npc[this.TargetIndex].Center) < 1200f);
				if (!stillCanReachTarget)
				{
					this.TargetIndex = -1;
                    projectile.netUpdate = true;
				}
			}
			return stillCanReachTarget;
		}

		public void VisualEffects()
		{
			if (!Main.dedServ)
			{
				int dustCount = 5;
				for (int i = 0; i < dustCount; i++)
				{
					Vector2 vector = projectile.Center + Utils.RotatedBy(projectile.Size, (double)((float)i / (float)dustCount * 6.2831855f), default(Vector2)) * 0.333f;
					Vector2 velocity = Utils.ToRotationVector2(Utils.NextFloat(Main.rand, 6.2831855f)) * Utils.NextFloat(Main.rand, 6f, 16f);
					Dust dust = Dust.NewDustPerfect(vector, 66, new Vector2?(velocity), 0, Main.DiscoColor, 0.7f);
					dust.noGravity = true;
					dust.noLight = true;
					dust.velocity = -projectile.velocity;
				}
			}
            projectile.alpha -= 5;
			if (projectile.alpha < 50)
			{
                projectile.alpha = 50;
			}
			Lighting.AddLight(projectile.Center / 16f, Main.DiscoColor.ToVector3());
		}

		public void Movement(bool stillCanReachTarget)
		{
			if (stillCanReachTarget)
			{
				float angleOffsetToTarget = projectile.AngleTo(Main.npc[this.TargetIndex].Center) - Utils.ToRotation(projectile.velocity);
				angleOffsetToTarget = MathHelper.WrapAngle(angleOffsetToTarget);
                projectile.velocity = Utils.RotatedBy(projectile.velocity, (double)(angleOffsetToTarget * 0.1f), default(Vector2));
			}
			float oldSpeed = projectile.velocity.Length();
            projectile.velocity = Utils.SafeNormalize(projectile.velocity, Vector2.UnitY) * (oldSpeed + 0.0025f);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			CalamityGlobalProjectile.DrawCenteredAndAfterimage(projectile, lightColor, ProjectileID.Sets.TrailingMode[projectile.type], 1, null, true);
			return false;
		}

		public const float AngularMovementSpeed = 0.1f;

		public const float Acceleration = 0.0025f;

		public const float TargetCheckInterval = 30f;

		public const float MaximumTargetDistance = 1200f;
	}
}
