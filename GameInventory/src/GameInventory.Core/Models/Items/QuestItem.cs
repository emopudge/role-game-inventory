using System;
using GameInventory.Core.Interfaces;

namespace GameInventory.Core.Models.Items
{
    // класс квестовых предметов
    public class QuestItem : ItemBase
    {
        // айди квеста, для которого нужен предмет
        public string QuestId { get; private set; }

        // конструктор
        public QuestItem(
            string id,
            string name,
            string questId,
            string description = "квестовый предмет",
            float weight = 1.0f,
            int value = 0,
            ItemRarity rarity = ItemRarity.Common)
            : base(id, name, description, weight, value, rarity)
        {
            QuestId = questId;
        }

        // методы
        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            string questInfo = $"\nквест: {QuestId}";

            return baseInfo + questInfo;
        }
    }
}