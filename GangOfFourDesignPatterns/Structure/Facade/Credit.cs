using System;

namespace GangOfFourDesignPatterns.Structure.Facade
{
    /// <summary>

    /// The 'Subsystem ClassB' class

    /// </summary>

    class Credit

    {
        public bool HasGoodCredit(Mortgage.Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }
}
