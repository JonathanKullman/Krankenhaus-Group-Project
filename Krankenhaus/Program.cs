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
            Console.WriteLine("Welcome to Hospital Simulator 3000");
            Console.WriteLine($"Total number of patients: ");
            int nrOfPatients = ReadInt();
            Console.WriteLine($"Enter IVA's patient limit:");
            int iva = ReadInt();
            Console.WriteLine($"Enter Sanatorium's patient limit:");
            int sanatorium = ReadInt();
            var simulationNr1 = new Simulation(nrOfPatients, iva, sanatorium);

            Screen.PrintToSCreen(simulationNr1);


            ConsoleKey input = ConsoleKey.Enter;
            while (input != ConsoleKey.Escape)
            {
                input = Console.ReadKey().Key;
                simulationNr1.Paus();
                if (input != ConsoleKey.Escape)
                {
                    Console.WriteLine("\nYou have paused/resumed the simulator. ESC to Exit.");
                }
                else if (input == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
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
