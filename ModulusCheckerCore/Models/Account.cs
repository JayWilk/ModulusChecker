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
        /// Return a string in the format of {SortCode}{AccountNumber} 
        /// </summary>
        public override string ToString() =>
            $"{SortCode}{AccountNumber}";
    }
}