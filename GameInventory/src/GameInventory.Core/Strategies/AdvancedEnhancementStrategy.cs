using GameInventory.Core.Interfaces;
using GameInventory.Core.Models.Items;

namespace GameInventory.Core.Strategies
{
    // магическое улучшение: +50% урона
    public class MagicWeaponEnhancer : IEnhancementStrategy
    {
        public string Name => "Магическое зачарование";
        public int Cost => 200;
        
        public void Enhance(Weapon weapon)
        {
            int newDamage = (int)(weapon.Damage * 1.5); 
            weapon.EnhanceDamage(newDamage);
        }
    }
}