using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HospitalLibrary;

namespace Krankenhaus
{
    public class Simulation
    {
        public Timer Timer { get; set; }
        public Hospital Hospital { get; set; }
        public DateTime Start { get; set; }
        public int TickCounter { get; set; }
        public DateTime End { get; set; }
        public Simulation(int nrOfPatients)
        {
            this.Hospital = new Hospital(nrOfPatients);
            TickCounter = 1;
            Start = DateTime.Now;
            this.Timer = new Timer(new TimerCallback(EveryTick), null, 4000, 5000);
        }
        internal void EveryTick(object state)
        {

            Hospital.OnTick();
            ToScreen();
            TickCounter++;
            if (Hospital.Iva.PatientList.Count == 0 && Hospital.Sanatorium.PatientList.Count == 0)
            {
                Timer.Change(Timeout.Infinite, Timeout.Infinite);
                Timer.Dispose();
                Console.WriteLine("idhuAPISUdgOADGOA");
                Console.ReadKey();
            }
            
        }


        internal void ToScreen()
        {
            Console.Clear();

            Console.Write("\n\t\t\t\t\t           Current Tick/Cycle: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{TickCounter}");
            Console.ResetColor();

            //CURRENT PATIENTS IN QUEUE DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t       <<< Patients in Queue [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Hospital.PatientQueue.PatientList.Count}");
            Console.ResetColor();
            Console.Write("] >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            var tempArray = new Patient[Hospital.PatientQueue.PatientList.Count];
            Hospital.PatientQueue.PatientList.CopyTo(tempArray, 0);

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

            //CURRENT DOCTOR DISPLAY
            Console.WriteLine($"\n\n\n\t\t\t\t\t      <<< Current Doctor At IVA >>>");
            Console.WriteLine("\t\t\t______________________________________________________________________");


            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n\t                Name: ");
            Console.ResetColor();
            Console.Write($"{Hospital.Iva.CurrentExtraDoctor.Name}");         
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\t     Exhausted Level: ");
            Console.ResetColor();
            Console.Write($"{Hospital.Iva.CurrentExtraDoctor.ExhaustedLevel}");
           
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\t     Competence Level: ");
            Console.ResetColor();
            Console.Write($"{Hospital.Iva.CurrentExtraDoctor.Competence}");

            //EXTRA DOCTORS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t      <<<   Extra Doctors [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Hospital.ExtraDoctors.Count}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            var tempDoctorArray = new ExtraDoctor[Hospital.ExtraDoctors.Count];
            Hospital.ExtraDoctors.CopyTo(tempDoctorArray, 0);

            foreach (var doctor in tempDoctorArray)
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

            //IVA PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t      <<<   IVA Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Hospital.Iva.PatientList.Count}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (var patient in Hospital.Iva.PatientList)
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


            //SANATORIUM PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t  <<<   Sanatorium Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Hospital.Sanatorium.PatientList.Count}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (var patient in Hospital.Sanatorium.PatientList)
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


            //AFTERLIFE PATIENTS DISPLAY
            Console.Write("\n\n\n\t\t\t\t\t   <<<   Afterlife Patients [");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Hospital.AfterLife.DeadPatients.Count}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (var patient in Hospital.AfterLife.DeadPatients)
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
            Console.Write($"{Hospital.CheckedOut.HealthyPatients.Count}");
            Console.ResetColor();
            Console.Write("]  >>>\n");
            Console.WriteLine("\t\t\t______________________________________________________________________");

            foreach (var patient in Hospital.CheckedOut.HealthyPatients)
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
                Console.Write("\t     Time of death: ");
                Console.ResetColor();
                Console.Write($"{patient.TimeOfCheckOut}");
            }

        }       

    }
}
