using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST100700933PROGP2
{
    class Ingredient   // defines the properties of an ingredient
    {
        public string Name { get; set; }//the name of the ingredient
        public double Quantity { get; set; }// quantity of the ingredient
        public string Unit { get; set; }//measurement for the quantity
        public int Calories { get; set; }//number of calories per the specified quantity of the ingredient
        public string FoodGroup { get; set; }//categorizes the ingredient into a food group
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////END/////////////////////////////////////////////////////////////