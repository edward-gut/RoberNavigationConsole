using Microsoft.VisualBasic.CompilerServices;
using RoberNavigationConsole.Util;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RoberNavigationConsole.Objects
{
    public class Coordinate
    {
        public Coordinate() { }
        public Coordinate(int _x, int _y) {
            x = _x;
            y = _y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
}
