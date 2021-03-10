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

        public ExtraDoctor Copy()
        {
            var extraDoctor = new ExtraDoctor();
            extraDoctor.Name = this.Name;
            extraDoctor.ExhaustedLevel = this.ExhaustedLevel;
            extraDoctor.Competence = this.Competence;


            return extraDoctor;
        }
    }
}
