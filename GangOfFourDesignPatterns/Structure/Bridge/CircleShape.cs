using System;

namespace GangOfFourDesignPatterns.Structure.Bridge
{
    public class CircleShape : Shape
    {
        public override void ApplyColor(IBrushColor color)
        {
            Color = color;
        }

        public override void DrawShape()
        {
            Console.WriteLine("Drawing Circle with: ");
            Color.ApplyColor();
        }
    }
}
