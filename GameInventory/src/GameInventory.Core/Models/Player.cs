using System;
using GameInventory.Core.Interfaces;

namespace GameInventory.Core.Models
{
    // класс игрока
    public class Player
    {
        // свойства
        public string Name { get; }
        public IInventory Inventory { get; }

        // конструктор
        public Player(string name)
        {
            Name = name;
            Inventory = new Inventory();
        }

        // метод: получить информацию
        public string GetInfo()
        {
            return $"имя: {Name}, инвентарь: {Inventory.GetInfo()}";
        }
    }
}