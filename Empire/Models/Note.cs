namespace Empire.Models
{
    public class ExpenseNote
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? DateAdded { get; set; }
    }
}