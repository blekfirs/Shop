namespace information_system.Data_Types
{
    public class AccountingRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime RecordDate { get; set; }
        public bool IsIncome { get; set; }

        public AccountingRecord(int id, string name, decimal amount, DateTime recordDate, bool isIncome)
        {
            Id = id;
            Name = name;
            Amount = amount;
            RecordDate = recordDate;
            IsIncome = isIncome;
        }
    }
}
