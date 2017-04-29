using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaChemicalsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbCon = DatabaseConnection.Instance();
            Console.WriteLine(dbCon.IsConnect());

            if (dbCon.IsConnect()) {
                int counter = 0;
                string line;

                StreamReader file = new StreamReader("C:\\Users\\aselab\\Documents\\NovaChemData\\01-Metal-BaseCase.txt");

                while ((line = file.ReadLine()) != null || counter == 10)
                {
                    if (counter > 0)
                    {

                    }

                }
            }
        }
    }
}
