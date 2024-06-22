using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string CountWaysToRollTen(int m, int n)
        {
            // Validate inputs
            if (m <= 0 || n <= 0)
            {
                return "Dice sides must be positive integers.";
            }

            // Calculate number of ways to get sum 10
            int count = 0;

            // Iterate over all possible values on the first die
            for (int value1 = 1; value1 <= m; value1++)
            {
                // Calculate required value on the second die to sum up to 10
                int value2 = 10 - value1;

                // Check if the value2 is within the range of the second die
                if (value2 >= 1 && value2 <= n)
                {
                    count++;
                }
            }
            // Generate response message
            string response;
            if (count == 0)
            {
                response = "There are 0 ways to get the sum 10.";
            }
            else if (count == 1)
            {
                response = "There is 1 way to get the sum 10.";
            }
            else
            {
                response = $"There are {count} ways to get the sum 10.";
            }

            // Return the result
            return response;
        }
    }
}