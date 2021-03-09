using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class IVA : IDepartment
    {
        private int risk;

        public int Risk
        {
            get 
            {
                if (CurrentExtraDoctor == null)
                {
                    return risk;
                }
                else if (CurrentExtraDoctor.Competence >= risk)
                {
                    return 0;
                }
                else 
                {
                    return risk -= CurrentExtraDoctor.Competence;
                }
            }
            set { risk = value; }
        }
        private int chance;

        public int Chance
        {
            get 
            {
                if (CurrentExtraDoctor == null)
                {
                    return chan;
                }
                else
                {
                    return chance += CurrentExtraDoctor.Competence;
                }  
            }

            set { chance = value; }
        }
        public ExtraDoctor CurrentExtraDoctor { get; set; }
        public List<Patient> PatientList { get; set; }
        public int MaxPatientList { get; set; }
        public IVA(Hospital hp)
        {
            MaxPatientList = 5;
            this.Risk = 10;
            this.Chance = 70;
            this.CurrentExtraDoctor = hp.ExtraDoctors.Dequeue();
            OnTickChanges(hp);
        }
        public void OnTickChanges(Hospital hp)
        {

            while (PatientList.Count == MaxPatientList)
            {
                var patient = hp.PatientQueue.Patients.Dequeue();
                if (patient.Condition == Condition.Deceased)
                {
                    hp.AfterLife.DeadPatients.Add(patient);
                }
                else if (patient.Condition == Condition.Healthy)
                {
                    hp.CheckedOut.HealthyPatients.Add(patient);
                }
                else
                {
                    hp.Iva.PatientList.Add(patient);
                }
            }

            for (int i = 0; i < PatientList.Count; i++)
            {
                PatientList[i].CalculateNewHealth(this);
            }

            if (CurrentExtraDoctor != null)
            {
                CurrentExtraDoctor.ExhaustedLevel++;
                if (CurrentExtraDoctor.ExhaustedLevel == 20)
                {
                    hp.PatientQueue.Patients.Enqueue(new Patient()); //läkaren behöver rehabiliteras
                    if (hp.ExtraDoctors.Count > 0)
                    {
                        CurrentExtraDoctor = hp.ExtraDoctors.Dequeue(); //sätt igång nästa läkare
                    }
                    else
                    {
                        CurrentExtraDoctor = null;
                    }
                }
            }




        }
    }
}
