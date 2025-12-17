using Xunit;
using GameInventory.Core.States;
using GameInventory.Core.Interfaces;
using GameInventory.Core.Models;
using GameInventory.Core.Models.Items;

namespace GameInventory.Tests
{
    public class StateTests
    {
        // тесты для состояний
        [Fact] public void UnequippedState_Status_ShouldBeCorrect() => 
            Assert.Equal("не надет", new UnequippedState().Status);
        
        [Fact] public void EquippedState_Status_ShouldBeCorrect() => 
            Assert.Equal("надет", new EquippedState().Status);
        
        [Fact] public void UnequippedState_CanUse_ShouldReturnFalse() => 
            Assert.False(new UnequippedState().CanUse());
        
        [Fact] public void EquippedState_CanUse_ShouldReturnTrue() => 
            Assert.True(new EquippedState().CanUse());
        
        [Fact]
        public void UnequippedState_Equip_ShouldReturnEquippedState()
        {
            var state = new UnequippedState();
            Assert.IsType<EquippedState>(state.Equip());
        }
        
        [Fact]
        public void EquippedState_Unequip_ShouldReturnUnequippedState()
        {
            var state = new EquippedState();
            Assert.IsType<UnequippedState>(state.Unequip());
        }
        
        // тесты для EquippableItem
        [Fact]
        public void EquippableItem_Constructor_ShouldStartWithUnequippedState()
        {
            var sword = new Weapon("sword1", "Меч", 10);
            var equippable = new EquippableItem(sword);
            
            Assert.IsType<UnequippedState>(equippable.CurrentState);
        }
        
        [Fact]
        public void EquippableItem_Equip_ShouldChangeState()
        {
            var sword = new Weapon("sword1", "Меч", 10);
            var equippable = new EquippableItem(sword);
            
            equippable.Equip();
            
            Assert.IsType<EquippedState>(equippable.CurrentState);
            Assert.True(sword.IsEquipped);
        }
        
        [Fact]
        public void EquippableItem_EquipThenUnequip_ShouldWork()
        {
            var sword = new Weapon("sword1", "Меч", 10);
            var equippable = new EquippableItem(sword);
            
            equippable.Equip();
            equippable.Unequip();
            
            Assert.IsType<UnequippedState>(equippable.CurrentState);
            Assert.False(sword.IsEquipped);
        }
        
        [Fact]
        public void EquippableItem_ToString_ShouldShowStatus()
        {
            var sword = new Weapon("sword1", "Меч", 10);
            var equippable = new EquippableItem(sword);
            
            Assert.Contains("(не надет)", equippable.ToString());
            
            equippable.Equip();
            Assert.Contains("(надет)", equippable.ToString());
        }
    }
}