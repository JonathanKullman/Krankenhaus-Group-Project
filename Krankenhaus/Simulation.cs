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
        private List<Timer> Timers { get; }
        internal Hospital Hospital { get; }
        internal DateTime Start { get; set; }
        internal int PatientsAtStart { get; }
        internal int DayCounter { get; private set; }
        internal DateTime End { get; set; }
        private bool isRunning { get; set; }
        internal Logger Logger { get; }
        internal Simulation(int nrOfPatients, int iva, int sanatorium)
        {
            PatientsAtStart = nrOfPatients;
            this.Hospital = new Hospital(nrOfPatients, iva, sanatorium);
            this.Logger = new Logger();
            DayCounter = 1;
            isRunning = true;
            Start = DateTime.Now;
            Timers = new List<Timer>();
            this.Timers.Add(new Timer(new TimerCallback(Hospital.Iva.OnTickChanges), Hospital, 1000, 1000 + PatientsAtStart));
            this.Timers.Add(new Timer(new TimerCallback(Hospital.Sanatorium.OnTickChanges), Hospital, 1000, 1000 + PatientsAtStart));
            this.Timers.Add(new Timer(new TimerCallback(Hospital.PatientQueue.OnTickChanges), Hospital, 1000, 1000 + PatientsAtStart));
            this.Timers.Add(new Timer(new TimerCallback(Run), null, 1100, 1000 + PatientsAtStart));
        }
        internal void Paus()
        {
            if (isRunning)
            {
                isRunning = false;
                foreach (Timer timer in Timers)
                {
                    timer.Change(Timeout.Infinite, Timeout.Infinite);
                }
            }
            else
            {
                isRunning = true;
                foreach (Timer timer in Timers)
                {
                    timer.Change(1000, 1000);
                }
            }
        }
        internal void Run(object state)
        {

            if (isRunning)
            {
                DayCounter++;

                Hospital.OnTick(DayCounter);

                Screen.PrintToSCreen(this);
                Logger.WriteToFile(Hospital.Clone());


                if (Hospital.PatientQueue.PatientsCount() == 0 && Hospital.Iva.PatientsCount() == 0 && Hospital.Sanatorium.PatientsCount() == 0)
                {
                    foreach (var timer in Timers)
                    {
                        timer.Change(Timeout.Infinite, Timeout.Infinite);
                        timer.Dispose();
                    }
                    End = DateTime.Now;
                    Screen.PrintFinishedResults(this);
                    Logger.SimFinished(Start, End, DayCounter, Hospital.Clone(), PatientsAtStart);
                }
            }
        }
    }
}
