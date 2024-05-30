using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST100700933PROGP2
{
    class RecipeManager    //this class manages a list of recipes and has methods for adding, removing, and getting recipes.
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }

        public List<Recipe> GetRecipeList()
        {
            return recipes;
        }

        public Recipe GetRecipeByName(string name)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Name == name)
                {
                    return recipe;//Searches for recipts by name 
                }
            }
            return null;
        }
        public void ClearRecipes()// Clear the list of recipes
        {
            recipes.Clear(); 
        }
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////END/////////////////////////////////////////////////////////////