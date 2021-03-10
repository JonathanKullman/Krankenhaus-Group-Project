using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public class Hospital
    {
        public Queue<ExtraDoctor> ExtraDoctors { get; private set; }
        public AfterLife AfterLife { get; private set; }
        public CheckedOut CheckedOut { get; private set; }
        public Sanatorium Sanatorium { get; private set; }
        public IVA Iva { get; private set; }
        public PatientQueue PatientQueue { get; private set; }
        public event EventHandler SendReport;

        public Hospital(int nrOfPatients)
        {
            ExtraDoctors = HospitalManager.GenerateExtraDoctors();

            AfterLife = new AfterLife();
            CheckedOut = new CheckedOut();

            PatientQueue = new PatientQueue(nrOfPatients);
            Iva = new IVA(this);
            Sanatorium = new Sanatorium(this);
        }
        public Hospital()
        {

        }
        public void OnTick()
        {
            Iva.OnTickChanges(this);
            Sanatorium.OnTickChanges(this);
            PatientQueue.OnTickChanges();

            SendReport?.Invoke(this.Copy(), EventArgs.Empty);
        }
        public Hospital Copy()
        {
            var hp = new Hospital();
            hp.PatientQueue = (PatientQueue)this.PatientQueue.Clone();
            hp.Iva = (IVA)this.Iva.Clone();
            hp.Sanatorium = (Sanatorium)this.Sanatorium.Clone();
            hp.AfterLife = this.AfterLife.Clone();
            hp.CheckedOut = this.CheckedOut.Clone();

            var tempArray = new ExtraDoctor[this.ExtraDoctors.Count];

            hp.ExtraDoctors = new Queue<ExtraDoctor>();

            this.ExtraDoctors.CopyTo(tempArray, 0);

            for (int i = 0; i < ExtraDoctors.Count; i++)
            {
                hp.ExtraDoctors.Enqueue(tempArray[i].Copy());
            }


            return hp;
        }
    }
}
