using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace ST10007933PROGP2.Test
{
    [TestClass]
    public class UIDisplayRecipeDetailsTests
    {
        private Mock<RecipeManager> mockRecipeManager;
        private StringWriter consoleOutput;

        [TestInitialize]
        public void Setup()
        {
            mockRecipeManager = new Mock<RecipeManager>();
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [TestCleanup]
        public void Cleanup()
        {
            consoleOutput.Dispose();
            Console.SetOut(Console.Out);
        }

        [TestMethod]
        public void DisplayRecipeDetails_WhenCaloriesExceed300_ShouldDisplayWarning()
        {
            // Arrange
            var recipe = new Recipe
            {
                Name = "HighCalorieRecipe",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Sugar", Quantity = 200, Unit = "grams", Calories = 400, FoodGroup = "Carbohydrate" }
                },
                Steps = new List<Step>
                {
                    new Step { Description = "Mix ingredients" }
                },
                TotalCalories = 400
            };

            mockRecipeManager.Setup(rm => rm.GetRecipeByName("HighCalorieRecipe")).Returns(recipe);

            var ui = new UI(mockRecipeManager.Object);

            // Act
            using (var sr = new StringReader("HighCalorieRecipe\n"))
            {
                Console.SetIn(sr);
                ui.DisplayRecipeDetails();
            }

            // Assert
            var output = consoleOutput.ToString();
            StringAssert.Contains(output, "Total calories: 400");
            StringAssert.Contains(output, "WARNING: Recipe exceeds 300 calories!");
        }

        [TestMethod]
        public void DisplayRecipeDetails_WhenCaloriesNotExceed300_ShouldNotDisplayWarning()
        {
            // Arrange
            var recipe = new Recipe
            {
                Name = "LowCalorieRecipe",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Lettuce", Quantity = 100, Unit = "grams", Calories = 50, FoodGroup = "Vegetable" }
                },
                Steps = new List<Step>
                {
                    new Step { Description = "Chop and mix ingredients" }
                },
                TotalCalories = 50
            };

            mockRecipeManager.Setup(rm => rm.GetRecipeByName("LowCalorieRecipe")).Returns(recipe);

            var ui = new UI(mockRecipeManager.Object);

            // Act
            using (var sr = new StringReader("LowCalorieRecipe\n"))
            {
                Console.SetIn(sr);
                ui.DisplayRecipeDetails();
            }

            // Assert
            var output = consoleOutput.ToString();
            StringAssert.Contains(output, "Total calories: 50");
            Assert.IsFalse(output.Contains("WARNING: Recipe exceeds 300 calories!"));
        }
    }
}