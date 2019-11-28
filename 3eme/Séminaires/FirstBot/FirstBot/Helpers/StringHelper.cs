using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBot.Helpers
{
    public class StringHelper
    {
        public static String CleanString(String dirtyString)
        {
            String charsToRemove = "<>?!,.|\'\"\\/{}[])(_-=+*&^%$#@";
            String result = dirtyString;

            foreach (char c in charsToRemove)
            {
                result.Replace(c.ToString(), String.Empty);
            }
            return result.ToUpper();
        }
    }
}
