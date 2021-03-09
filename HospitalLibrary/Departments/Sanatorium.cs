using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class Sanatorium : IDepartment
    {
        public int Risk { get; set; }
        public int Chance { get; set; }
        public List<Patient> PatientList { get; set; } //Max 10
        public Sanatorium()
        {
            Risk = 50;
            Chance = 35;
        }
        public void OnTickChanges()
        {
            



        }
    }
}
