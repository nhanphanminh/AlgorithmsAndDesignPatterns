using System;

namespace GangOfFourDesignPatterns.Structure.Facade
{
    /// <summary>
    /// A common example in GoF Design Parttern which Mortgage is a Facade class
    /// Facade help us to unique sub-systems to a simpler system. It also reduce dependenciese and
    /// make our code more flexible if there are potential many clients will use sub-systems in similar ways
    /// </summary>
    public class Mortgage
    {
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
                cust.Name, amount);

            bool eligible = true;

            // Check creditworthyness of applicant

            if (!_bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(cust))
            {
                eligible = false;
            }

            return eligible;
        }

        public class Customer

        {
            private string _name;

            // Constructor

            public Customer(string name)
            {
                this._name = name;
            }

            // Gets the name

            public string Name
            {
                get { return _name; }
            }
        }
    }
}
