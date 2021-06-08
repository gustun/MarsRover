namespace MarsRover.Core
{
    public class Plateau
    {
        public Plateau(int maxXAxis, int maxYAxis)
        {
            MaxXAxis = maxXAxis;
            MaxXAxis = maxYAxis;
        }
        public int MaxXAxis { get; internal set; }
        public int MaxYAxis { get; internal set; }
        public int MinXAxis => 0;
        public int MinYAxis => 0;
    }
}