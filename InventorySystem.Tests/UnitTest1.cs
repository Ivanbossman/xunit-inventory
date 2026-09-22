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


        [Fact]
        public void ProcessOrder_FiftyItems_AppliesTwentyPercentDiscount()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            service.AddProduct(new Product
            {
                Id = "P102",
                Name = "Headphones",
                UnitPrice = 100m,
                StockQuantity = 60
            });

            // Act
            OrderResult result = service.ProcessOrder("P102", 50, 0m);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(4000m, result.TotalCost);
        }


        [Fact]
        public void ProcessOrder_ExactStockQuantity_Succeeds()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            service.AddProduct(new Product
            {
                Id = "P103",
                Name = "Monitor",
                UnitPrice = 200m,
                StockQuantity = 5
            });

            // Act
            OrderResult result = service.ProcessOrder("P103", 5, 0m);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1000m, result.TotalCost);
        }


        [Fact]
        public void ProcessOrder_UnknownProduct_ReturnsFailure()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            // Act
            OrderResult result = service.ProcessOrder("P999", 1, 0m);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Product not found.", result.Message);
        }


        [Fact]
        public void ProcessOrder_NegativeQuantity_ReturnsFailure()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            service.AddProduct(new Product
            {
                Id = "P104",
                Name = "Keyboard",
                UnitPrice = 100m,
                StockQuantity = 10
            });

            // Act
            OrderResult result = service.ProcessOrder("P104", -1, 0m);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Quantity must be positive.", result.Message);
        }
    }
}