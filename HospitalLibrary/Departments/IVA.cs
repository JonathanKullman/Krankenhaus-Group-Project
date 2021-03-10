using System;
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
                    return chance;
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
            this.CurrentExtraDoctor = hp.DequeueExtraDoctor();
            PatientList = new List<Patient>();
            OnTickChanges(hp);
        }
        public IVA()
        {
        }
        
        public void OnTickChanges(Hospital hp)
        {

            HospitalManager.CheckConditionThenTreatment(hp, this);

            if (CurrentExtraDoctor != null) //handles extraDoctors if they still exists
            {
                if (PatientList.Count != 0)
                {
                    CurrentExtraDoctor.ExhaustedLevel += 5;
                }
                
                if (CurrentExtraDoctor.ExhaustedLevel >= 20)
                {
                    if (hp.ExtraDoctorCount() > 0)
                    {
                        CurrentExtraDoctor = hp.DequeueExtraDoctor(); //sätt igång nästa läkare
                    }
                    else
                    {
                        CurrentExtraDoctor = null;
                    }
                }
            }


        }
        public IDepartment Copy()
        {
            var dep = new IVA();
            dep.PatientList = new List<Patient>();
            dep.CurrentExtraDoctor = this.CurrentExtraDoctor.Copy();

            for (int i = 0; i < PatientList.Count; i++)
            {
                dep.PatientList.Add(this.PatientList[i].Copy());
            }

            return dep;
        }
    }
}
