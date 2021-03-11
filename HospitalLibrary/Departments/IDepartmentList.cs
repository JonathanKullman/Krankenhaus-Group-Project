using System;
using System.Collections;

namespace HospitalLibrary
{
    interface IDepartmentList : IEnumerable
    {
        int MaxPatients { get; }
        public Patient this[int i] { get; }
        public int PatientsCount();
        public void AddPatient(Patient patient);
        public void RemovePatient(Patient patient);
    }
}
