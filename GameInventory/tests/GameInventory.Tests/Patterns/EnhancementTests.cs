using Xunit;
using GameInventory.Core.Strategies;
using GameInventory.Core.Models.Items;

namespace GameInventory.Tests.Patterns
{
    public class WeaponEnhancerTests
    {
        [Fact]
        public void BasicEnhancer_ShouldIncreaseDamageBy10()
        {
            // arrange
            var enhancer = new BasicWeaponEnhancer();
            var sword = new Weapon("sword1", "Меч", 20);
            
            // act
            enhancer.Enhance(sword);
            
            // assert
            Assert.Equal(30, sword.Damage); 
        }
        
        [Fact]
        public void MagicEnhancer_ShouldIncreaseDamageBy50Percent()
        {
            var enhancer = new MagicWeaponEnhancer();
            var sword = new Weapon("sword1", "Меч", 100);
            
            enhancer.Enhance(sword);
            
            Assert.Equal(150, sword.Damage); 
        }
    }
}