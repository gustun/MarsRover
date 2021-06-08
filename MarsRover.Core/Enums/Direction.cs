using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Core.Enums
{
    public class Direction
    {
        public Direction(char key, string description) =>
            (Key, Description) = (key, description);

        public char Key { get; }
        public string Description { get; }

        public Direction Right
        {
            get => _right;
            set
            {
                if (_right == null)
                    _right = value;
            }
        }

        private Direction _right;

        public Direction Left
        {
            get => _left;
            set
            {
                if (_left == null)
                    _left = value;
            }
        }

        private Direction _left;
    }

    public class Directions
    {
        public static readonly Direction NORTH = new Direction('N', "North");
        public static readonly Direction EAST = new Direction('E', "East");
        public static readonly Direction SOUTH = new Direction('S', "South");
        public static readonly Direction WEST = new Direction('W', "West");

        static Directions()
        {
            NORTH.Right = EAST;
            NORTH.Left = WEST;

            EAST.Right = SOUTH;
            EAST.Left = NORTH;

            SOUTH.Right = WEST;
            SOUTH.Left = EAST;

            WEST.Right = NORTH;
            WEST.Left = SOUTH;
            Values = new Dictionary<char, Direction>
            {
                {NORTH.Key, NORTH},
                {SOUTH.Key, SOUTH},
                {EAST.Key, EAST},
                {WEST.Key, WEST},
            };
        }

        public static Dictionary<char, Direction> Values { get; }

        public static Direction GetByKey(char key)
        {
            var getResult = Values.TryGetValue(key, out var result);
            if (!getResult) throw new Exception($"invalid direction character: ${key}");
            return result;
        }
    }
}