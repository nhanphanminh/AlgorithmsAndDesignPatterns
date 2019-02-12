using System.Collections.Generic;

namespace GangOfFourDesignPatterns.Structure.Decorator
{
    /// <summary>
    /// Expression which contain many expressions. This is Decorator class in Decorator Patterns
    /// </summary>
    public abstract class ListExpression : IExpression
    {
        protected List<IExpression> ExpressionImplementations;

        protected ListExpression(List<IExpression> expressionImplementations)
        {
            ExpressionImplementations = expressionImplementations;
        }

        public abstract void ExecuteAlgorithm();

        public abstract bool Evaluate();
    }
}
