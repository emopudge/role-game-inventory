using System;
using GameInventory.Core.Models.Items;

namespace GameInventory.Core.Interfaces
{
    // интерфейс фабрики для создания наборов оружия и брони
    public interface IItemSetFactory
    {
        Weapon CreateWeapon();
        Armor CreateArmor();
        string SetName { get; }
    }
}