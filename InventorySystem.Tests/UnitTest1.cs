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
        public void ProcessOrder_TwentyItems_AppliesTenPercentDiscount()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            service.AddProduct(new Product
            {
                Id = "P104",
                Name = "Mouse",
                UnitPrice = 10m,
                StockQuantity = 30
            });

            // Act
            OrderResult result = service.ProcessOrder("P104", 20, 0m);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(180m, result.TotalCost);
        }



        [Fact]
        public void ProcessOrder_ValidOrder_DeductsStock()
        {
            // Arrange
            InventoryOrderService service = new InventoryOrderService();

            service.AddProduct(new Product
            {
                Id = "P105",
                Name = "Monitor",
                UnitPrice = 200m,
                StockQuantity = 10
            });

            // Act
            service.ProcessOrder("P105", 3, 0m);
            Product product = service.GetProduct("P105");

            // Assert
            Assert.Equal(7, product.StockQuantity);
        }
    }
}