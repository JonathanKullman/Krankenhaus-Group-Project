using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public class Hospital
    {
        public Queue<ExtraDoctor> ExtraDoctors { get; set; }
        public AfterLife AfterLife { get; set; }
        public CheckedOut CheckedOut { get; set; }
        public Sanatorium Sanatorium { get; set; }
        public IVA Iva { get; set; }
        public PatientQueue PatientQueue { get; set; }

        public Hospital(int nrOfPatients)
        {
            ExtraDoctors = HospitalManager.GenerateExtraDoctors();

            AfterLife = new AfterLife();
            CheckedOut = new CheckedOut();

            PatientQueue = new PatientQueue(nrOfPatients);
            Iva = new IVA(this);
            Sanatorium = new Sanatorium();

            
        }
        public void OnTick()
        {
            Iva.OnTickChanges(this);
            Sanatorium.OnTickChanges(this);
            PatientQueue.OnTickChanges();
        }

    }
}
