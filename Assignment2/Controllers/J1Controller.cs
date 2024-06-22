using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
    [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public String CalculateTotalCalories(int burger, int drink, int side, int dessert)
        {
            // Defining calorie values for each menu item
            int[] burgerCalories = { 461, 431, 420, 0 };  // last one is for "no burger"
            int[] drinkCalories = { 130, 160, 118, 0 };  // last one is for "no drink"
            int[] sideCalories = { 100, 57, 70, 0 };     // last one is for "no side order"
            int[] dessertCalories = { 167, 266, 75, 0 }; // last one is for "no dessert"

            // Validate input indices
            if (burger < 1 || burger > 4 || drink < 1 || drink > 4 || side < 1 || side > 4 || dessert < 1 || dessert > 4)
            {
                return "Invalid menu choice. Choices must be between 1 and 4.";
            }

            // Calculate total calories
            int totalCalories = burgerCalories[burger - 1] + drinkCalories[drink - 1] +
                                sideCalories[side - 1] + dessertCalories[dessert - 1];

            // Return the result
            return $"Your total calorie count is {totalCalories}";
        }
    }
}