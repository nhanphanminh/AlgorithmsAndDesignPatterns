using System;

namespace GangOfFourDesignPatterns.Structure.Decorator
{
    public class ParamExpression : IExpression
    {
        public void ExecuteAlgorithm()
        {
            throw new NotImplementedException();
        }

        public bool Evaluate()
        {
            try
            {
                ExecuteAlgorithm();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
