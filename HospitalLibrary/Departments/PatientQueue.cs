using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary
{
    public class PatientQueue : IDepartment
    {
        public int Risk { get; }
        public int Chance { get; }

        private Queue<Patient> patients;

        public PatientQueue(int nrOfPatients)
        {
            Risk = 80;
            Chance = 5;
            patients = HospitalManager.GeneratePatientList(nrOfPatients);
            OnTickChanges();
        }
        private PatientQueue(Queue<Patient> patients, int risk, int chance)
        {
            this.patients = patients;
            this.Risk = risk;
            this.Chance = chance;
        }
        public void OnTickChanges()
        {
            CopyPatientsToArray().ToList().ForEach(patient => patient.CalculateNewHealth(this));
        }
        internal Patient Dequeue()
        {
            return patients.Dequeue();
        }
        public int PatientsCount()
        {
            return patients.Count;
        }
        public Patient[] CopyPatientsToArray()
        {
            var tempPatientArray = new Patient[patients.Count];
            patients.CopyTo(tempPatientArray, 0);
            return tempPatientArray;
        }
        public IDepartment Clone()
        {
            var tempPatientArray = CopyPatientsToArray();
            var patientsCopy = new Queue<Patient>();
            tempPatientArray.ToList().ForEach(patient => patientsCopy.Enqueue(patient.Clone()));

            return new PatientQueue(patientsCopy, this.Risk, this.Chance);
        }
        
    }
}