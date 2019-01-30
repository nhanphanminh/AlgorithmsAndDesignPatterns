namespace GangOfFourDesignPatterns.Structure.Bridge
{
    /// <summary>
    /// Bridge patter is used to seperate abstraction from its implementation so that  the two can have vary independently
    /// In this example, Shape is interface of abstraction with is seperated with Color Brushes and Shapes.
    /// Both Cirle and Rectangle Shapes can draw by Red or Green Color. Therefore, using Bridge pattern in this case can seperate
    ///     implementation of drawing shapes and collect brush color.
    /// </summary>
    public abstract class Shape
    {
        public abstract void ApplyColor(IBrushColor color);
        public abstract void DrawShape();
        protected IBrushColor Color;
    }
}
