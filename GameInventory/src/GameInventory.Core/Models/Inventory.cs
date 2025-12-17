using System.Collections.Generic;
using System.Linq;
using GameInventory.Core.Interfaces;

namespace GameInventory.Core.Models
{
    // класс инвентаря
    public class Inventory : IInventory
    {
        private readonly List<IItem> _items = new();

        // свойства
        public int Capacity { get; }
        public float CurrentWeight { get; private set; }
        public float MaxWeight { get; }

        // конструктор
        public Inventory(int capacity = 20, float maxWeight = 100f)
        {
            Capacity = capacity;
            MaxWeight = maxWeight;
        }

        // методы

        // 1. добавляем предмет, если в инвентаре есть место
        // и можно застакать, либо взять новый слот
        public bool AddItem(IItem item)
        {
            if (item == null) return false;
            if (CurrentWeight + item.Weight > MaxWeight) return false;
            foreach (var existingItem in _items)
            {
                if (existingItem.CanStackWith(item))
                {
                    CurrentWeight += item.Weight;
                    existingItem.CurrentStack += item.CurrentStack;
                    return true;
                }
            }
            // если не стакается
            if (_items.Count >= Capacity) return false;
            // если дошли досюда, просто добавляем новый слот
            _items.Add(item);
            CurrentWeight += item.Weight;
            return true;
        }

        // 2. удаление предметов по ID
        public bool RemoveItem(string itemId, int count = 1)
        {
            var item = GetItem(itemId);
            if (item == null) return false;
            // если в стаке больше предметов, чем надо удалить
            if (item.CurrentStack > count)
            {
                item.CurrentStack -= count;
                CurrentWeight -= item.Weight * count;
                return true;
            }

            // иначе удаляем полностью
            _items.Remove(item);
            CurrentWeight -= item.Weight * count;
            return true;
        }

        // 3. получение предмета по ID
        public IItem GetItem(string itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId);
        }

        // 4. получение копии списка инвентаря
        public List<IItem> GetAllItems()
        {
            return new List<IItem>(_items);
        }

        // 5. очистка инвентаря
        public void Clear()
        {
            CurrentWeight = 0;
            _items.Clear();
        }

        // 6. подсчет общего количества предметов в инвентаре
        public int GetItemCount()
        {
            return _items.Sum(item => item.CurrentStack);
        }

        // 7. подсчет количества конкретного предмета
        public int GetItemCount(string itemId)
        {
            return _items
            .Where(item => itemId == item.Id)
            .Sum(item => item.CurrentStack);
        }

        // 8. поместится ли новый предмет в инвентарь?
        public bool HasSpaceFor(IItem item)
        {
            if (item == null) return false;
            if (CurrentWeight + item.Weight > MaxWeight) return false;
            if (_items.Any(i=>i.CanStackWith(item))) return true;
            return _items.Count < Capacity;
        }

        // 9. информация об инвентаре
        public string GetInfo()
        {
            return $"количество предметов: {GetItemCount()}, заполнено {CurrentWeight}/{MaxWeight} кг";
        }
    }
}