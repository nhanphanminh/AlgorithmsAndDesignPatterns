using System;

namespace GangOfFourDesignPatterns.Structure.Bridge
{
    public class RedBrush : IBrushColor
    {
        public void ApplyColor()
        {
            Console.WriteLine("Red color");
        }
    }
}
