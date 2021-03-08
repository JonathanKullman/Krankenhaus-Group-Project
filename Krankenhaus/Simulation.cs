﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using HospitalLibrary;

namespace Krankenhaus
{
    public class Simulation
    {
        
        public Hospital Hospital { get; set; }
        public DateTime Start { get; set; }
        public int TickCounter { get; set; }
        public DateTime End { get; set; }
        public Simulation(int nrOfPatients)
        {
            this.Hospital = HospitalBuilder.CreateHospital(nrOfPatients);
        }
        public async Task StartTicker()
        {



        }

    }
}