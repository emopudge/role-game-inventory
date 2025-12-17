using System;

namespace GameInventory.Core.Interfaces 
    {
    public interface IItem // базовый интерфейс всех предметов в инвентаре
    {
        // свойства
        string Id { get; }
        string Name { get; }
        string Description { get; }
        float Weight { get; }
        int Value { get; }
        ItemRarity Rarity { get; }
        int MaxStackSize { get; }
        int CurrentStack { get; set; }

        // методы
        bool CanStackWith(IItem other); // можно ли застакать предмет с другим?
        string GetInfo(); 

    }

    public enum ItemRarity // нумерованный список уровней редкости предметов
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary

    }
}