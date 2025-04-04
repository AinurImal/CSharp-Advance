using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advanced C# - Nullable Types:");

            //1.Birth date on a Website for might be optional, but date as a value cannot be null.
            //DateTime date = null;

            //2. Solution 1 - Using Nullable Generic Structure: 
            Nullable<DateTime> date = null;

            //3. Solution 2 - ? Keyword = tell compiler this value can be null.
            DateTime? maDate = new DateTime();

            //4. Using Nullable Methods
            Console.WriteLine("\nDemonstrating Nullable Methods:");
            Console.WriteLine("GetValueOrDefault: " + date.GetValueOrDefault());
            Console.WriteLine("HasValue: " + date.HasValue);
            //Console.WriteLine("Value: " + date.Value); //Causes Exception, as value is Null.
            //In Summary, use GetValueOrDefault when working with Nullable Types.

            //5. Reassinging Nullable Values
            //DateTime maNewDate = maDate; //Cannot Convert Nullable to regular data type.
            Console.WriteLine("\nCasting Nullable Values:");
            DateTime? myDate = new DateTime(2014, 1, 1);
            DateTime? maNewDate = myDate; //Can Reassign nullable type is value is not null.
            Console.WriteLine(maNewDate);

            DateTime dateymcdate = maDate.GetValueOrDefault();
            Console.WriteLine(dateymcdate);

            //6. Null Coalescing Operator
            Console.WriteLine("\nNull Coalescing Operator");
            DateTime? dateWan = new DateTime();
            DateTime date2;

            if (dateWan != null)
                date2 = dateWan.GetValueOrDefault();
            else
                date2 = DateTime.Today;

            Console.WriteLine(date2);

            //7. Rewriting IF Else using Null Coalescing Operator
            DateTime date3 = dateWan ?? DateTime.Today; //If date has value, otherwise use Today.

            //8. Tertiary Operator
            DateTime date4 = (dateWan != null) ? dateWan.GetValueOrDefault() : DateTime.Today;

            Console.ReadKey();
        }
    }
}
