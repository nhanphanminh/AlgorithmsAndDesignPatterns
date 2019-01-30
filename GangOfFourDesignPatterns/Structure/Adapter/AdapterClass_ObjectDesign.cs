using GangOfFourDesignPatterns.Structure.Adapter.Object;

namespace GangOfFourDesignPatterns.Structure.Adapter
{
    /// <summary>
    /// This adapter pattern is used to wrap a specified class( AdapteeClass in this case) to a target type( ITarget in this case).
    /// This is object level design.
    /// Pos:
    ///     + Simpler than class level design
    /// Cons:
    ///     + Harder to extend than class level design
    /// </summary>
    class AdapterClassObjectDesign : ITarget
    {
        private AdapteeClass _adaptee;

        public AdapterClassObjectDesign(AdapteeClass adaptee)
        {
            _adaptee = adaptee;
        }
    }
}
