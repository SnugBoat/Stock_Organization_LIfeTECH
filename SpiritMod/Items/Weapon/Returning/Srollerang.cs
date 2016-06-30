using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Returning
{
	public class Srollerang : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodenBoomerang);
            item.name = "Srollerang";                      
            item.damage = 25;                            
            item.value = 100;
            item.rare = 4;
            item.knockBack = 2;
            item.useStyle = 5;
            item.useAnimation = 25;
            item.useTime = 27;
            item.shoot = mod.ProjectileType("SrollerangProjectile"); 
 
        }
		    }
}