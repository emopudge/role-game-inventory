namespace GameInventory.Core.Interfaces
{
    // интерфейс для состояния предмета
    public interface IItemState
    {
        IItemState Equip();
        IItemState Unequip();
        bool CanUse();
        string Status { get; }
    }
}