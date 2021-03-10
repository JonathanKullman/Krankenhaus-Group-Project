using System;
using System.Collections.Generic;

namespace HospitalLibrary
{
    public class PatientQueue : IDepartment
    {
        public int Risk { get; set; }
        public int Chance { get; set; }
        public Queue<Patient> PatientList { get; set; }
        public int NumOfPatientsAtStart { get; set; }
        public PatientQueue(int nrOfPatients)
        {
            NumOfPatientsAtStart = nrOfPatients;
            Risk = 80;
            Chance = 5;
            PatientList = HospitalManager.GeneratePatientList(NumOfPatientsAtStart);
            OnTickChanges();
        }
        public PatientQueue()
        {

        }
        public void OnTickChanges()
        {
            var tempArray = new Patient[PatientList.Count];
            PatientList.CopyTo(tempArray, 0);
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i].CalculateNewHealth(this);
            }

        }
        public IDepartment Copy()
        {
            var dep = new PatientQueue();
            
            var tempArray = new Patient[this.PatientList.Count];

            dep.PatientList = new Queue<Patient>();
            dep.PatientList.CopyTo(tempArray, 0);

            for (int i = 0; i < PatientList.Count; i++)
            {
                dep.PatientList.Enqueue(tempArray[i].Copy());
            }
            return dep;
        }
        
    }
}