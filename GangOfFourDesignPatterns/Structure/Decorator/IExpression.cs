namespace GangOfFourDesignPatterns.Structure.Decorator
{
    /// <summary>
    /// This is component in decorator pattern. Let assumpt that we need an expression to evaluate some algorithm
    /// Inside some algorithms, it may contains many algorithms, such as: firstExpression, lastExpression and allExpression
    /// There is also some single algorithm like: constExpression, ParamExpression,...
    /// Then we need to add algorithms to composite algorithm dynamically. In this case, Decorator Patterns is a good chooice
    /// </summary>
    public interface IExpression
    {
        void ExecuteAlgorithm();
        bool Evaluate();
    }
}
