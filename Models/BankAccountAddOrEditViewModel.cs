namespace BankTransactions.Models
{
    public class BankAccountAddOrEditViewModel
    {
        public BankAccount BankAccount { get; set; }
        public Bank Bank { get; set; }
        public Customer Customer { get; set; }
        public List<Bank> BankList { get; set; }
        public List<Customer> CustomerList { get; set; }
    }
}
