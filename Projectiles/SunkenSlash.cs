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
			base.DisplayName.SetDefault("Sunken Slash");
			Main.projFrames[base.projectile.type] = 28;
		}

		public override void SetDefaults()
		{
			Mod CalamityMod = ModLoader.GetMod("CalamityMod");
			if (CalamityMod != null)
			{
				base.projectile.width = 148;
				base.projectile.height = 68;
				base.projectile.friendly = true;
				base.projectile.penetrate = -1;
				base.projectile.tileCollide = false;
				base.projectile.melee = true;
				base.projectile.ownerHitCheck = true;
				base.projectile.usesLocalNPCImmunity = true;
				base.projectile.localNPCHitCooldown = 5;
			}
		}

		public override void AI()
		{
			Player player = Main.player[base.projectile.owner];
			float num = 0f;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter);
			if (base.projectile.spriteDirection == -1)
			{
				num = (float)Math.PI;
			}
			if (++base.projectile.frame >= Main.projFrames[base.projectile.type])
			{
				base.projectile.frame = 0;
			}
			base.projectile.soundDelay--;
			if (base.projectile.soundDelay <= 0)
			{
				Main.PlaySound(SoundID.Item15, base.projectile.Center);
				base.projectile.soundDelay = 24;
			}
			if (Main.myPlayer == base.projectile.owner)
			{
				if (player.channel && !player.noItems && !player.CCed)
				{
					float scaleFactor6 = 1f;
					if (player.inventory[player.selectedItem].shoot == base.projectile.type)
					{
						scaleFactor6 = player.inventory[player.selectedItem].shootSpeed * base.projectile.scale;
					}
					Vector2 vector2 = Main.MouseWorld - vector;
					vector2.Normalize();
					if (vector2.HasNaNs())
					{
						vector2 = Vector2.UnitX * player.direction;
					}
					vector2 *= scaleFactor6;
					if (vector2.X != base.projectile.velocity.X || vector2.Y != base.projectile.velocity.Y)
					{
						base.projectile.netUpdate = true;
					}
					base.projectile.velocity = vector2;
				}
				else
				{
					base.projectile.Kill();
				}
			}
			Vector2 vector3 = base.projectile.Center + base.projectile.velocity * 3f;
			Lighting.AddLight(vector3, 0.2f, 0.2f, 3f);
			if (Main.rand.NextBool(3))
			{
				int num2 = Dust.NewDust(vector3 - base.projectile.Size / 2f, base.projectile.width, base.projectile.height, 99, base.projectile.velocity.X, base.projectile.velocity.Y, 100, default(Color), 2f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].position -= base.projectile.velocity;
			}
			base.projectile.position = player.RotatedRelativePoint(player.MountedCenter) - base.projectile.Size / 2f;
			base.projectile.rotation = base.projectile.velocity.ToRotation() + num;
			base.projectile.spriteDirection = base.projectile.direction;
			base.projectile.timeLeft = 2;
			player.ChangeDir(base.projectile.direction);
			player.heldProj = base.projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(base.projectile.velocity.Y * (float)base.projectile.direction, base.projectile.velocity.X * (float)base.projectile.direction);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(0, 0, 200, 0);
		}
	}
}