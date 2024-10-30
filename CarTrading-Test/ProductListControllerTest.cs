using CarTrading.Controllers;
namespace CarTrading_Test
{
    public class ProductListControllerTest
    {
        [Fact]
        public void Test1()
        {
            var controller = new ProductListController(null); //Arrange
            var result = controller.GetMyNameRight(); //Act
            Assert.Equal("Nicolas", result); //Assert
        }
        [Fact]
        public void Test2()
        {
            var controller = new ProductListController(null);
            Assert.Equal(11, controller.AddNumbers(8, 3));
            Assert.Equal(-5, controller.AddNumbers(8, -3));
            Assert.Equal(-121, controller.AddNumbers(4, -125));
            Assert.Equal(-1, controller.AddNumbers(0, 0));
        }
    }
}