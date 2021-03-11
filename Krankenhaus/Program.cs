using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

            simulationNr1.Hospital.OnSendReport(simulationNr1.DayCounter);
            Screen.PrintToSCreen(simulationNr1);

            simulationNr1.EveryTick(null);
            while (true)
            {
                Console.ReadKey();
                simulationNr1.Paus();
                Console.WriteLine("\nYou have paused the simulator.");
            }
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
