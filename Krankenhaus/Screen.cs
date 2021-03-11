using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using HospitalLibrary;

namespace Krankenhaus
{
    internal static class Screen
    {
        internal static void PrintToSCreen(Simulation sim)
        {
            var dayCounter = sim.DayCounter;
            var hp = sim.Hospital.Clone();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\n\t\t\t\t\t           Current Tick/Cycle: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{dayCounter}");
            Console.ResetColor();

            //CURRENT PATIENTS IN QUEUE DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t       <<< Patients in Queue [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{hp.PatientQueue.PatientsCount()}");
            Console.ResetColor();
            Console.Write("] >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            var tempArray = hp.PatientQueue.CopyPatientsToArray();

            for (int i = 0; i < tempArray.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\t\tName: ");
                Console.ResetColor();
                Console.Write($"{tempArray[i].Name}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\t      Sickness Level: ");
                Console.ResetColor();
                Console.Write($"{tempArray[i].SicknessLevel}");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("\t      Date of Birth: ");
                Console.ResetColor();
                Console.Write($"{tempArray[i].Birthday}");
            }

            //EXTRA DOCTORS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t      <<<   Extra Doctors [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{hp.ExtraDoctorsCount()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");


            foreach (ExtraDoctor doctor in hp.CopyExtraDoctorsToArray())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\t                Name: ");
                Console.ResetColor();
                Console.Write($"{doctor.Name}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\t     Exhausted Level: ");
                Console.ResetColor();
                Console.Write($"{doctor.ExhaustedLevel}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\t     Competence Level: ");
                Console.ResetColor();
                Console.Write($"{doctor.Competence}");

            }

            //SANATORIUM PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t  <<<   Sanatorium Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{hp.Sanatorium.PatientsCount()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (Patient patient in hp.Sanatorium)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\t\t\t          Name: ");
                Console.ResetColor();
                Console.Write($"{patient.Name}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\t        Sickness Level: ");
                Console.ResetColor();
                Console.Write($"{patient.SicknessLevel}");
            }

            //IVA PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t      <<<   IVA Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{hp.Iva.PatientsCount()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (Patient patient in hp.Iva)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\t\t\t          Name: ");
                Console.ResetColor();
                Console.Write($"{patient.Name}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\t     Sickness Level: ");
                Console.ResetColor();
                Console.Write($"{patient.SicknessLevel}");
            }

            if (hp.Iva.ExtraDoctor != null)
            {
                //CURRENT DOCTOR DISPLAY
                Console.WriteLine($"\n\n\n\t\t\t\t\t      <<< Current Doctor At IVA >>>");
                Console.WriteLine("\t\t\t______________________________________________________________________");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\t                Name: ");
                Console.ResetColor();

                Console.Write($"{hp.Iva.ExtraDoctor.Name}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\t     Exhausted Level: ");
                Console.ResetColor();
                Console.Write($"{hp.Iva.ExtraDoctor.ExhaustedLevel}");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\t     Competence Level: ");
                Console.ResetColor();
                Console.Write($"{hp.Iva.ExtraDoctor.Competence}");
            }

            //AFTERLIFE PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t   <<<   Afterlife Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{hp.AfterLife.CountDeadPatients()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (Patient patient in hp.AfterLife)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\tName: ");
                Console.ResetColor();
                Console.Write($"{patient.Name}");
                //Console.ForegroundColor = ConsoleColor.DarkCyan;
                //Console.Write("\t     Sickness Level: ");
                //Console.ResetColor();
                //Console.Write($"{patient.SicknessLevel}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\tDied at: ");
                Console.ResetColor();
                Console.Write($"{patient.Department}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\tTime of death: ");
                Console.ResetColor();
                Console.Write($"{patient.TimeOfCheckOut}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (patient.Department != Department.PatientQueue)
                {
                    Console.Write("\tDays treated: ");
                    Console.ResetColor();
                    Console.Write($"{patient.DaysTreated}");
                }
                else
                {
                    Console.Write("\tDays passed: ");
                    Console.ResetColor();
                    Console.Write($"{patient.DaysPassed}");
                }


            }


            //HEALTHY CHECKED OUT PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t    <<<   Checked Out Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{hp.CheckedOut.CountHealthyPatients()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (Patient patient in hp.CheckedOut)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\tName: ", -50);
                Console.ResetColor();
                Console.Write($"{patient.Name}");
                //Console.ForegroundColor = ConsoleColor.DarkCyan;
                //Console.Write("\t     Sickness Level: ");
                //Console.ResetColor();
                //Console.Write($"{patient.SicknessLevel}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\tReleased from: ");
                Console.ResetColor();
                Console.Write($"{patient.Department}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\tReleased at: ");
                Console.ResetColor();
                Console.Write($"{patient.TimeOfCheckOut}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (patient.Department != Department.PatientQueue)
                {
                    Console.Write("\tDays treated: ");
                    Console.ResetColor();
                    Console.Write($"{patient.DaysTreated}");
                }
                else
                {
                    Console.Write("\tDays passed: ");
                    Console.ResetColor();
                    Console.Write($"{patient.DaysPassed}");
                }
            }
        }
        internal static void PrintFinishedResults(Simulation sim)
        {
            Console.WriteLine();
            Console.WriteLine($"The simulated started with {sim.PatientsAtStart} patients.");
            Console.WriteLine($"Lasted for {sim.DayCounter} days.");
            Console.WriteLine($"Started at {sim.Start}.");
            Console.WriteLine($"Ended at {sim.End}.");
            Console.WriteLine($"{sim.Hospital.AfterLife.CountDeadPatients()} patients died.");
            Console.WriteLine($"{sim.Hospital.CheckedOut.CountHealthyPatients()} patients recovered.");
            Console.WriteLine($"{sim.Hospital.ExtraDoctorsCount()} extra doctors were still available.");
        }
    }
}
