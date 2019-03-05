using System;
using System.Collections.Generic;

namespace GangOfFourDesignPatterns.Structure.Decorator
{
    /// <summary>
    /// Check first expression which is OK - a concrete decorator
    /// </summary>
    public class FirstExpression : ListExpression
    {
        public FirstExpression(List<IExpression> expressionImplementations) : base(expressionImplementations)
        {
        }

        public override void ExecuteAlgorithm()
        {
            throw new NotImplementedException();
        }

        public override bool Evaluate()
        {
            foreach (var expression in ExpressionImplementations)
            {
                if (expression.Evaluate())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
