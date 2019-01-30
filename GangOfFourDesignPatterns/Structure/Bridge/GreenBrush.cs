using System;

namespace GangOfFourDesignPatterns.Structure.Bridge
{
    public class GreenBrush : IBrushColor
    {
        public void ApplyColor()
        {
            Console.WriteLine("Green Color");
        }
    }
}
