using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
	public class IronNetLauncher : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Iron Net Launcher";     
            item.damage = 6;   
            item.ranged = true;          
            item.width = 52;       
            item.height = 24;         
            item.useTime = 90;  
            item.useAnimation = 90;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 2;
            item.value = 1000;
            item.rare = 1;
            item.useSound = 12;
            item.shoot = mod.ProjectileType("IronNetLauncherProjectile");
            item.shootSpeed = 0.001f;
            item.useAmmo = ProjectileID.None;
        }
    }
}