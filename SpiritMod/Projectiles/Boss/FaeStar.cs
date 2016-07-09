using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
	public class FaeStar : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(82);
			projectile.hostile = true;
			projectile.magic = true;
			projectile.width = 32;
			projectile.light = 0.5f;
			projectile.height = 32;
			projectile.friendly = false;
			projectile.name = "Fae Star";
			projectile.damage = 10;
			
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			}
			for (int I = 0; I < 15; I++)
				{
				//	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CrystalDust"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
			return false;
		}
	
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			}
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}