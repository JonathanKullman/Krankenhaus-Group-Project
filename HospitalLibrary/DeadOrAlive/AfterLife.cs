using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class AfterLife
    {
        public List<Patient> DeadPatients { get; set; }
        public AfterLife()
        {
            DeadPatients = new List<Patient>();
        }
        public AfterLife Clone()
        {
            var al = new AfterLife();
            al.DeadPatients = new List<Patient>();
            for (int i = 0; i < DeadPatients.Count; i++)
            {
                al.DeadPatients.Add(this.DeadPatients[i].Copy());
            }

            return al;
        }
    }
}
