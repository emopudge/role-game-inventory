using System;
using GameInventory.Core.Interfaces;

namespace GameInventory.Core.Models.Items
{
    public class Potion : ItemBase // класс зелий
    {
        // особое свойство зелий: лечение
        public int HealAmount { get; private set; }

        // конструктор
        public Potion(
            string id, 
            string name,
            int healAmount,
            string description = "целебное зелье",
            float weight = 0.5f,
            int value = 20,
            ItemRarity rarity = ItemRarity.Common,
            int maxStackSize = 5) // зелья можно стакать
            : base(id, name, description, weight, value, rarity, maxStackSize)
        {
            HealAmount = healAmount;
        }

        // методы
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            string potionInfo = $"\nлечение: {HealAmount} HP";

            return baseInfo + potionInfo;
        }
    }
}