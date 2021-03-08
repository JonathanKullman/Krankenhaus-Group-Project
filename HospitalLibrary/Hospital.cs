using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public class Hospital
    {
        public Queue<ExtraDoctor> ExtraDoctor { get; set; }

        public AfterLife AfterLife { get; set; }

        public CheckedOut CheckedOut { get; set; }

        public Sanatorium Sanatorium { get; set; }

        public IVA Iva { get; set; }

        public PatientQueue PatientQueue { get; set; }

        static void GeneratePatientLine()
        {

        }

        static void CalculateSicknessQueue()
        {

        }

        static void FindAvailableCare()
        {

        }
    }
}
