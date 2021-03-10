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
        
        public event EventHandler<SendReportEventArgs> SendReport;

        public Hospital(int nrOfPatients)
        {
            extraDoctors = HospitalManager.GenerateExtraDoctors();

            AfterLife = new AfterLife();
            CheckedOut = new CheckedOut();

            PatientQueue = new PatientQueue(nrOfPatients);
            Iva = new IVA(this);
            Sanatorium = new Sanatorium(this);
        }
        public Hospital()
        {

        }
        public void OnTick(int currentTick)
        {
            Iva.OnTickChanges(this);
            Sanatorium.OnTickChanges(this);
            PatientQueue.OnTickChanges();
            SendReportEventArgs eArgs = new SendReportEventArgs(currentTick);
            SendReport?.Invoke(this.Clone(), eArgs);
        }
        public Hospital Clone()
        {
            var hp = new Hospital();
            hp.PatientQueue = (PatientQueue)this.PatientQueue.Clone();
            hp.Iva = (IVA)this.Iva.Clone();
            hp.Sanatorium = (Sanatorium)this.Sanatorium.Clone();
            hp.AfterLife = this.AfterLife.Copy();
            hp.CheckedOut = this.CheckedOut.Copy();

            var tempArray = new ExtraDoctor[this.extraDoctors.Count];

            hp.extraDoctors = new Queue<ExtraDoctor>();

            this.extraDoctors.CopyTo(tempArray, 0);

            for (int i = 0; i < extraDoctors.Count; i++)
            {
                hp.extraDoctors.Enqueue(tempArray[i].Clone());
            }
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
