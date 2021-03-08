using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class Patient
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public byte SicknessLevel { get; set; }
        public bool IsDead { get; set; }
        public bool IsHealthy { get; set; }
        public DateTime? TimeOfCheckOut { get; set; }
    }
}
