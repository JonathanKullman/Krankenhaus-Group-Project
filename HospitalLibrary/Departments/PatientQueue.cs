using System;

namespace HospitalLibrary
{
    public class PatientQueue : IDepartment
    {
        public int Risk { get; set; }
        public int Chance { get; set; }
        public int Unchanged { get; set; }
    }
}
