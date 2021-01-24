using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTest
{
    class Coordinate
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char Direction { get; set; }

        public Coordinate(string coordinateString)
        {
            ParseCoordinate(coordinateString);
        }

        /// <summary>
        /// ParseCoordinate
        /// Read x and y coordinates and cardinal direction from a string.
        /// 
        /// If the string does not include a cardinal direction, it will default to North.
        /// This should only apply for reading the north-eastern most coordinate, since
        /// the direction is irrelevant.
        /// </summary>
        /// <param name="coordinateString">String to be parsed.</param>
        private void ParseCoordinate(string coordinateString)
        {
            int columns = 0;
            int rows = 0;
            string[] coordinateSplit = coordinateString.Split(' ');
            if (!(int.TryParse(coordinateSplit[0], out columns)) || !(int.TryParse(coordinateSplit[1], out rows)))
            {
                throw new InvalidOperationException("ERROR: coordinates must be two integers divided by a single space.");
            }
            Column = columns;
            Row = rows;

            Direction = 'N';
            if (coordinateSplit.Length == 3)
            {
                Direction = coordinateSplit[2][0];
            }
        }
    }
}
