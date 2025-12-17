using Xunit;
using GameInventory.Core.Models;

namespace GameInventory.Tests.Models
{
    public class PlayerTests
    {
        [Fact]
        public void Player_HasInventory()
        {
            var player = new Player("бэтмен");
            
            Assert.NotNull(player.Inventory);
            Assert.Equal("бэтмен", player.Name);
        }
    }
}