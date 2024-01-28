using Empire.Models;

namespace Empire.Service
{
    public interface ServiceInterface
    {
        Task<(bool flag, string message)> AddOrUpdateExpensesAsync(Expenses expenses);
        Task<List<Expenses>> GetAllExpensesAsync();
        Task<bool> DeleteExpensesAsync(int id);

        //Fund
        Task<int> AddFundAsync(Fund fund);
        Task<decimal> GetAvailableFund();

        // Note
        Task<(bool flag, string message)> AddNoteAsync(ExpenseNote note);
        Task<(bool flag, string message)> DeleteNoteAsync(int id);
        Task<List<ExpenseNote>> GetNoteAsync();
    }
}