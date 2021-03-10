using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public static class HospitalManager
    {
        public static string GenerateName()
        {
            var rng = new Random();
            string[] firstNames = new string[]
                    {
                "Maria",
                "Erik",
                "Anna",
                "Lars",
                "Margareta",
                "Karl",
                "Elisabeth",
                "Anders",
                "Eva",
                "Johan",
                "Kristina",
                "Per",
                "Birgitta",
                "Nils",
                "Karin",
                "Carl",
                "Marie",
                "Mikael",
                "Elisabet",
                "Jan",
                "Ingrid",
                "Hans",
                "Christina",
                "Peter",
                "Sofia",
                "Olof",
                "Linnéa",
                "Lennart",
                "Kerstin",
                "Gunnar",
                "Lena",
                "Sven",
                "Helena",
                "Fredrik",
                "Marianne",
                "Daniel",
                "Emma",
                "Bengt",
                "Linnea",
                "Bo",
                "Johanna",
                "Alexander",
                "Inger",
                "Gustav",
                "Sara",
                "Göran",
                "Cecilia",
                "Åke",
                "Elin",
                "Magnus"
                    };
            string[] lastNames = new string[]
                {
                "Andersson",
                "Johansson",
                "Karlsson",
                "Nilsson",
                "Eriksson",
                "Larsson",
                "Olsson",
                "Persson",
                "Svensson",
                "Gustafsson",
                "Pettersson",
                "Jonsson",
                "Jansson",
                "Hansson",
                "Bengtsson",
                "Carlsson",
                "Jönsson",
                "Lindberg",
                "Petersson",
                "Magnusson",
                "Lindström",
                "Gustavsson",
                "Olofsson",
                "Lindgren",
                "Axelsson",
                "Bergström",
                "Lundberg",
                "Lundgren",
                "Berg",
                "Jakobsson",
                "Berglund",
                "Sandberg",
                "Fredriksson",
                "Mattsson",
                "Sjöberg",
                "Forsberg",
                "Henriksson",
                "Lindqvist",
                "Lind",
                "Engström",
                "Eklund",
                "Lundin",
                "Danielsson",
                "Ali",
                "Håkansson",
                "Holm",
                "Gunnarsson",
                "Bergman",
                "Samuelsson",
                "Fransson"
                };

            return firstNames[rng.Next(0, firstNames.Length)] + " " + lastNames[rng.Next(0, lastNames.Length)];
        }
        internal static Queue<ExtraDoctor> GenerateExtraDoctors()
        {
            var extraDoctors = new Queue<ExtraDoctor>();
            while (extraDoctors.Count != 10)
            {
                extraDoctors.Enqueue(new ExtraDoctor());
            }
            return extraDoctors;
        }
        internal static Queue<Patient> GeneratePatientList(int nrOfPatients)
        {
            var patients = new Queue<Patient>();
            while (patients.Count != nrOfPatients)
            {
                patients.Enqueue(new Patient());
            }
            return patients;
        }

        internal static void CheckConditionThenTreatment(Hospital hp, IDepartmentList idl)
        {
            while (idl.PatientList.Count != idl.MaxPatientList) //check patient condition, if "sick" add to list if there is room
            {
                if (hp.PatientQueue.PatientList.Count == 0)
                {
                    break;
                }
                var patient = hp.PatientQueue.PatientList.Dequeue();
                if (patient.Condition == Condition.Deceased)
                {
                    hp.AfterLife.DeadPatients.Add(patient);
                }
                else if (patient.Condition == Condition.Healthy)
                {
                    hp.CheckedOut.HealthyPatients.Add(patient);
                }
                else
                {
                    idl.PatientList.Add(patient);
                }

            }

            for (int i = 0; i < idl.PatientList.Count; i++) //If threatment cured or killed patient, added to new list and removed from old.
            {
                var patient = idl.PatientList[i];

                patient.CalculateNewHealth(idl as IDepartment);
                if (patient.Condition == Condition.Deceased)
                {
                    hp.AfterLife.DeadPatients.Add(patient);
                    idl.PatientList.RemoveAt(i);
                }
                else if (patient.Condition == Condition.Healthy)
                {
                    hp.CheckedOut.HealthyPatients.Add(patient);
                    idl.PatientList.RemoveAt(i);
                }
            }
        }
    }
}
