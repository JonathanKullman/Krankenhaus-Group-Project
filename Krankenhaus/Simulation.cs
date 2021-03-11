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
        internal Hospital Hospital { get; }
        internal DateTime Start { get; set; }
        internal int PatientsAtStart { get; }
        internal int DayCounter { get; private set; }
        internal DateTime End { get; set; }
        private bool isRunning { get; set; }
        internal Logger Logger { get; }
        internal Simulation(int nrOfPatients)
        {
            PatientsAtStart = nrOfPatients;
            this.Hospital = new Hospital(nrOfPatients);
            this.Logger = new Logger();
            Hospital.SendReport += Logger.WriteToFile;
            DayCounter = 1;
            isRunning = true;
            Start = DateTime.Now;
            this.Timer = new Timer(new TimerCallback(EveryTick), null, 1000, 1000 + PatientsAtStart);
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
                Screen.PrintToSCreen(this);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());

                if (Hospital.Iva.PatientsCount() == 0 && Hospital.Sanatorium.PatientsCount() == 0)
                {
                    Timer.Change(Timeout.Infinite, Timeout.Infinite);
                    Timer.Dispose();
                    End = DateTime.Now;
                    Screen.PrintFinishedResults(this);
                    Logger.SimFinished(Start, End, DayCounter, Hospital.Clone(), PatientsAtStart);
                }
            }
        }
    }
}
