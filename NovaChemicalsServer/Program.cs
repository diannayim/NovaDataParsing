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
                int totalCounter = 0;
                int counter = 0;
                string line;
                bool notNull = true;

                StreamReader file = new StreamReader("C:\\Users\\aselab\\Documents\\NovaChemData\\01-Metal-BaseCase.txt");

                while (notNull)
                {
                    MySqlCommand command = dbCon.CreateSQLCommand();

                    while (counter < 100)
                    {
                        line = file.ReadLine();

                        if (line == null)
                        {
                            notNull = false;
                            break;
                        }
                        
                        string[] fields = line.Replace(" ", "").Split(',');

                        if (counter > 0)
                        {
                            command.CommandText += "INSERT INTO data (filekey, cellnumber, xcoor, ycoor, zcoor, ppmvdryco, xvel, yvel, zvel, pressure, temperature, ch4, o2, co2, co, h2o, h2, cellvolume, density, turbkineticenergy, turbdissrate, viscositylam, specificheatcp) VALUES "
                                + "(?filekey_" + counter + ", ?cellnumber_" + counter + ", ?xcoor_" + counter + ", ?ycoor_" + counter + ", ?zcoor_" + counter + ", ?ppmvdryco_" + counter + ", ?xvel_" + counter + ", ?yvel_" + counter + ", ?zvel_" + counter + ", ?pressure_" + counter + ", ?temperature_" + counter
                                + ", ?ch4_" + counter + ", ?o2_" + counter + ", ?co2_" + counter + ", ?co_" + counter + ", ?h2o_" + counter + ", ?h2_" + counter + ", ?cellvolume_" + counter + ", ?density_" + counter + ", ?turbkineticenergy_" + counter + ", ?turbdissrate_" + counter + ", ?viscositylam_" + counter + ", ?specificheatcp_" + counter + ");\n";

                            command.Parameters.AddWithValue("?filekey_" + counter, 1);
                            command.Parameters.AddWithValue("?cellnumber_" + counter, int.Parse(fields[0]));
                            command.Parameters.AddWithValue("?xcoor_" + counter, float.Parse(fields[1]));
                            command.Parameters.AddWithValue("?ycoor_" + counter, float.Parse(fields[2]));
                            command.Parameters.AddWithValue("?zcoor_" + counter, float.Parse(fields[3]));
                            command.Parameters.AddWithValue("?ppmvdryco_" + counter, float.Parse(fields[4]));
                            command.Parameters.AddWithValue("?xvel_" + counter, float.Parse(fields[5]));
                            command.Parameters.AddWithValue("?yvel_" + counter, float.Parse(fields[6]));
                            command.Parameters.AddWithValue("?zvel_" + counter, float.Parse(fields[7]));
                            command.Parameters.AddWithValue("?pressure_" + counter, float.Parse(fields[8]));
                            command.Parameters.AddWithValue("?temperature_" + counter, float.Parse(fields[9]));
                            command.Parameters.AddWithValue("?ch4_" + counter, float.Parse(fields[10]));
                            command.Parameters.AddWithValue("?o2_" + counter, float.Parse(fields[11]));
                            command.Parameters.AddWithValue("?co2_" + counter, float.Parse(fields[12]));
                            command.Parameters.AddWithValue("?co_" + counter, float.Parse(fields[13]));
                            command.Parameters.AddWithValue("?h2o_" + counter, float.Parse(fields[14]));
                            command.Parameters.AddWithValue("?h2_" + counter, float.Parse(fields[15]));
                            command.Parameters.AddWithValue("?cellvolume_" + counter, float.Parse(fields[16]));
                            command.Parameters.AddWithValue("?density_" + counter, float.Parse(fields[17]));
                            command.Parameters.AddWithValue("?turbkineticenergy_" + counter, float.Parse(fields[18]));
                            command.Parameters.AddWithValue("?turbdissrate_" + counter, float.Parse(fields[19]));
                            command.Parameters.AddWithValue("?viscositylam_" + counter, float.Parse(fields[20]));
                            command.Parameters.AddWithValue("?specificheatcp_" + counter, float.Parse(fields[21]));
                        }

                        counter++;
                    }
                    
                    command.ExecuteNonQuery();
                    totalCounter += counter;
                    Console.WriteLine(totalCounter);
                    counter = 1;

                    if (!notNull)
                        break;
                }
            }
        }
    }
}
