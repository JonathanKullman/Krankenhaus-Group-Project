using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    interface IDepartmentList
    {
        public List<Patient> PatientList { get; set; }
        public int MaxPatientList { get; set; }
    }
}
