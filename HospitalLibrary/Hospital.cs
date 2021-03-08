using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public class Hospital
    {
        public List<ExtraDoctor> ExtraDoctors { get; set; }
        public AfterLife AfterLife { get; set; }
        public CheckedOut CheckedOut { get; set; }
        public Sanatorium Sanatorium { get; set; }
        public IVA Iva { get; set; }
        public PatientQueue PatientQueue { get; set; }

        public List<Patient> PatientList { get; set; }
        public Hospital(int nrOfPatients)
        {
            this.ExtraDoctors = HospitalBuilder.GenerateExtraDoctorQueue();
            this.PatientList = HospitalBuilder.GeneratePatientList(nrOfPatients);
            this.AfterLife = new AfterLife();
            this.CheckedOut = new CheckedOut();
            this.Sanatorium = new Sanatorium();
            this.Iva = new IVA();
            this.PatientQueue = new PatientQueue();


        }


        static void CalculateSicknessQueue()
        {

        }

        static void FindAvailableCare()
        {

        }
    }
}
