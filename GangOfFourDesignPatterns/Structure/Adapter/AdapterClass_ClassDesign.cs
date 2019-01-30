namespace GangOfFourDesignPatterns.Structure.Adapter.Object
{
    /// <summary>
    /// This adapter pattern is used to wrap a specified class( AdapteeClass in this case) to a target type( ITarget in this case).
    /// This is class level design.
    /// Pos:
    ///     + easier to maintain and extend
    /// Cons:
    ///     + More complex implementation than object
    /// </summary>
    class AdapterClass_ClassDesign : AdapteeClass, ITarget
    {
    }
}
