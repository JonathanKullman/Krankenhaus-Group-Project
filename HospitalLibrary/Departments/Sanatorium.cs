using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class Sanatorium : IDepartment, IDepartmentList
    {
        public int Risk { get; }
        public int Chance { get; }

        private List<Patient> patients;
        public int MaxPatients { get; }
        public Sanatorium(Hospital hp, int maxPatients)
        {
            MaxPatients = maxPatients;
            Risk = 50;
            Chance = 35;
            patients = new List<Patient>();
            OnTickChanges(hp);
        }
        private Sanatorium(List<Patient> patients, int maxPatients, int risk, int chance)
        {
            this.patients = patients;
        }
        public void OnTickChanges(object state)
        {
            var hp = state as Hospital;
            HospitalManager.CheckConditionAndTreat(hp, this);
        }
        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }
        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
        }
        internal Patient MoveToIVA()
        {
            var patient = patients[0];
            patients.Remove(patient);
            return patient;
        }
        public int PatientsCount()
        {
            return patients.Count;
        }
        public IDepartment Clone()
        {
            var patientsCopy = new List<Patient>();
            patients.ForEach(patient => patientsCopy.Add(patient.Clone()));
            return new Sanatorium(patientsCopy, this.MaxPatients, this.Risk, this.Chance);
        }
        public Patient this[int i]
        {
            get { return patients[i]; }
        }
        public IEnumerator GetEnumerator()
        {
            return patients.GetEnumerator();
        }
    }
}
