using System;
using GameInventory.Core.Interfaces;


// базовый абстрактный класс предметов инвентаря. 
// нельзя создать экземпляр напрямую, наследуемся от интерфейса
namespace GameInventory.Core.Models.Items
    {
    public abstract class ItemBase : IItem
    {
        // свойства (как в интерфейсе, но с реализацией)
        public string Id { get; protected set; } // get публичный для всех, а set только для наследников
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public float Weight { get; protected set; }
        public int Value { get; protected set; }
        public ItemRarity Rarity { get; protected set; }
        public int MaxStackSize { get; protected set; }
        public int CurrentStack { get; set; }

        // конструктор
        protected ItemBase(
            string id,
            string name,
            string description,
            float weight,
            int value,
            ItemRarity rarity,
            int maxStackSize = 1 // по дефолту 1
        )
        {
            Id = id;
            Name = name;
            Description = description;
            Weight = weight;
            Value = value;
            Rarity = rarity;
            MaxStackSize = maxStackSize;
            CurrentStack = 1; // при создании 1 предмет в стаке
        }

        // методы
        public virtual bool CanStackWith(IItem other) // виртуальный - можно переопределить (override)
        {
            if (other == null) return false; // если другого предмета нет, нельзя

            // иначе если верны все условия, то можно
            bool sameType = other.GetType() == this.GetType();
            bool sameId = other.Id == this.Id;
            bool fitsInStack = (this.CurrentStack + other.CurrentStack) <= this.MaxStackSize;
            return sameType && sameId && fitsInStack;
        }

        public virtual string GetInfo()
        {
            string info = $"{Name} ({Rarity})\n";
                info += $"Вес: {Weight}\n";
                info += $"Цена: {Value} золота\n";
                info += $"В стаке: {CurrentStack}/{MaxStackSize}\n";
                info += $"Описание: {Description}";
                
                return info;
        }

        public override string ToString() // для отладки - имя и количество
        {
            return $"{Name}, {CurrentStack}";
        }
    }
}