using System;
using System.Collections.Generic;

namespace Console_Challenge
{
    public class Meal
    {
        public string Number;
        public string Name;
        public string Description;
        public List<String> Ingredients;
        public string Price;

        public Meal(string number, string name, string description, List<String> ingredients, string price)
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
