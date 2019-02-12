using System;

namespace GangOfFourDesignPatterns.Structure.Facade
{
    /// <summary>

    /// The 'Subsystem ClassC' class

    /// </summary>

    class Loan

    {
        public bool HasNoBadLoans(Mortgage.Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }
}
