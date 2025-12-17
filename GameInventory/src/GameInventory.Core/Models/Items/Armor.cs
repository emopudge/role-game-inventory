using GameInventory.Core.Interfaces;

namespace GameInventory.Core.Models.Items
{
    // класс брони
    public class Armor : ItemBase, IEquippable
    {
        // особые свойства брони
        public int Defense { get; private set; }
        public bool IsEquipped { get; private set; }

        // конструктор
        public Armor(
            string id, 
            string name,
            int defense,
            string description = "обычная броня", 
            float weight = 5.0f,
            int value = 80,
            ItemRarity rarity = ItemRarity.Common)
            : base(id, name, description, weight, value, rarity, maxStackSize: 1)

        {
            Defense = defense;
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

        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            string weaponInfo = $"\nЗащита: {Defense}\n";
            weaponInfo += $"Экипировано: {(IsEquipped ? "Да" : "Нет")}";
            
            return baseInfo + weaponInfo;
        }

    }
}