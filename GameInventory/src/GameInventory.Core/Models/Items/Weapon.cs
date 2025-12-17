using GameInventory.Core.Interfaces;
using System;

namespace GameInventory.Core.Models.Items
    {
    public class Weapon : ItemBase, IEquippable // наследование от базового класса и интерфейса 
    {
        // особые свойства оружия
        public int Damage { get; private set; } // только этот класс может менять свойство
        public bool IsEquipped {get; private set;}
        
        // конструктор
        public Weapon( // принимает параметры на ввод
            string id,
            string name,
            int damage,
            string description = "обычное оружие", // по дефолту
            float weight = 3.0f,
            int value = 50,
            ItemRarity rarity = ItemRarity.Common)
            // передает их в конструктор базового класса
            : base(id, name, description, weight, value, rarity, maxStackSize: 1) // оружие не стакается
        {
            Damage = damage;
            IsEquipped = false;
        }

        // методы
        public void Equip()
        {
            IsEquipped = true;
        }

        public void Unequip()
        {
            IsEquipped = false;
        }

        public void EnhanceDamage(int newDamage)
        {
            if (newDamage > Damage)
            {
                Damage = newDamage;
                Console.WriteLine($"{Name} улучшен: урон {Damage} → {newDamage}");
            }
        }

        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            string weaponInfo = $"\nУрон: {Damage}\n";
            weaponInfo += $"Экипировано: {(IsEquipped ? "Да" : "Нет")}";
            
            return baseInfo + weaponInfo;
        }
        
    }
}