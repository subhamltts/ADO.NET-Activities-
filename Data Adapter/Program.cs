using DBFirstDemoDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectXDBConnection obj = new ProjectXDBConnection();
            string result = obj.ConnectionToDB();
            //Console.WriteLine(result);
            
            List<string> ls = new List<string>();
            ls = obj.ReadFromDB();
            foreach (var item in ls)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n************** Faculty Table ******************");
            List<string> ls2 = new List<string>();
            ls2 = obj.GetDataFaculty();
            foreach (var item in ls2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n************** Grader Table ******************");
            List<string> ls3 = new List<string>();
            ls3 = obj.GetDataGrader();
            foreach (var item in ls3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n************** Get Batch of given Faculty ******************");
            List<string> ls4 = new List<string>();
            ls4 = obj.GetDataBatch_Faculty();
            foreach (var item in ls4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n************** Get Courses for given batch ******************");
            List<string> ls5 = obj.GetDataCourse_Batch(); //new List<string>();
            //ls5 = obj.GetDataCourse_Batch();
            foreach (var item in ls5)
            {
                Console.WriteLine(item);
            }

            /*Console.WriteLine("\n************** Get ModelOwner for specified ID ******************");
            string owner = obj.GetModelData(2021);
            Console.WriteLine(owner);
            */

            Console.WriteLine("\n************** Stored Procedure ******************");
            obj.storedProcedure("01_ICPC_C", "ICPC_C", 12);


            Console.WriteLine("******************* Adapter data *****************");
            obj.sqlAdapterFunction("Prithvi", "prithvi.pagala@ltts.com", 99004990);

            Console.ReadKey();
        }
    }
}
