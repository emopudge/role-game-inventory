using Xunit;
using GameInventory.Core.Builders;
using GameInventory.Core.Models.Items;

namespace GameInventory.Tests.Patterns
{
    public class BuilderTests
    {
        [Fact]
        // 1. оружие создается
        public void BuildWeapon_WithNameAndDamage_ShouldCreateWeapon()
        {
            var builder = new ItemBuilder();
            
            var sword = builder
                .SetName("Стальной меч")
                .SetDamage(15)
                .BuildWeapon();
            
            Assert.Equal("Стальной меч", sword.Name);
            Assert.Equal(15, sword.Damage);
            Assert.Equal(3.0f, sword.Weight); // вес по умолчанию
            Assert.Equal(50, sword.Value);    // цена по умолчанию
        }
        
        [Fact]
        // 2. брооня создается
        public void BuildArmor_WithDefense_ShouldCreateArmor()
        {
            var armor = new ItemBuilder()
                .SetName("Кожаный доспех")
                .SetDefense(10)
                .BuildArmor();
            
            Assert.Equal("Кожаный доспех", armor.Name);
            Assert.Equal(10, armor.Defense);
        }
        
        [Fact]
        // 3. зелье создается 
        public void BuildPotion_ShouldCreatePotion()
        {
            var potion = new ItemBuilder()
                .SetName("Зелье здоровья")
                .SetHealAmount(30)
                .BuildPotion();
            
            Assert.Equal("Зелье здоровья", potion.Name);
            Assert.Equal(30, potion.HealAmount);
        }
    }
}