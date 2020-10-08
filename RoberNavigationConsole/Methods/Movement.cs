using RoberNavigationConsole.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoberNavigationConsole.Methods
{
    public static class Movement
    {
        private static readonly Orientation north = new Orientation()
        {
            x = 0,
            y = 1,
            pole = 'N'
        };
        private static readonly Orientation sur = new Orientation()
        {
            x = 0,
            y = -1,
            pole = 'S'
        };
        private static readonly Orientation east = new Orientation()
        {
            x = 1,
            y = 0,
            pole = 'E'
        };
        private static readonly Orientation west = new Orientation()
        {
            x = -1,
            y = 0,
            pole = 'W'
        };
        private static readonly Orientation[] poles = new[]
        {
            north, sur, east, west
        };
        public static Rover move(Coordinate Cube, Orientation Position, string commands)
        {

            Rover rover = new Rover() { orientation = Position, valid = true };
            Orientation nextMove = poles.First((a)=> a.pole == Position.pole);

            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'L':
                        nextMove = calculateMove(nextMove, -1);
                        break;
                    case 'R':
                        nextMove = calculateMove(nextMove, 1);
                        break;
                    case 'A':
                        //
                        break;
                }
                rover.orientation.x += nextMove.x;
                rover.orientation.y += nextMove.y;
                rover.orientation.pole = nextMove.pole;
            }
            if ((rover.orientation.x <= Cube.x && rover.orientation.x >= 0) && (rover.orientation.y <= Cube.y && rover.orientation.y >= 0))
            {
                rover.valid = true;
            }
            else
            {
                rover.valid = false;
            }

            return rover;
        }

        private static Orientation calculateMove(Orientation position, int movement)
        {
            Orientation move = new Orientation();
            if (position.x == 0)
            {
                move.y = position.y + (position.y * -1);
                move.x = position.x + (movement * position.y);
            }
            else
            {
                move.x = position.x + (position.x * -1);
                move.y = position.y - (movement * position.x);
            }
            move.pole = poles.FirstOrDefault((a) => a.x == move.x && a.y == move.y).pole;
            return move;
        }
    }
}
