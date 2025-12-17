using GameInventory.Core.States;
using GameInventory.Core.Interfaces;
using GameInventory.Core.Models.Items;

namespace GameInventory.Core.Models
{
    public class EquippableItem
    {
        private IItem _item;
        private IItemState _state;
        
        public string Name => _item.Name;
        public IItemState CurrentState => _state;
        public IItem Item => _item;
        
        public EquippableItem(IItem item)
        {
            _item = item;
            _state = new UnequippedState();
        }
        
        public void Equip()
        {
            _state = _state.Equip();
            
            if (_item is IEquippable equippable)
            {
                equippable.Equip();
            }
        }
        
        public void Unequip()
        {
            _state = _state.Unequip();
            
            if (_item is IEquippable equippable)
            {
                equippable.Unequip();
            }
        }
        
        public bool CanUse()
        {
            return _state.CanUse();
        }
        
        public override string ToString()
        {
            return $"{_item.Name} ({_state.Status})";
        }
    }
}