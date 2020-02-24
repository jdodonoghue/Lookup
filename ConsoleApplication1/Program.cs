using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lookup.Biz;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dslookup1 = new DataSet();
            Lookup.Biz.Lookup obj = new Lookup.Biz.Lookup("Constring");
            
            dslookup1 = obj.Retrieve_Lookup(1);
            string x = dslookup1.Tables[0].Rows.Count.ToString();
                        
            Console.WriteLine("count: " + x);
            Console.ReadLine();
            
        }
    }
}
