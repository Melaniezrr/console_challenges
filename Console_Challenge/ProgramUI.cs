using System;
using System.Collections.Generic;

namespace Console_Challenge
{

    public class ProgramUI
    {
        // init repos
        MealRepo mealRepo = new MealRepo();

        public void Run()
        {
            Console.WriteLine("Welcome to the Cafe");
            MainMenu();
        }

        private void MainMenu()
        {
            Console.WriteLine("Select an Option: \n" +
                "1. Add Meal \n" +
                "2. Delete Meal \n" +
                "3. List Meals \n" +
                "3. Exit");
            string input = Console.ReadLine();
            bool wasSuccessful;
            string number;
            string name;
            string description;
            string price;
            List<String> ingredients = new List<string>();


            switch (input)
            {
                case "1":
                    // Add Meal
                    Console.WriteLine("Enter a Meal Number: ");
                    number = Console.ReadLine();
                    Console.WriteLine("Enter a Meal Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter a Description: ");
                    description = Console.ReadLine();
                    Console.WriteLine("Enter a price: ");
                    price = Console.ReadLine();


                    Meal newmeal = new Meal(number, name, description, ingredients, price);

                    mealRepo.AddMeal(newmeal);
                    MainMenu();
                    break;
                case "2":
                    // Remove Meal
                    Console.WriteLine("Remove a Meal by ID: ");
                    number = Console.ReadLine();

                    wasSuccessful = mealRepo.RemoveMealFromList(number);
                    Console.WriteLine("Your removal was successful? :" + wasSuccessful);
                    MainMenu();
                    break;
                case "3":
                    // List Meals
                    List<Meal> meals = mealRepo.GetMealList();
                    Console.WriteLine(meals.Count);
                    if (meals.Count > 0)
                    {
                        foreach (Meal meal in meals)
                        {
                            Console.WriteLine(meal.Number + " | " + meal.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No meals yet. Please create one.");
                    }
                    MainMenu();
                    break;
                
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please make a different selection.");
                    MainMenu();
                    break;
            }
        }
    }
}
