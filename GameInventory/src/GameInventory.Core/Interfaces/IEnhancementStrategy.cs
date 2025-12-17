using GameInventory.Core.Models.Items;

namespace GameInventory.Core.Interfaces
{
    // интерфейс для улучшения оружия
    public interface IEnhancementStrategy
    {
        void Enhance(Weapon weapon);
        string Name { get; }
        int Cost { get; }
    }
}