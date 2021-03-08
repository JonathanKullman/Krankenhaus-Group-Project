using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class ExtraDoctor
    {
        public string Name { get; set; }
        public int ExhaustedLevel { get; set; }
        public int Competence { get; set; }
        public bool BurnedOut { get; set; }
        public ExtraDoctor()
        {
            var rng = new Random();
            this.Name = HospitalBuilder.GenerateName();
            this.ExhaustedLevel = 0;
            this.Competence = rng.Next(-10, 30);
        }
    }
}
