using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class ExtraDoctor
    {
        public string Name { get; set; }
        public byte ExhaustedLevel { get; set; }
        public byte Competence { get; set; }
        public bool BurnedOut { get; set; }
        public ExtraDoctor()
        {
            
        }
    }
}
