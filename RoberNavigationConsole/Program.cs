using RoberNavigationConsole.Methods;
using RoberNavigationConsole.Objects;
using RoberNavigationConsole.Util;
using System;
using System.ComponentModel.Design;

namespace RoberNavigationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rober Navigation Software!.");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");
            int x = InputUtil.NumberField("Insert the Horitonzal Cube Dimension: ",false);
            int y = InputUtil.NumberField("Insert the Vertical Cube Dimension: ", false);
            Coordinate cube = new Coordinate(x, y); 
            Console.Clear();
            Console.WriteLine("Perfect!, Let's configure our new Rober!.");
            Console.WriteLine("----------------------------------------");
            int roberx = InputUtil.NumberField("Insert the Horizontal Rober Coordenate: ", false);
            int robery = InputUtil.NumberField("Insert the Vertical Rober Coordenate: ", false);
            Console.Clear();
            Console.Write("Alright, we almost done");
            Console.WriteLine();
            char orientation = InputUtil.PoleField("Insert the Rober Orientation(N, S, E, W): ", false);
            Rover rover = new Rover(new Orientation(roberx, robery, orientation), false);
            Console.Clear();
            Console.WriteLine("Done, Configuration Completed!");
            Console.WriteLine("Lets Play!");
            Console.WriteLine("------------------------------");
            string? commands = "";
            do {
                Console.WriteLine();
                 commands = InputUtil.CommandField("Insert the commands!: ",false);
                Rover newRover = Movement.move(cube, rover.orientation, commands);
                Console.WriteLine(newRover.valid + " " + newRover.orientation.pole + " Coordinates: (" + newRover.orientation.x + ", " + newRover.orientation.y + ")");
            }
            while (commands != null);

        }
    }
}
