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
            this.Timer = new Timer(new TimerCallback(OnEveryTick), null, 1000, 1000);
        }
        static void OnEveryTick(object state)
        {
            //Hospital.OnTick();
        }



    }
}
