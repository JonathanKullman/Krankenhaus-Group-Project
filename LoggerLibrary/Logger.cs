using System;
using System.IO;
using HospitalLibrary;

namespace LoggerLibrary
{
    public class Logger
    {
        public void WriteToFile(object s, EventArgs e)
        {
            var hp = s as Hospital;



            using (StreamWriter sw = File.AppendText("Logger.txt"))
            {
                foreach (var patient in hp.Iva.PatientList)
                {
                    sw.Write(patient.Name);
                }
                

                sw.Close();
                sw.Flush();

            }
            
        }
    }
}
