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
        public ExtraDoctor()
        {
            var rng = new Random();
            Name = HospitalManager.GenerateName();
            ExhaustedLevel = 0;
            Competence = rng.Next(-10, 31);
        }
        private ExtraDoctor(string name, int exhaustedLevel, int competence)
        {
            Name = name;
            ExhaustedLevel = exhaustedLevel;
            Competence = competence;
        }
        public ExtraDoctor Clone()
        {
            var extraDoctor = new ExtraDoctor(this.Name, this.ExhaustedLevel, this.Competence);
            return extraDoctor;
        }
    }
}
