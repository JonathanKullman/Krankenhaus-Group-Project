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
                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine();
                sw.Write("\n\t\t\t\t\t           Current Tick/Cycle: ");
                sw.Write($"Day #{e.CurrentTick}");

                //CURRENT PATIENTS IN QUEUE DISPLAY
                sw.Write("\n\n\n\t\t\t\t\t       <<< Patients in Queue [");
                sw.Write($"{hp.PatientQueue.PatientsCount()}");
                sw.Write("] >>>\n");
                sw.WriteLine("\t\t\t______________________________________________________________________");

                var tempArray = hp.PatientQueue.CopyPatientsToArray();

                for (int i = 0; i < tempArray.Length; i++)
                {
                    sw.Write("\n\t\tName: ");
                    sw.Write($"{tempArray[i].Name}");
                    sw.Write("\t      Sickness Level: ");
                    sw.Write($"{tempArray[i].SicknessLevel}");
                    sw.Write("\t      Date of Birth: ");
                    sw.Write($"{tempArray[i].Birthday}");
                }

                //EXTRA DOCTORS DISPLAY
                sw.Write("\n\n\n\t\t\t\t\t      <<<   Extra Doctors [");
                sw.Write($"{hp.ExtraDoctorsCount()}");
                sw.Write("]  >>>\n");
                sw.WriteLine("\t\t\t______________________________________________________________________");


                foreach (ExtraDoctor doctor in hp.CopyExtraDoctorsToArray())
                {
                    sw.Write("\n\t                Name: ");
                    sw.Write($"{doctor.Name}");
                    sw.Write("\t     Exhausted Level: ");
                    sw.Write($"{doctor.ExhaustedLevel}");
                    sw.Write("\t     Competence Level: ");
                    sw.Write($"{doctor.Competence}");

                }

                //SANATORIUM PATIENTS DISPLAY
                sw.Write("\n\n\n\t\t\t\t\t  <<<   Sanatorium Patients [");
                sw.Write($"{hp.Sanatorium.PatientsCount()}");
                sw.Write("]  >>>\n");
                sw.WriteLine("\t\t\t______________________________________________________________________");

                foreach (Patient patient in hp.Sanatorium)
                {
                    sw.Write("\n\t\t\t          Name: ");
                    sw.Write($"{patient.Name}");
                    sw.Write("\t        Sickness Level: ");
                    sw.Write($"{patient.SicknessLevel}");
                }

                //IVA PATIENTS DISPLAY
                sw.Write("\n\n\n\t\t\t\t\t      <<<   IVA Patients [");
                sw.Write($"{hp.Iva.PatientsCount()}");
                sw.Write("]  >>>\n");
                sw.WriteLine("\t\t\t______________________________________________________________________");

                foreach (Patient patient in hp.Iva)
                {
                    sw.Write("\n\t\t\t          Name: ");
                    sw.Write($"{patient.Name}");
                    sw.Write("\t     Sickness Level: ");
                    sw.Write($"{patient.SicknessLevel}");
                }

                if (hp.Iva.ExtraDoctor != null)
                {
                    //CURRENT DOCTOR DISPLAY
                    sw.WriteLine($"\n\n\n\t\t\t\t\t      <<< Current Doctor At IVA >>>");
                    sw.WriteLine("\t\t\t______________________________________________________________________");

                    sw.Write("\n\t                Name: ");

                    sw.Write($"{hp.Iva.ExtraDoctor.Name}");
                    sw.Write("\t     Exhausted Level: ");
                    sw.Write($"{hp.Iva.ExtraDoctor.ExhaustedLevel}");

                    sw.Write("\t     Competence Level: ");
                    sw.Write($"{hp.Iva.ExtraDoctor.Competence}");
                }

                //AFTERLIFE PATIENTS DISPLAY
                sw.Write("\n\n\n\t\t\t\t\t   <<<   Afterlife Patients [");
                sw.Write($"{hp.AfterLife.CountDeadPatients()}");
                sw.Write("]  >>>\n");
                sw.WriteLine("\t\t\t______________________________________________________________________");

                foreach (Patient patient in hp.AfterLife)
                {
                    sw.Write("\n\t           Name: ");
                    sw.Write($"{patient.Name}");
                    sw.Write("\t     Sickness Level: ");
                    sw.Write($"{patient.SicknessLevel}");
                    sw.Write("\t     Died at: ");
                    sw.Write($"{patient.Department}");
                    sw.Write("\t     Time of death: ");
                    sw.Write($"{patient.TimeOfCheckOut}");
                    if (patient.Department != Department.PatientQueue)
                    {
                        sw.Write("\tDays treated: ");
                        sw.Write($"{patient.DaysTreated}");
                    }
                    else
                    {
                        sw.Write("\tDays passed: ");
                        sw.Write($"{patient.DaysPassed}");
                    }
                }


                //HEALTHY CHECKED OUT PATIENTS DISPLAY
                sw.Write("\n\n\n\t\t\t\t\t    <<<   Checked Out Patients [");
                sw.Write($"{hp.CheckedOut.CountHealthyPatients()}");
                sw.Write("]  >>>\n");
                sw.WriteLine("\t\t\t______________________________________________________________________");

                foreach (Patient patient in hp.CheckedOut)
                {
                    sw.Write("\n\t          Name: ");
                    sw.Write($"{patient.Name}");
                    sw.Write("\t     Sickness Level: ");
                    sw.Write($"{patient.SicknessLevel}");
                    sw.Write("\t     Released at: ");
                    sw.Write($"{patient.Department}");
                    sw.Write("\t     Time of checkout: ");
                    sw.Write($"{patient.TimeOfCheckOut}");
                    if (patient.Department != Department.PatientQueue)
                    {
                        sw.Write("\tDays treated: ");
                        sw.Write($"{patient.DaysTreated}");
                    }
                    else
                    {
                        sw.Write("\tDays passed: ");
                        sw.Write($"{patient.DaysPassed}");
                    }
                }
                sw.Flush();
            }
        }
        public void SimFinished(DateTime start, DateTime end, int dayCounter, Hospital hp, int patientsAtStart)
        {
            using (StreamWriter sw = File.AppendText("SimCompletedReport.txt"))
            {
                sw.WriteLine($"The simulation started with {patientsAtStart} patients.");
                sw.WriteLine($"Simulation lasted for {dayCounter} days.");
                sw.WriteLine($"Simulation started at {start}.");
                sw.WriteLine($"Simulation Ended at {end}.");
                sw.WriteLine($"{hp.AfterLife.CountDeadPatients()} patients died.");
                sw.WriteLine($"{hp.CheckedOut.CountHealthyPatients()} patients recovered.");
                sw.WriteLine($"{hp.ExtraDoctorsCount()} extra doctors were still available.");
                sw.WriteLine();

            }
        }
    }
}
