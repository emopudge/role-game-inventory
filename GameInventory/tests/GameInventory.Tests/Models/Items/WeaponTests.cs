using Xunit;
using GameInventory.Core.Models.Items;

namespace GameInventory.Tests.Models.Items
{
    public class WeaponTests
    {
        // ТЕСТ 1: Оружие создается
        [Fact]
        public void CreateWeapon()
        {
            var sword = new Weapon("sword1", "Меч", 10);
            
            Assert.Equal("Меч", sword.Name);
            Assert.Equal(10, sword.Damage);
        }
        
        // ТЕСТ 2: Можно надеть оружие
        [Fact]
        public void EquipWeapon()
        {
            var sword = new Weapon("sword1", "Меч", 10);
            
            sword.Equip();
            
            Assert.True(sword.IsEquipped);
        }
        
        // ТЕСТ 3: Можно снять оружие
        [Fact]
        public void UnequipWeapon()
        {
            var sword = new Weapon("sword1", "Меч", 10);
            
            sword.Equip();
            sword.Unequip();
            
            Assert.False(sword.IsEquipped);
        }
        
        // ТЕСТ 4: Информация содержит урон
        [Fact]
        public void WeaponInfoShowsDamage()
        {
            var sword = new Weapon("sword1", "Меч", 15);
            
            string info = sword.GetInfo();
            
            Assert.Contains("Урон: 15", info);
        }
    }
}