using System;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summoner
{
	public abstract class GenericMinion : ModProjectile
	{

		public override bool PreAI()
		{
			this.CheckActive();
			this.Behavior();
			this.SelectFrame();
			return false;
		}

		public virtual void CheckActive()
		{
		}

		public virtual void SelectFrame()
		{
		}

		public virtual void Behavior()
		{
		}
	}
}
