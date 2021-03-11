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
        private List<Timer> Timer { get; }
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
            Timer = new List<Timer>();
            this.Timer.Add(new Timer(new TimerCallback(Hospital.Iva.OnTickChanges), Hospital, 1000, 1000 + PatientsAtStart));
            this.Timer.Add(new Timer(new TimerCallback(Hospital.Sanatorium.OnTickChanges), Hospital, 1000, 1000 + PatientsAtStart));
            this.Timer.Add(new Timer(new TimerCallback(Hospital.PatientQueue.OnTickChanges), null, 1000, 1000 + PatientsAtStart));
            this.Timer.Add(new Timer(new TimerCallback(Run), null, 1000, 1000 + PatientsAtStart));
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
        internal void Run(object state)
        {
            if (isRunning)
            {
                DayCounter++;

                Hospital.OnTick(DayCounter);
                Screen.PrintToSCreen(this);

                if (Hospital.Iva.PatientsCount() == 0 && Hospital.Sanatorium.PatientsCount() == 0)
                {
                    foreach (var item in Timer)
                    {
                        item.Change(Timeout.Infinite, Timeout.Infinite);
                        item.Dispose();
                    }
                    End = DateTime.Now;
                    Screen.PrintFinishedResults(this);
                    Logger.SimFinished(Start, End, DayCounter, Hospital.Clone(), PatientsAtStart);
                }
            }
        }
    }
}
