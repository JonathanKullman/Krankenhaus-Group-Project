using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public enum Condition { Healthy = 0, Sick, Deceased = 10 }
    public enum Department { IVA, Sanatorium, PatientQueue }
    public class Patient
    {
        public string Name { get; }
        public DateTime Birthday { get; }
        public int SicknessLevel { get; private set; }
        public int DaysPassed { get; set; }
        public int DaysTreated { get; set; }
        public Department Department { get; set; }
        public Condition Condition 
        { 
            get
            {
                if (SicknessLevel == 10)
                    return Condition.Deceased;
                else if (SicknessLevel == 0)
                    return Condition.Healthy;
                else
                    return Condition.Sick;
            }
        }
        public DateTime? TimeOfCheckOut { get; internal set; }

        public Patient()
        {
            var rng = new Random();
            Department = Department.PatientQueue;
            Name = HospitalManager.GenerateName();
            Birthday = DateTime.Now.AddDays(-rng.Next(1 * 365, 90 * 365)).Date;
            SicknessLevel = rng.Next(0, 10);
        }
        private Patient(string name, DateTime birthdate, int sicknessLevel, 
            DateTime? timeOfCheckout, int daysPassed, int daysTreated, Department dep)
        {
            Name = name;
            Birthday = birthdate;
            SicknessLevel = sicknessLevel;
            TimeOfCheckOut = timeOfCheckout;
            DaysPassed = daysPassed;
            DaysTreated = daysTreated;
            Department = dep;
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
        }
        public Patient Clone()
        {
            var patient = new Patient(this.Name, this.Birthday, this.SicknessLevel,
                this.TimeOfCheckOut, this.DaysPassed, this.DaysTreated, this.Department);
            return patient;
        }
    }
}
