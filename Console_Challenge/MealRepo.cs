using System;
using System.Collections.Generic;

namespace Console_Challenge
{
    public class MealRepo
    {
        private List<Meal> _listOfMeals = new List<Meal>();

        // Create CRUD Methods

        // create
        public void AddMeal(Meal Meal)
        {
            _listOfMeals.Add(Meal);
        }

        // read (list or get one)
        public List<Meal> GetMealList()
        {
            return _listOfMeals;
        }

        public Meal GetMeal(string number)
        {
            Meal dev = GetMealByNumber(number);
            return dev;
        }

        // delete
        public bool RemoveMealFromList(string number)
        {
            Meal Meal = GetMealByNumber(number);
            if (Meal == null)
            {
                return false;
            }

            int initialCount = _listOfMeals.Count;
            _listOfMeals.Remove(Meal);

            return initialCount > _listOfMeals.Count;
        }

        // helper
        private Meal GetMealByNumber(string number)
        {
            foreach (Meal Meal in _listOfMeals)
            {
                if (Meal.Number == number)
                {
                    return Meal;
                }

                return null;
            }

            return null;
        }
    }
}
