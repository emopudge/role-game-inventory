using Xunit;
using GameInventory.Core.Models;
using GameInventory.Core.Models.Items;

namespace GameInventory.Tests
{
    public class InventoryTests
    {
        [Fact]
        // 1. тест на добавление предмета
        public void AddItem_ShouldAdd()
        {
            var inventory = new Inventory();
            var sword = new Weapon("sword1", "Меч", 10);
            
            bool result = inventory.AddItem(sword);
            
            Assert.True(result);
            Assert.Equal(1, inventory.GetItemCount());
        }
        
        [Fact]
        // 2. проверка, что предметы стакаются
        public void AddItem_TwoPotions_ShouldStack()
        {
            var inventory = new Inventory();
            var potion1 = new Potion("potion1", "Зелье", 50, maxStackSize: 5);
            var potion2 = new Potion("potion1", "Зелье", 50, maxStackSize: 5);
            
            inventory.AddItem(potion1);
            bool result = inventory.AddItem(potion2);
            
            Assert.True(result);
            Assert.Equal(2, inventory.GetItemCount("potion1"));
        }
        
        [Fact]
        // 3. ошибка при добавлении в полный инвентарь
        public void AddItem_WhenFull_ShouldFail()
        {
            var inventory = new Inventory(capacity: 1);
            var sword1 = new Weapon("sword1", "Меч", 10);
            var sword2 = new Weapon("sword2", "Топор", 15);
            
            inventory.AddItem(sword1);
            bool result = inventory.AddItem(sword2);
            
            Assert.False(result);
        }
        
        [Fact]
        // 4. удаление предмета
        public void RemoveItem_ShouldWork()
        {
            var inventory = new Inventory();
            var sword = new Weapon("sword1", "Меч", 10);
            inventory.AddItem(sword);
            
            bool result = inventory.RemoveItem("sword1");
            
            Assert.True(result);
            Assert.Equal(0, inventory.GetItemCount());
        }
        
        [Fact]
        // 5. поиск предмета
        public void GetItem_ShouldFindItem()
        {
            var inventory = new Inventory();
            var sword = new Weapon("sword1", "Меч", 10);
            inventory.AddItem(sword);
            
            var item = inventory.GetItem("sword1");
            
            Assert.NotNull(item);
            Assert.Equal("Меч", item.Name);
        }
        
        [Fact]
        // 6. очистка
        public void Clear_ShouldEmpty()
        {
            var inventory = new Inventory();
            inventory.AddItem(new Weapon("sword1", "Меч", 10));
            
            inventory.Clear();
            
            Assert.Equal(0, inventory.GetItemCount());
        }
        
        [Fact]
        // 7. проверка на наличие места
        public void HasSpaceFor_ShouldReturnTrue()
        {
            var inventory = new Inventory();
            var sword = new Weapon("sword1", "Меч", 10);
            
            bool hasSpace = inventory.HasSpaceFor(sword);
            
            Assert.True(hasSpace);
        }
    }
}