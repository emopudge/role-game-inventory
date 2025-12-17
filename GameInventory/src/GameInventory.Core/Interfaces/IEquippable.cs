using System;

namespace GameInventory.Core.Interfaces
{
    // интерфейс для предметов, которые можно надеть или экипировать
    public interface IEquippable
    {
        void Equip();
        void Unequip();
        bool IsEquipped { get; }
    }
}