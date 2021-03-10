using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class CheckedOut : IEnumerable
    {
        private List<Patient> healthyPatients;
        internal CheckedOut()
        {
            healthyPatients = new List<Patient>();
        }
        internal CheckedOut Clone()
        {
            var checkedOutCopy = new CheckedOut();
            checkedOutCopy.healthyPatients = new List<Patient>();
            for (int i = 0; i < healthyPatients.Count; i++)
            {
                checkedOutCopy.healthyPatients.Add(this.healthyPatients[i].Clone());
            }
            return checkedOutCopy;
        }
        internal void AddHealthyPatients(Patient patient)
        {
            healthyPatients.Add(patient);
        }
        public int CountHealthyPatients()
        {
            return healthyPatients.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return healthyPatients.GetEnumerator();
        }
    }
}
