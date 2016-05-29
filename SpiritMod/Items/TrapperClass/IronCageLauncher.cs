using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.TrapperClass
{
    public class IronCageLauncher : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Iron Bubble Launcher";     
            item.damage = 10;   
            item.magic = true;
            item.mana = 1;        
            item.width = 52;       
            item.height = 24;         
            item.useTime = 2;  
            item.useAnimation = 2;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 0;
            item.value = 1000;
            item.rare = 1;
            item.autoReuse = true;
            item.useTurn = true;
            item.shoot = mod.ProjectileType("IronCageLauncherProjectile");
            item.shootSpeed = 0.0f;
            item.useAmmo = ProjectileID.None;
        }
    }
}