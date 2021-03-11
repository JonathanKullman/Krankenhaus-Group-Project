using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary
{
    public class PatientQueue : IDepartment
    {
        private readonly object patientLock = new object();
        public int Risk { get; }
        public int Chance { get; }

        private Queue<Patient> patients;

        public PatientQueue(int nrOfPatients)
        {
            Risk = 80;
            Chance = 5;
            patients = HospitalManager.GeneratePatientList(nrOfPatients);
            OnTickChanges(null);
        }
        private PatientQueue(Queue<Patient> patients, int risk, int chance)
        {
            this.patients = patients;
            this.Risk = risk;
            this.Chance = chance;
        }
        public void OnTickChanges(object state)
        {
            lock (patientLock)
            {
                CopyPatientsToArray().ToList().ForEach(patient => patient.CalculateNewHealth(this));
            }
            if (state != null)
            {
                var hp = state as Hospital;
                if (hp.Iva.MaxPatients == 0 && hp.Sanatorium.MaxPatients == 0)
                {
                    for (int i = 0; i < PatientsCount(); i++)
                    {
                        var p = Dequeue();
                        if (p.Condition == Condition.Deceased)
                        {
                            p.DaysPassed = hp.CurrentDay;
                            p.TimeOfCheckOut = DateTime.Now;
                            hp.AfterLife.AddDeadPatients(p);
                        }
                        else if (p.Condition == Condition.Healthy)
                        {
                            p.DaysPassed = hp.CurrentDay;
                            p.TimeOfCheckOut = DateTime.Now;
                            hp.CheckedOut.AddHealthyPatients(p);
                        }
                        else
                        {
                            patients.Enqueue(p);
                        }
                    }
                }
            }

        }
        internal Patient Dequeue()
        {
            lock (patientLock)
            {
                return patients.Dequeue();
            }
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