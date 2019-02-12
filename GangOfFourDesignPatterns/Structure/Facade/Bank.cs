using System;

namespace GangOfFourDesignPatterns.Structure.Facade
{
    /// <summary>

    /// The 'Subsystem ClassA' class

    /// </summary>

    class Bank

    {
        public bool HasSufficientSavings(Mortgage.Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }
}
