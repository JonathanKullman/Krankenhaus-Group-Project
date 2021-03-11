using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public class Hospital
    {
        private Queue<ExtraDoctor> extraDoctors;
        public AfterLife AfterLife { get; private set; }
        public CheckedOut CheckedOut { get; private set; }
        public Sanatorium Sanatorium { get; private set; }
        public IVA Iva { get; private set; }
        public PatientQueue PatientQueue { get; private set; }
        public int CurrentDay { get; private set; }

        public Hospital(int nrOfPatients, int iva, int sanatorium)
        {
            extraDoctors = HospitalManager.GenerateExtraDoctors();
            CurrentDay = 1;
            AfterLife = new AfterLife();
            CheckedOut = new CheckedOut();

            PatientQueue = new PatientQueue(nrOfPatients);
            Iva = new IVA(this, iva);
            Sanatorium = new Sanatorium(this, sanatorium);
            
        }
        private Hospital()
        {

        }
        public void OnTick(int currentTick)
        {
            CurrentDay = currentTick;

            foreach (Patient item in Iva)
            {
                item.DaysTreated++;
            }            
            foreach (Patient item in Sanatorium)
            {
                item.DaysTreated++;
            }
        }

        public Hospital Clone()
        {
            var hp = new Hospital();
            hp.PatientQueue = (PatientQueue)this.PatientQueue.Clone();
            hp.Iva = (IVA)this.Iva.Clone();
            hp.Sanatorium = (Sanatorium)this.Sanatorium.Clone();
            hp.AfterLife = this.AfterLife.Clone();
            hp.CheckedOut = this.CheckedOut.Clone();
            hp.extraDoctors = new Queue<ExtraDoctor>();
            hp.CurrentDay = this.CurrentDay;
            CopyExtraDoctorsToArray().ToList().ForEach(doctor => hp.extraDoctors.Enqueue(doctor.Clone()));
            return hp;
        }
        internal ExtraDoctor DequeueExtraDoctor()
        {
            return extraDoctors.Dequeue();
        }
        public int ExtraDoctorsCount()
        {
            return extraDoctors.Count;
        }
        public ExtraDoctor[] CopyExtraDoctorsToArray()
        {
            var tempDocArray = new ExtraDoctor[extraDoctors.Count];
            extraDoctors.CopyTo(tempDocArray, 0);
            return tempDocArray;
        }
    }
}
