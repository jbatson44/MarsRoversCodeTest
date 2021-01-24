using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTest
{
    class Rover
    {
        public Coordinate Coordinate { get; set; }
        public string MoveInstructions { get; set; }
        public Coordinate Limits { get; set; }

        public Rover(Coordinate coordinate, string moveInstructions, Coordinate limits)
        {
            Coordinate = coordinate;
            MoveInstructions = moveInstructions;
            Limits = limits;
        }

        /// <summary>
        /// ExecuteInstructions
        /// Loop through the series of instructions given to the rover.
        /// </summary>
        public void ExecuteInstructions()
        {
            int numInstructions = MoveInstructions.Length;
            for (int i = 0; i < numInstructions; i++)
            {
                UpdateCoordinate(MoveInstructions[i]);
            }
        }

        /// <summary>
        /// UpdateCoordinate
        /// Perform a single instruction and then update the rover's current coordinate.
        /// </summary>
        /// <param name="instruction">A single instruction for the rover.</param>
        private void UpdateCoordinate(char instruction)
        {
            switch (instruction)
            {
                case 'L':
                case 'R':
                    TurnRover(instruction);
                    break;
                case 'M':
                    MoveRover();
                    break;
                default:
                    throw new InvalidOperationException("ERROR: \"" + instruction + "\" is not a valid instruction");
                   
            }
        }

        /// <summary>
        /// MoveRover
        /// Updates the rovers current coordinates based on the direction the rover is facing.
        /// If the instruction leads outside the grid an InvalidOperationException is thrown.
        /// </summary>
        private void MoveRover()
        {
            // move North
            if (Coordinate.Direction == 'N')
            {   
                if (Coordinate.Row == Limits.Row)
                {
                    throw new InvalidOperationException("ERROR: directions will send rover out of exploration grid.");
                }
                Coordinate.Row += 1;
            }
            // move South
            else if (Coordinate.Direction == 'S')
            {
                if (Coordinate.Row == 0)
                {
                    throw new InvalidOperationException("ERROR: directions will send rover out of exploration grid.");
                }
                Coordinate.Row -= 1;
            }
            // move East
            else if (Coordinate.Direction == 'E')
            {
                if (Coordinate.Column == Limits.Column)
                {
                    throw new InvalidOperationException("ERROR: directions will send rover out of exploration grid.");
                }
                Coordinate.Column += 1;
            }
            // move West
            else if (Coordinate.Direction == 'W')
            {
                if (Coordinate.Column == 0)
                {
                    throw new InvalidOperationException("ERROR: directions will send rover out of exploration grid.");
                }
                Coordinate.Column -= 1;
            }
        }

        /// <summary>
        /// TurnRover
        /// Update the rovers direction after a turning left or right.
        /// </summary>
        /// <param name="turnDirection">Direction to turn the rover. Either L (left) or R (right)</param>
        private void TurnRover(char turnDirection)
        {
            // turn 90 degrees to the left
            if (turnDirection == 'L')
            {
                if (Coordinate.Direction == 'N')
                {
                    Coordinate.Direction = 'W';
                }
                else if (Coordinate.Direction == 'S')
                {
                    Coordinate.Direction = 'E';
                }
                else if (Coordinate.Direction == 'E')
                {
                    Coordinate.Direction = 'N';
                }
                else if (Coordinate.Direction == 'W')
                {
                    Coordinate.Direction = 'S';
                }
            }
            // turn 90 degrees to the right
            else if (turnDirection == 'R')
            {
                if (Coordinate.Direction == 'N')
                {
                    Coordinate.Direction = 'E';
                }
                else if (Coordinate.Direction == 'S')
                {
                    Coordinate.Direction = 'W';
                }
                else if (Coordinate.Direction == 'E')
                {
                    Coordinate.Direction = 'S';
                }
                else if (Coordinate.Direction == 'W')
                {
                    Coordinate.Direction = 'N';
                }
            }
        }
    }
}
