namespace ModulusCheckerCore.Models
{
    public class BankAccount
    {
        public string SortCode { get; set; }

        public string AccountNumber { get; set; }

        public BankAccount(string sortCode, string accountNumber)
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