using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST100700933PROGP2
{
    class Recipe  //Contains a list of ingredients and steps
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public int TotalCalories { get; private set; }
        public double ScaleFactor { get; private set; } 

        public Recipe(string name, List<Ingredient> ingredients, List<Step> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
            TotalCalories = CalculateTotalCalories();
        }

        private int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public void Scale(double scaleFactor)// This is used to adjust ingredient quantities and associated calories in a recipe based on a specified scale factor
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
                ingredient.Calories = (int)(ingredient.Calories * scaleFactor);
            }

            TotalCalories = CalculateTotalCalories();
            ScaleFactor = scaleFactor; // Update the scale factor
        }
        public void ResetQuantities()//this is used to reset the quantities of a specified recipe 
        {
            foreach (Ingredient ingredient in Ingredients)
            {              
                ingredient.Quantity /= ScaleFactor;           
                ingredient.Calories = (int)(ingredient.Calories / ScaleFactor);
            }
            TotalCalories = CalculateTotalCalories();
            ScaleFactor = 1.0; 
        }
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////END/////////////////////////////////////////////////////////////