using System;
using GameInventory.Core.Interfaces;
using GameInventory.Core.Builders;
using GameInventory.Core.Models.Items;

namespace GameInventory.Core.Factories
{
    // фабрика для создания эльфийского набора оружия и брони
    public class ElfSetFactory : IItemSetFactory
    {
        // унаследованные методы
        public string SetName => "эльфийский набор";
        public Weapon CreateWeapon()
        {            
            return new ItemBuilder()
            .SetName("клинок эльфа")
            .SetDamage(20)
            .SetWeight(2.0f)
            .SetValue(300)
            .SetRarity(ItemRarity.Rare)
            .SetDescription("изящный и острый")
            .BuildWeapon();
        }
        public Armor CreateArmor()
        {
            return new ItemBuilder()
                .SetName("эльфийские доспехи")
                .SetDefense(20)
                .SetDescription("легкие и прочные")
                .SetWeight(4.0f)
                .SetValue(400)
                .SetRarity(ItemRarity.Rare)
                .BuildArmor();
        }

    }
}