using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class AfterLife
    {
        private List<Patient> deadPatients;
        internal AfterLife()
        {
            deadPatients = new List<Patient>();
        }
        internal AfterLife Copy()
        {
            var al = new AfterLife();
            al.deadPatients = new List<Patient>();
            for (int i = 0; i < deadPatients.Count; i++)
            {
                al.deadPatients.Add(this.deadPatients[i].Copy());
            }
            return al;
        }
    }
}
