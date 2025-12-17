using GameInventory.Core.Interfaces;
using System;

namespace GameInventory.Core.States
{
    // состояние: предмет не надет
    public class UnequippedState: IItemState
    {
        public string Status => "не надет";
        public IItemState Equip()
        {
            Console.WriteLine("экипирую предмет...");
            return new EquippedState();
        }
        public IItemState Unequip()
        {
            Console.WriteLine("предмет уже снят!");
            return this;
        }
        public bool CanUse()
        {
            return false;
        }
    }
}