using RoberNavigationConsole.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoberNavigationConsole.Objects
{
    public class Rover
    {
        public Rover() { }
        public Rover(Orientation _orientation, bool _valid)
        {
            orientation = _orientation;
            valid = _valid;
        }

        public Orientation orientation { get; set; }
        public bool? valid { get; set; }
    }
}
