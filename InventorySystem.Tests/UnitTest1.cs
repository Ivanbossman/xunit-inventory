using Xunit;
using InventorySystem;

namespace InventorySystem.Tests
{
    public class InventoryOrderServiceTests
    {
        [Fact]
        public void ProcessOrder_ValidOrder_ReturnsTotal()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            service.AddProduct("Laptop", 1000m, 10);

            // Act
            decimal result = service.ProcessOrder("Laptop", 2);

            // Assert
            Assert.Equal(2000m, result);
        }
    }
}