using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class AfterLife
    {
        public List<Patient> DeadPatients { get; set; }
        public AfterLife()
        {
            DeadPatients = new List<Patient>();
        }
    }
}
