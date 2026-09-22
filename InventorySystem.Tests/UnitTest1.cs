using InventorySystem;
using Xunit;

namespace InventorySystem.Tests
{
    public class InventoryOrderServiceTests
    {
        [Fact]
        public void ProcessOrder_ValidOrder_ReturnsCorrectTotal()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            service.AddProduct(new Product
            {
                Id = "P100",
                Name = "Keyboard",
                UnitPrice = 100m,
                StockQuantity = 10
            });

            // Act
            OrderResult result = service.ProcessOrder("P100", 2, 0.05m);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(210m, result.TotalCost);
        }


        [Fact]
        public void ProcessOrder_TenItems_AppliesTenPercentDiscount()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            service.AddProduct(new Product
            {
                Id = "P101",
                Name = "Mouse",
                UnitPrice = 100m,
                StockQuantity = 20
            });

            // Act
            OrderResult result = service.ProcessOrder("P101", 10, 0m);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(900m, result.TotalCost);
        }



    }
}