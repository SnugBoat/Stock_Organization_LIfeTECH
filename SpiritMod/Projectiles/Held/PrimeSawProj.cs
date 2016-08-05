using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
	public class PrimeSawProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Prime Saw";
			projectile.width = 20;
			projectile.height = 62;
			projectile.aiStyle = 20;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.hide = true;
			projectile.ownerHitCheck = true; 
			projectile.melee = true;
		}
	}
}