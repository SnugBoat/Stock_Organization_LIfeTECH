using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class Li : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "The Gigazapper";
			item.damage = 88;
			item.melee = true;
			item.width = 36;
			item.height = 36;
            item.useTime = 17;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.useStyle = 1;
			item.knockBack = 5;
			item.rare = 7;
			item.useSound = 19;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("GigazapperProj");
			item.shootSpeed = 56f;
		}
    }
}
