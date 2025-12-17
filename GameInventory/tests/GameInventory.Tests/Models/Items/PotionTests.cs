using Xunit;
using GameInventory.Core.Models.Items;

namespace GameInventory.Tests.Models.Items
{
    public class PotionTests
    {
        // ТЕСТ 1: зелье создается
        [Fact]
        public void CreatePotion()
        {
            var potion = new Potion("potion1", "валерьянка", 5);

            Assert.Equal(potion.Name, "валерьянка");
            Assert.Equal(potion.HealAmount, 5);
        }
    }
}