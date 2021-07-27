using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using strproDAL;
namespace strprocd
{
    class Program
    {
        static void Main(string[] args)
        {
            CS1 obj = new CS1();
            int rows;
            int rows1;
            int result = (obj.GetAllCoursesDetails("ILSWTTI149", "Software", 85, "SKP", "Hands-on", out rows));
            // int result1 = (obj.DeleteCourse("ILSWTTI101", out rows));
            Console.WriteLine($"Value=" + result);
            Console.WriteLine(rows + "Rows Affected");
            Console.WriteLine("\n");

            int result1 = (obj.ModifyCourseDuration("ILSWTTI101", 80, out rows1));
            /* Console.WriteLine($"Value=" + result1);
             Console.WriteLine(rows + "Rows Affected");
             Console.WriteLine("\n");
            */
            Console.WriteLine($"Value=" + result1);
            Console.WriteLine(rows1 + "Rows Affected");
            Console.ReadLine();

        }
    }
    }

