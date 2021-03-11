using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class AfterLife : IEnumerable
    {
        private List<Patient> deadPatients;
        internal AfterLife()
        {
            deadPatients = new List<Patient>();
        }
        internal AfterLife Clone()
        {
            var al = new AfterLife();
            al.deadPatients = new List<Patient>();
            for (int i = 0; i < deadPatients.Count; i++)
            {
                al.deadPatients.Add(this.deadPatients[i].Clone());
            }
            return al;
        }
        internal void AddDeadPatients(Patient patient)
        {
            deadPatients.Add(patient);
        }
        public int CountDeadPatients()
        {
            return deadPatients.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return deadPatients.GetEnumerator();
        }
    }
}
