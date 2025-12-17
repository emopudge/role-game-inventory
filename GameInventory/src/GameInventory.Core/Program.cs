using System;
using GameInventory.Core.Models.Items;

namespace GameInventory.Core
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("ТЕСТ ОРУЖИЯ");
            
            var sword = new Weapon("sword_001", "Меч", 10);
            Console.WriteLine(sword.GetInfo());
            
            Console.WriteLine("\nУРА");
        }
    }
}