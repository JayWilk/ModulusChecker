namespace ModulusCheckerCore.Models
{
    public class Account
    {
        public double SortCode { get; set; }

        public double AccountNumber { get; set; }

        public Account(double sortCode, double accountNumber)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
        }
    }
}