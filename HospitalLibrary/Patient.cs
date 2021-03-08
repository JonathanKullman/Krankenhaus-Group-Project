using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class Patient
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int SicknessLevel { get; set; }
        public bool IsDead { get; set; }
        public bool IsHealthy { get; set; }
        public DateTime? TimeOfCheckOut { get; set; }

        public Patient()
        {
            var rng = new Random();
            this.Name = HospitalBuilder.GenerateName();
            this.Birthday = DateTime.Now.AddDays(-rng.Next(1 * 365, 90 * 365)).Date;
            this.SicknessLevel = rng.Next(0, 10);
            if (SicknessLevel == 0)
            {
                IsHealthy = true;
                TimeOfCheckOut = DateTime.Now;
            }
            else if (SicknessLevel == 10)
            {
                IsDead = true;
                TimeOfCheckOut = DateTime.Now;
            }
            else
            {
                IsHealthy = false;
                IsDead = false;
                TimeOfCheckOut = null;
            }
        }
    }
}
