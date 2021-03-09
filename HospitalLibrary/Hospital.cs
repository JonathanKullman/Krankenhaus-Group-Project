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
            this.ExtraDoctors = HospitalBuilder.GenerateExtraDoctors();

            this.AfterLife = new AfterLife();
            this.CheckedOut = new CheckedOut();

            this.PatientQueue = new PatientQueue(nrOfPatients);
            this.Iva = new IVA(this);
            this.Sanatorium = new Sanatorium();

            


        }
        public void OnTick()
        {
            Iva.OnTickChanges(this);
            Sanatorium.OnTickChanges();
            PatientQueue.OnTickChanges();

            
        }

    }
}
