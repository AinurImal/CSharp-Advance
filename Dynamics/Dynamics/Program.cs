using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advanced C# - Dynamics:");
            /*Taking Some Dynamic Language features into C#
             * In Python, we can allow variable types to be assigned @ runtime.
             * .NET has implmented similar behavior, 
            */

            //1. The Old Way to Achieve the Same Behavior - Reflection
            object obj = "Conor";
            //obj.GetHashCode();

            var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null);

            //2. Intro to Dynamics, if we use Static Programming, the compiler cannot find this Optimize Method
            //object excelObject = "Mosh"; //Using String for Simplicity
            dynamic excelObject = "Mosh";
            excelObject.Optimize(); //Excel Object Method, now useable once Dynamic keyword Added


            //3. Casting Dynamic Values
            dynamic name = "Conor";
            //name = 10; //Reassigning Value to INT & NO Errors
            name++; //Applying INT Method to String, see Runtime Exception! Some of the Dangers of Dynamics, must create Unit tests to cover this!

            //4. Moar Examples
            dynamic a = 10;
            dynamic b = 5;
            //Var lets the Compiler Decide what Type a given variable will be.
            var c = a + b; //Because A & B are Dynamic, C will also be Dynamic

            //5. Moar
            int i = 5;
            dynamic d = i; //d is now int
            long l = d; //l is an int value inside a long

            Console.ReadKey();
        }
    }
}
