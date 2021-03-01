using CalamityMod.Buffs.DamageOverTime;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.Projectiles
{
	public class DryIceFire : ModProjectile
	{
		public override string Texture => "CalamityMod/Projectiles/InvisibleProj";

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fire");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 12;
			base.projectile.height = 12;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = 2;
			base.projectile.extraUpdates = 2;
			base.projectile.timeLeft = 50;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
			base.projectile.tileCollide = false;
		}

		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.15f, 0.45f, 0f);
			if (base.projectile.ai[0] > 7f)
			{
				float num296 = 1f;
				if (base.projectile.ai[0] == 8f)
				{
					num296 = 0.25f;
				}
				else if (base.projectile.ai[0] == 9f)
				{
					num296 = 0.5f;
				}
				else if (base.projectile.ai[0] == 10f)
				{
					num296 = 0.75f;
				}
				base.projectile.ai[0] += 1f;
				int num297 = 230;
				if (Main.rand.NextBool(2))
				{
					for (int num298 = 0; num298 < 2; num298++)
					{
						int num299 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, num297, base.projectile.velocity.X * 0.2f, base.projectile.velocity.Y * 0.2f, 100, new Color(), 0.75f);
						Dust dust = Main.dust[num299];
						if (Main.rand.NextBool(3))
						{
							dust.noGravity = true;
							dust.scale *= 1.75f;
							dust.velocity.X *= 2f;
							dust.velocity.Y *= 2f;
						}
						else
						{
							dust.noGravity = true;
							dust.scale *= 0.5f;
						}
						dust.velocity.X *= 1.2f;
						dust.velocity.Y *= 1.2f;
						dust.scale *= num296;
						dust.velocity += base.projectile.velocity;
					}
				}
			}
			else
			{
				base.projectile.ai[0] += 1f;
			}
			base.projectile.rotation += 0.3f * (float)base.projectile.direction;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<CalamityMod.Buffs.StatDebuffs.GlacialState>(), 120);
			target.AddBuff(BuffID.Frostburn, 120);
		}
	}
}
