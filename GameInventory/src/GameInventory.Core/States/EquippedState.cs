using GameInventory.Core.Interfaces;
using System;

namespace GameInventory.Core.States
{
    // состояние: предмет надет
    public class EquippedState: IItemState
    {
        public string Status => "надет";
        public IItemState Equip()
        {
            Console.WriteLine("предмет уже экипирован!");
            return this;
        }
        public IItemState Unequip()
        {
            Console.WriteLine("снимаю предмет...");
            return new UnequippedState();
        }
        public bool CanUse()
        {
            return true;
        }
    }
}