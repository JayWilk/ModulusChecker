namespace ModulusCheckerCore.Models
{
    public class BankAccount
    {
        public double SortCode { get; set; }

        public double AccountNumber { get; set; }

        public BankAccount(double sortCode, double accountNumber)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
        }

        /// <summary>
        /// Returns a formatted account number a string in the format {SortCode}{AccountNumber}
        /// </summary>
        /// <value>
        /// The formatted number.
        /// </value>
        public string FormattedNumber =>
            (SortCode + AccountNumber).ToString();
    }
}