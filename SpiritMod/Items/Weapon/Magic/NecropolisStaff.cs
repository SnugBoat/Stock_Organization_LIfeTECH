using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class NecropolisStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Necropolis Staff";
			item.damage = 76;
			item.magic = true;
			item.mana = 17;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 6;
			item.value = 0200;
			item.rare = 2;
			item.useSound = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NecropolisTrident");
			item.shootSpeed = 4f;
		}
	}
}