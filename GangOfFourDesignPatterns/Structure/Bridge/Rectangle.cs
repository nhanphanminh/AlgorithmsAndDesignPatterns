using System;

namespace GangOfFourDesignPatterns.Structure.Bridge
{
    public class Rectangle : Shape
    {
        public override void ApplyColor(IBrushColor color)
        {
            Color = color;
        }

        public override void DrawShape()
        {
            Console.WriteLine("Drawing Rectangle with: ");
            Color.ApplyColor();
        }
    }
}
