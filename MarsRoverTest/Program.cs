using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTest
{
    /// <summary>
    /// A program to calculate the end position of Mars rovers after executing 
    /// a series of movement instructions.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // The number of rovers. We could change this to prompt the user for 
            // how many rovers there are, but for now we will assume only two.
            int numRovers = 2;

            // Parse north eastern most coordinate
            string dimensionString = Console.ReadLine();
            Coordinate limits;
            try
            {
                limits = new Coordinate(dimensionString.Trim());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            List<Rover> roverList = new List<Rover>();
            for (int i = 0; i < numRovers; i++)
            {
                // Parse start coordinate
                string startCoordString = Console.ReadLine();
                Coordinate startCoordinate;
                try
                {
                    startCoordinate = new Coordinate(startCoordString.Trim());
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    return;
                }

                // Read movement instructions and create rover and add it to the list.
                string instructions = Console.ReadLine();
                Rover rover = new Rover(startCoordinate, instructions, limits);
                roverList.Add(rover);
            }

            Console.WriteLine();

            // Loop through all the rovers and have them follow their instructions
            // then display their end coordinate
            for (int i = 0; i < numRovers; i++)
            {
                try
                {
                    roverList[i].ExecuteInstructions();
                    Console.WriteLine(roverList[i].Coordinate.Column + " " +
                        roverList[i].Coordinate.Row + " " + roverList[i].Coordinate.Direction);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
