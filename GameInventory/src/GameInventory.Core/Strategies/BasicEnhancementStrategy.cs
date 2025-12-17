using GameInventory.Core.Interfaces;
using GameInventory.Core.Models.Items;

namespace GameInventory.Core.Strategies
{
    // простое улучшение: +10 урона
    public class BasicWeaponEnhancer : IEnhancementStrategy
    {
        public string Name => "Простое улучшение";
        public int Cost => 50;
        
        public void Enhance(Weapon weapon)
        {
            int newDamage = weapon.Damage + 10;
            weapon.EnhanceDamage(newDamage);
        }
    }
}