using Xunit;
using GameInventory.Core.Models.Items;

namespace GameInventory.Tests.Models.Items
{
    public class ArmorTests
    {
        // ТЕСТ 1: броня создается
        [Fact]
        public void CreateArmor()
        {
            var armor = new Armor("armor1", "щит", 20);

            Assert.Equal("щит", armor.Name);
            Assert.Equal(20, armor.Defense);
        }

    }
}