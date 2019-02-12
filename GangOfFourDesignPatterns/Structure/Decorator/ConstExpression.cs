using System;

namespace GangOfFourDesignPatterns.Structure.Decorator
{
    /// <summary>
    /// single algorithm - a concrete component in decorator patterns
    /// </summary>
    public class ConstExpression : IExpression
    {
        public void ExecuteAlgorithm()
        {
            throw new NotImplementedException();
        }

        public bool Evaluate()
        {
            return true;
        }
    }
}
