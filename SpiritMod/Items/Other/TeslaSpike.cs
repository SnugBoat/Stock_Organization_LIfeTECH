using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Other
{
    public class TeslaSpike : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Tesla Spike";     
            item.damage = 57;   
            item.ranged = true;          
            item.width = 52;       
            item.height = 24;      
            item.toolTip = "Electriiiiiiiic";    
            item.useTime = 2;  
            item.useAnimation = 2;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 2;
            item.value = 10000;
            item.rare = 9;
            item.useSound = 12;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TeslaSpikeProjectile");
            item.shootSpeed = 16f;
            item.useAmmo = ProjectileID.None;
        }
    }
}