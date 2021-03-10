using System;
using System.IO;
using HospitalLibrary;

namespace LoggerLibrary
{
    public class Logger
    {
        public void WriteToFile(object s, SendReportEventArgs e)
        {
            var hp = s as Hospital;
            
            using (StreamWriter sw = File.AppendText("Logger.txt"))
            {
                sw.Write($"Tick nr: {e.CurrentTick}");
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
