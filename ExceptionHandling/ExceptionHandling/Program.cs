using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advanced C# - Exception Handling:");

            //1. Exception Handling Scenario, Dividing by Zero.
            var calculator = new Calculator();

            //var result = calculator.Divide(5, 0); //Causes DivideByZero Exception.

            //2. First Solution - Try & Catch Blocks
            try
            {
                var result = calculator.Divide(5, 0);
            }
            catch (DivideByZeroException ex) //Very Specific Exception
            {
                Console.WriteLine("You CANNOT DIVIDE by ZERO");
            }
            catch (ArithmeticException ex)//Less Specific Exception
            {
                Console.WriteLine("You CANNOT DIVIDE by ZERO");
            }
            catch (Exception ex) //Most Generic Exception
            {
                Console.WriteLine("Sorry, Unexpteced Error Occured.");
            }

            //3. Introducing Finally
            ////Working with Unmanged Data eg Files, Database etc. Need to Manually Terminate access.
            try
            {
                using (var streamReader = new StreamReader(@"c:\file.zip"))
                {
                    var content = streamReader.ReadToEnd(); //Opening Stream
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, Unexpteced Error Occured.");
            }

            //When the USING Keyword is envoked, this finally block is implmented behind the scenes, no need for this block anymore.

            //finally 
            //{
            //    if(streamReader != null)
            //    {
            //        streamReader.Dispose(); //Closing Steam
            //    }
            //}

            //4. Creating Custom Error Handling
            try
            {
                var api = new YoutubeAPI();
                api.GetVideos("Tony123");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            /*Summary
             * When using Frameworks like Entity, we will see these Generic Exceptions a lot.
             * And withing those Exceptions, we will have the inner exceptions with the real problem.
            */
            Console.ReadKey();
        }
    }
}
