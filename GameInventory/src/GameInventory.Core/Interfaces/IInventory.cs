using System.Collections.Generic;

namespace GameInventory.Core.Interfaces
{
    // интерфейс для инвентаря
    public interface IInventory
    {
        // методы
        bool AddItem(IItem item);
        bool RemoveItem(string itemId, int count = 1);
        IItem GetItem(string itemId);
        List<IItem> GetAllItems();
        void Clear();

        // информация
        int GetItemCount();
        int GetItemCount(string itemId);
        bool HasSpaceFor(IItem item);
        string GetInfo();

        // свойства
        int Capacity { get; }
        float CurrentWeight { get; }
        float MaxWeight { get; }
    }
}