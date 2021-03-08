using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class IVA : IDepartment
    {
        public int Risk { get; set; }
        public int Chance { get; set; }
        public int Unchanged { get; set; }
        public ExtraDoctor CurrentDoctor { get; set; }
        public Patient[] PatientList { get; set; } //Max 5
    }
}
