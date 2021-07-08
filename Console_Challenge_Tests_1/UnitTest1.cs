using System;
using System.Configuration;
using Xunit;
using System.Collections.Generic;

using Console_Challenge;

namespace Console_Challenge_Tests_1
{
    public class UnitTest1
    {
        [Fact]
        public void AddMealTest()
        {
            // Arrange
            List<String> ingredients = new List<String>("Ingredient1");
            MealRepo mealRepo = new MealRepo();
            Meal meal = new Meal("1", "Item 1", "Item Description", ingredients, "5.00");

            List<Meal> expected = new List<Meal>(meal);
            // Act
            mealRepo.add(meal);

            // Assert
            List<Meal> actual = mealRepo.GetMealList();
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}
