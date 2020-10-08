using System;
using System.Collections.Generic;
using System.Text;

namespace RoberNavigationConsole.Objects
{
    public class Orientation : Coordinate
    {
        public Orientation() { }
        public Orientation(int _x, int _y, char _pole)
        {
            x = _x;
            y = _y;
            pole = _pole;
        }

        public char pole { get; set; }
    }
}
