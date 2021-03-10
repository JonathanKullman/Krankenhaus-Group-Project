using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HospitalLibrary;
using LoggerLibrary;

namespace Krankenhaus
{
    internal class Simulation
    {
        private Timer Timer { get; }
        private Hospital Hospital { get; }
        private DateTime Start { get; set; }
        public int PatientsAtStart { get; }
        private int DayCounter { get; set; }
        private DateTime End { get; set; }
        private bool isRunning { get; set; }
        private Logger Logger { get; }
        internal Simulation(int nrOfPatients)
        {
            PatientsAtStart = nrOfPatients;
            this.Hospital = new Hospital(nrOfPatients);
            this.Logger = new Logger();
            Hospital.SendReport += Logger.WriteToFile;
            DayCounter = 1;
            isRunning = true;
            Start = DateTime.Now;
            this.Timer = new Timer(new TimerCallback(EveryTick), null, 1000, 1000);
        }
        internal void Paus()
        {
            if (isRunning)
            {
                isRunning = false;
            }
            else
            {
                isRunning = true;
            }
        }
        internal void EveryTick(object state)
        {
            if (isRunning)
            {
                DayCounter++;
                Hospital.OnTick(DayCounter);
                ToScreen();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
                
                if (Hospital.Iva.PatientsCount() == 0 && Hospital.Sanatorium.PatientsCount() == 0)
                {
                    Timer.Change(Timeout.Infinite, Timeout.Infinite);
                    Timer.Dispose();
                    End = DateTime.Now;
                    Console.WriteLine($"Simulation started at {Start}");
                    Console.WriteLine($"Simulation ended at {End}");
                    Console.ReadKey();
                }
            }
        }
        private void ToScreen()
        {
            Console.Clear();

            Console.Write("\n\t\t\t\t\t           Current Tick/Cycle: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{DayCounter}");
            Console.ResetColor();

            //CURRENT PATIENTS IN QUEUE DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t       <<< Patients in Queue [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Hospital.PatientQueue.PatientsCount()}");
            Console.ResetColor();
            Console.Write("] >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            var tempArray = Hospital.PatientQueue.CopyPatientsToArray();

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
            Console.Write($"{Hospital.ExtraDoctorsCount()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");


            foreach (ExtraDoctor doctor in Hospital.CopyExtraDoctorsToArray())
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
            Console.Write($"{Hospital.Sanatorium.PatientsCount()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (Patient patient in Hospital.Sanatorium)
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
            Console.Write($"{Hospital.Iva.PatientsCount()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (Patient patient in Hospital.Iva)
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

            if (Hospital.Iva.ExtraDoctor != null)
            {
                //CURRENT DOCTOR DISPLAY
                Console.WriteLine($"\n\n\n\t\t\t\t\t      <<< Current Doctor At IVA >>>");
                Console.WriteLine("\t\t\t______________________________________________________________________");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\t                Name: ");
                Console.ResetColor();

                Console.Write($"{Hospital.Iva.ExtraDoctor.Name}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\t     Exhausted Level: ");
                Console.ResetColor();
                Console.Write($"{Hospital.Iva.ExtraDoctor.ExhaustedLevel}");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\t     Competence Level: ");
                Console.ResetColor();
                Console.Write($"{Hospital.Iva.ExtraDoctor.Competence}");
            }

            //AFTERLIFE PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t   <<<   Afterlife Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Hospital.AfterLife.CountDeadPatients()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (Patient patient in Hospital.AfterLife)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\t           Name: ");
                Console.ResetColor();
                Console.Write($"{patient.Name}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\t     Sickness Level: ");
                Console.ResetColor();
                Console.Write($"{patient.SicknessLevel}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\t     Time of death: ");
                Console.ResetColor();
                Console.Write($"{patient.TimeOfCheckOut}");
            }


            //HEALTHY CHECKED OUT PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t    <<<   Checked Out Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Hospital.CheckedOut.CountHealthyPatients()}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (Patient patient in Hospital.CheckedOut)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\t          Name: ");
                Console.ResetColor();
                Console.Write($"{patient.Name}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\t     Sickness Level: ");
                Console.ResetColor();
                Console.Write($"{patient.SicknessLevel}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\t     Time of Checkout: ");
                Console.ResetColor();
                Console.Write($"{patient.TimeOfCheckOut}");
            }

        }       

    }
}
