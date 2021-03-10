using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public enum Condition { Healthy = 0, Sick, Deceased = 10 }
    public class Patient
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int SicknessLevel { get; set; }
        public Condition Condition { get; set; }
        public DateTime? TimeOfCheckOut { get; set; }

        public Patient()
        {
            var rng = new Random();
            Name = HospitalManager.GenerateName();
            Birthday = DateTime.Now.AddDays(-rng.Next(1 * 365, 90 * 365)).Date;
            SicknessLevel = rng.Next(0, 10);
            CheckPatientHealth();
        }

        internal void CheckPatientHealth()
        {
            if (SicknessLevel == 0)
            {
                Condition = Condition.Healthy;
                TimeOfCheckOut = DateTime.Now;
            }
            else if (SicknessLevel == 10)
            {
                Condition = Condition.Deceased;
                TimeOfCheckOut = DateTime.Now;
            }
            else
            {
                Condition = Condition.Sick;
                TimeOfCheckOut = null;
            }
        }
        internal void CalculateNewHealth(IDepartment department)
        {
            var rng = new Random();
            int rngValue = rng.Next(1,101);

            if (SicknessLevel == 0 || SicknessLevel == 10)
            {
                return;
            }

            if (rngValue <= department.Risk)
            {
                SicknessLevel++;
            }
            else if (rngValue >= 100 - department.Chance)
            {
                SicknessLevel--;
            }
            CheckPatientHealth();
        }
        public Patient Copy()
        {
            var patient = new Patient();
            patient.Name = this.Name;
            patient.Birthday = this.Birthday;
            patient.SicknessLevel = this.SicknessLevel;
            patient.TimeOfCheckOut = this.TimeOfCheckOut;
            patient.Condition = this.Condition;

            return patient;
        }
    }
}
