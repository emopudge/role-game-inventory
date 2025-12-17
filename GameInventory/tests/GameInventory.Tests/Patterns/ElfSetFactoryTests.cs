using Xunit;
using GameInventory.Core.Factories;

namespace GameInventory.Tests.Patterns
{
    // тесты для фабрики оружия эльфов
    public class ElfSetFactoryTests
    {
        [Fact]
        public void Factory_ShouldBuild()
        {
            var factory = new ElfSetFactory();

            var weapon = factory.CreateWeapon();
            var armor = factory.CreateArmor();

            Assert.Equal(weapon.Name, "клинок эльфа");
            Assert.Equal(weapon.Weight, 2.0f);
            Assert.Equal(armor.Defense, 20);
            Assert.Equal(armor.Description, "легкие и прочные");
        }
    }
}