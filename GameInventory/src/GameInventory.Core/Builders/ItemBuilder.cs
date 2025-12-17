using GameInventory.Core.Models.Items;
using GameInventory.Core.Interfaces;

namespace GameInventory.Core.Builders
{
    // порождающий паттерн Builder для пошагового создания предметов
    public class ItemBuilder
    {
        // общие свойства (для всех предметов)
        private string _name = "предмет";
        private string _description = "";
        private float _weight = 3.0f;
        private int _value = 50;
        private ItemRarity _rarity = ItemRarity.Common;

        // специальные свойства (для конкретных типов)
        private int _damage = 10;
        private int _defense = 5;
        private int _healAmount = 20;
        private int _counter = 0;

        // методы задания свойств        
        public ItemBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ItemBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public ItemBuilder SetWeight(float weight)
        {
            _weight = weight;
            return this;
        }

        public ItemBuilder SetValue(int value)
        {
            _value = value;
            return this;
        }

        public ItemBuilder SetRarity(ItemRarity rarity)
        {
            _rarity = rarity;
            return this;
        }

        public ItemBuilder SetDamage(int damage)
        {
            _damage = damage;
            return this;
        }

        public ItemBuilder SetDefense(int defense)
        {
            _defense = defense;
            return this;
        }

        public ItemBuilder SetHealAmount(int healAmount)
        {
            _healAmount = healAmount;
            return this;
        }

        // методы создания предметов

        public Weapon BuildWeapon()
        {
            _counter++;
            string id = $"weapon_{_counter}";

            return new Weapon(
                id: id,
                name: _name,
                damage: _damage,
                description: _description,
                weight: _weight,
                value: _value,
                rarity: _rarity
            );
        }

        public Armor BuildArmor()
        {
            _counter++;
            string id = $"armor_{_counter}";

            return new Armor(
                id: id,
                name: _name,
                defense: _defense,
                description: _description,
                weight: _weight,
                value: _value,
                rarity: _rarity
            );
        }

        public Potion BuildPotion()
        {
            _counter++;
            string id = $"potion_{_counter}";

            return new Potion(
                id: id,
                name: _name,
                healAmount: _healAmount,
                description: _description,
                weight: _weight,
                value: _value,
                rarity: _rarity,
                maxStackSize: 5
            );
        }
    }
}