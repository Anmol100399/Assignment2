using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web.Http;
using System.Web.UI;

namespace Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        //Get localhost:xx/api/RSANumbers?lowerLimit={id}&upperLimit=15{id}
        /// <summary>
        /// RSA Numbers When a credit card number is sent through the Internet it must be protected so that other people cannot see it. Many web browsers use a protection based on "RSA Numbers." A number is an RSA number if it has exactly four divisors. In other words, there are exactly four numbers that divide into it evenly.
        ///For example, 10 is an RSA number because it has exactly four divisors(1, 2, 5, 10). 12 is not an RSA number because it has too many divisors(1, 2, 3, 4, 6, 12). 11 is not an RSA number either.There is only one RSA number in the range 10...12. 
        ///Write a program that inputs a range of numbers and then counts how many numbers from that range are RSA numbers.You may assume that the numbers in the range are less than 1000. 
        /// </summary>
        /// <returns>
        /// returns a RSA number of two inputs i.e. upperlimit and lowerlimit
        /// </returns>
        /// <example>
        ///GET localhost:xx/api/RSANumbers?lowerLimit=10&upperLimit=12 ->The number of RSA numbers between 10 and 12 is 1
        ///GET localhost:xx/api/RSANumbers?lowerLimit=11&upperLimit=15 ->The number of RSA numbers between 11 and 15 is 2
        /// curl -d "" http://localhost:60606/api/RSANumbers?lowerLimit={id}&upperLimit={id}
        [HttpGet]
        [Route("api/RSANumbers")]
        public string CountRSANumbers(int lowerLimit, int upperLimit)//int lowerlimit=input1; int upperlimit=input2
        {
            if (lowerLimit < 1 || upperLimit >= 999 || lowerLimit >= upperLimit)
                //error shown when lowerlimit less than 1 or upperlimit more than 1000 or lowerlimit more than upperlimit
            {
                return "Invalid Input. Lower limit must be at least 1, upper limit must be less than 1000 and lower limit must be less than upper limit.";
            }

            int count = CountRSANumbersInRange(lowerLimit, upperLimit);

            return $"The number of RSA numbers between {lowerLimit} and {upperLimit} is {count}"; //count is the RSA number result
        }

        private int CountRSANumbersInRange(int lower, int upper)
        {
            int rsaCount = 0;

            for (int num = lower; num <= upper; num++)
            {
                if (IsRSANumber(num))
                {
                    rsaCount++;
                }
            }

            return rsaCount;
        }

        private bool IsRSANumber(int number)
        {
            int divisorCount = 0;

            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    if (i * i == number)
                    {
                        divisorCount++;
                    }
                    else
                    {
                        divisorCount += 2;
                    }
                }
            }
            return divisorCount == 4;
        }
    }
}