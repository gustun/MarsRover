using System;
using System.Linq;
using MarsRover.Core.Enums;

namespace MarsRover.Core
{
    public class Position
    {
        public Position()
        {
        }

        public Position(string input)
        {
            var values = input.Split(' ');
            if (values.Length != 3) throw new Exception($"invalid input for position: {input}");
            
            var xParseResult = int.TryParse(values[0], out var xaxisValue);
            if (!xParseResult) throw new Exception($"invalid input for x axis: {input}");
            
            var yParseResult = int.TryParse(values[1], out var yaxisValue);
            if (!yParseResult) throw new Exception($"invalid input for y axis: {input}");

            var direction = Directions.GetByKey(values[2].FirstOrDefault());

            Xaxis = xaxisValue;
            Yaxis = yaxisValue;
            Direction = direction;
        }

        public int Xaxis { get; set; }
        public int Yaxis { get; set; }
        public Direction Direction { get; set; }
    }
}