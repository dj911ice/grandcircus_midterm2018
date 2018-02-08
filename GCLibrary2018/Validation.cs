using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace GCLibrary2018
{
    class Validation
    {
        public static bool Continue(string Input)
        {
            while (true)
            {
                if (Regex.Match(Input, "^(y|yes|Y|Yes)$").Success)
                {
                    return true;
                }
                else if (Regex.Match(Input, "^(n|no|N|No)$").Success)
                    return false;
                else
                {
                    Console.WriteLine("I didn't understand that. Try again!");
                    Input = Console.ReadLine();
                }
            }
        }
    }
}
