using System;
using System.Collections.Generic;

namespace GangOfFourDesignPatterns.Structure.Decorator
{
    /// <summary>
    /// Check from last expression, return true if any OK - A concrete decorator in Decorator Pattern
    /// </summary>
    public class LastExpression : ListExpression
    {
        public LastExpression(List<IExpression> expressionImplementations) : base(expressionImplementations)
        {
        }

        public override void ExecuteAlgorithm()
        {
            throw new NotImplementedException();
        }

        public override bool Evaluate()
        {
            for (int i = ExpressionImplementations.Count - 1; i >= 0; i--)
            {
                if (ExpressionImplementations[i].Evaluate())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
