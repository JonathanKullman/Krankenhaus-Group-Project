using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class HospitalBuilder
    {

        public Hospital CreateHospital()
        {
            return new Hospital();
        }
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
        internal static List<ExtraDoctor> GenerateExtraDoctorQueue()
        {
            var extraDoctors = new List<ExtraDoctor>();
            while (extraDoctors.Count != 10)
            {
                extraDoctors.Add(new ExtraDoctor());
            }
            return extraDoctors;
        }
        internal static List<Patient> GeneratePatientList(int nrOfPatients)
        {
            var extraDoctors = new List<Patient>();
            while (extraDoctors.Count != nrOfPatients)
            {
                extraDoctors.Add(new Patient());
            }
            return extraDoctors;
        }
    }
}
