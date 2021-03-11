using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class IVA : IDepartment, IDepartmentList
    {
        private int risk;
        public int Risk
        {
            get 
            {
                if (ExtraDoctor == null)
                {
                    return risk;
                }
                else if (ExtraDoctor.Competence >= risk)
                {
                    return 0;
                }
                else 
                {
                    return risk -= ExtraDoctor.Competence;
                }
            }
        }
        private int chance;
        public int Chance
        {
            get 
            {
                if (ExtraDoctor == null)
                {
                    return chance;
                }
                else
                {
                    return chance += ExtraDoctor.Competence;
                }  
            }
        }

        private List<Patient> patients;
        public int MaxPatients { get; }
        public ExtraDoctor ExtraDoctor { get; private set; }

        public IVA(Hospital hp, int maxPatients)
        {
            this.ExtraDoctor = hp.DequeueExtraDoctor();
            this.patients = new List<Patient>();
            this.MaxPatients = maxPatients;
            this.risk = 10;
            this.chance = 70;
            OnTickChanges(hp);
        }
        private IVA(ExtraDoctor extraDoctor, List<Patient> patients, int maxPatients, int risk, int chance)
        {
            this.ExtraDoctor = extraDoctor;
            this.patients = patients;
            this.MaxPatients = maxPatients;
            this.risk = risk;
            this.chance = chance;
        }
        public void OnTickChanges(object state)
        {
            var hp = state as Hospital;
            HospitalManager.CheckConditionAndTreat(hp, this);

            if (ExtraDoctor != null) // Handles extra doctors if they still exists.
            {
                if (patients.Count != 0)
                {
                    ExtraDoctor.ExhaustedLevel += 5;
                }
                
                if (ExtraDoctor.ExhaustedLevel >= 20)
                {
                    if (hp.ExtraDoctorsCount() > 0)
                    {
                        ExtraDoctor = hp.DequeueExtraDoctor();
                    }
                    else
                    {
                        ExtraDoctor = null;
                    }
                }
            }
        }
        public IDepartment Clone()
        {
            var patientsCopy = new List<Patient>();
            patients.ForEach(patient => patientsCopy.Add(patient.Clone()));
            return new IVA(this.ExtraDoctor, patientsCopy, this.MaxPatients, this.Risk, this.Chance);
        }
        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }
        public void RemovePatient(Patient patient)
        {
            patients.Remove(patient);
        }
        public int PatientsCount()
        {
            return patients.Count;
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
