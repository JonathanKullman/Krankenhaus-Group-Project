using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class Sanatorium : IDepartment, IDepartmentList
    {
        public int Risk { get; set; }
        public int Chance { get; set; }
        public List<Patient> PatientList { get; set; } 
        public int MaxPatientList { get; set; }
        public Sanatorium(Hospital hp)
        {
            MaxPatientList = 10;
            Risk = 50;
            Chance = 35;
            PatientList = new List<Patient>();
            OnTickChanges(hp);
        }
        public void OnTickChanges(Hospital hp)
        {
            HospitalManager.CheckConditionThenTreatment(hp, this);
        }
    }
}
