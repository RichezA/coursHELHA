using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public static class FizzBuzzClass
    {
        public static string GetFizzBuzz(int nbStart) 
        {
            return nbStart % 3 == 0 ? nbStart % 5 == 0 ? "FizzBuzz" : "Fizz" : nbStart % 5 == 0 ? "Buzz" : nbStart.ToString();
        }
    }
}
