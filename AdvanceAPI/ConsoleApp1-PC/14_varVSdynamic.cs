using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_PC
{
    internal class varVSdynamic
    {
        internal static void VarDynamicDemo()
        {
            int a = 4;
            var b = 34;

            // var can't be used as return type or for properties or in parameters.
            // type of variable is decide at compile time.
            // initialization is compulsory.

            // dynamic - type of variable is decided at runtime. initialization is not compulsory.
            // can be used to create properties, as a parameter or in return types.
            dynamic d1 = 4;
            d1 = "hi";
        }
    }
}
