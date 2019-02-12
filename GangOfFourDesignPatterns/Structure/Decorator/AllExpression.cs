using System.Collections.Generic;

namespace GangOfFourDesignPatterns.Structure.Decorator
{
    /// <summary>
    /// Evalution of this expression is true if all its children are true. This is a concrete class in Decorator Pattern
    /// </summary>
    public class AllExpression : ListExpression
    {
        public AllExpression(List<IExpression> expressionImplementations) : base(expressionImplementations)
        {
        }

        public override void ExecuteAlgorithm()
        {
            throw new System.NotImplementedException();
        }

        public override bool Evaluate()
        {
            foreach (var expression in ExpressionImplementations)
            {
                if (!expression.Evaluate())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
