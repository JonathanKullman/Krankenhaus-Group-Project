using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    class Sanatorium : IDepartment
    {
        public int Risk { get; set; }
        public int Chance { get; set; }
        public int Unchanged { get; set; }
        public Patient[] PatientList { get; set; } //Max 10
    }
}
