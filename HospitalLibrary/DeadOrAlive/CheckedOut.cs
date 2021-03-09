using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class CheckedOut
    {
        public List<Patient> HealthyPatients { get; set; }
        public CheckedOut()
        {
            HealthyPatients = new List<Patient>();
        }
    }
}
