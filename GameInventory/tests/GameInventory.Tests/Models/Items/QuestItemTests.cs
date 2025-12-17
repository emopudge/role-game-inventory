using Xunit;
using GameInventory.Core.Models.Items;

namespace GameInventory.Tests.Models.Items
{
    public class QuestItemTests
    {
        // ТЕСТ 1: предмет создается
        [Fact]
        public void CreateQuestItem()
        {
            var questItem = new QuestItem("item1", "пончик", "quest1", "за ним посылает новичка-полицейского его напарник");

            Assert.Equal(questItem.Name, "пончик");
        }
    }
}