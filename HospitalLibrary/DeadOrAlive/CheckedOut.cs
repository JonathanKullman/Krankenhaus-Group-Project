using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class CheckedOut
    {
        public List<Patient> HealthyPatients { get; set; }
        public CheckedOut()
        {
            HealthyPatients = new List<Patient>();
        }
        public CheckedOut Copy()
        {
            var hp = new CheckedOut();
            hp.HealthyPatients = new List<Patient>();
            for (int i = 0; i < HealthyPatients.Count; i++)
            {
                hp.HealthyPatients.Add(this.HealthyPatients[i].Copy());
            }

            return hp;
        }
    }
}
