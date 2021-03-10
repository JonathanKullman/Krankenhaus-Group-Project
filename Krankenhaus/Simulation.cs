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
            this.Timer = new Timer(new TimerCallback(EveryTick), null, 1000, 500);
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

            var tempArray = new Patient[Hospital.PatientQueue.PatientList.Count];
            Hospital.PatientQueue.PatientList.CopyTo(tempArray, 0);
            Console.WriteLine("PatientQueue");
            Console.WriteLine();
            for (int i = 0; i < tempArray.Length; i++)
            {

                Console.WriteLine(tempArray[i].Name);
                Console.WriteLine(tempArray[i].SicknessLevel);
            }
            Console.WriteLine($"ListCount: {Hospital.PatientQueue.PatientList.Count}");
            //Console.ReadKey();


            var tempDoctor = new ExtraDoctor[Hospital.ExtraDoctors.Count];
            Hospital.ExtraDoctors.CopyTo(tempDoctor, 0);
            Console.WriteLine("ExtraDoctors");
            Console.WriteLine();
            foreach (var item in tempDoctor)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine($"Exhausted lvl: {item.ExhaustedLevel}.");
                Console.WriteLine($"Cempetence lvl: {item.Competence}.");
            }
            Console.WriteLine($"ListCount: {Hospital.ExtraDoctors.Count}");
            //Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine($"Current doctor at IVA: \n" +
                $"{Hospital.Iva.CurrentExtraDoctor.Name}");
            Console.WriteLine($"{Hospital.Iva.CurrentExtraDoctor.ExhaustedLevel}");
            Console.WriteLine($"{Hospital.Iva.CurrentExtraDoctor.Competence}");
            Console.WriteLine();
            Console.WriteLine("IVA");
            Console.WriteLine();
            foreach (var item in Hospital.Iva.PatientList)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.SicknessLevel);
            }
            Console.WriteLine($"ListCount: {Hospital.Iva.PatientList.Count}");
            //Console.ReadKey();


            Console.WriteLine("Sanatorium");
            Console.WriteLine();
            foreach (var item in Hospital.Sanatorium.PatientList)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.SicknessLevel);
            }
            Console.WriteLine($"ListCount: {Hospital.Sanatorium.PatientList.Count}");
            //Console.ReadKey();


            Console.WriteLine("Afterlife");
            Console.WriteLine();
            foreach (var item in Hospital.AfterLife.DeadPatients)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.SicknessLevel);
                Console.WriteLine(item.TimeOfCheckOut);
            }
            Console.WriteLine($"ListCount: {Hospital.AfterLife.DeadPatients.Count}");
            //Console.ReadKey();


            Console.WriteLine("Checked out");
            Console.WriteLine();
            foreach (var item in Hospital.CheckedOut.HealthyPatients)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.SicknessLevel);
                Console.WriteLine(item.TimeOfCheckOut);
            }
            Console.WriteLine($"ListCount: {Hospital.CheckedOut.HealthyPatients.Count}");
            //Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine($"Current cycle: {TickCounter}");
            Console.WriteLine();
            Console.WriteLine();


        }


    }
}
