using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary;

namespace Krankenhaus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"How many patients?");
            int nrOfPatients = ReadInt();
            var simulationNr1 = new Simulation(nrOfPatients);

            



        }
        /// <summary>
        /// Runs a TryParse-loop for integers. Prompts user to retry while it's not a number.
        /// </summary>
        /// <returns></returns>
        static int ReadInt()
        {
            int integer;
            while (!int.TryParse(Console.ReadLine(), out integer))
            {
                Console.WriteLine("Invalid input. You have to use a number.");
            }
            return integer;
        }
    }
}
