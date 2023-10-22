using Empire.Data;
using Empire.Models;

using Microsoft.EntityFrameworkCore;

using System;

namespace Empire.Service
{
    public class AnalystService
    {
        #region Property
        private readonly ApplicationDbContext _appDBContext;
        #endregion

        #region Constructor
        public AnalystService(ApplicationDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Analysts
        public async Task<List<Analyst>> GetAllAnalystsAsync()
        {
            return await _appDBContext.Analyst.ToListAsync();
        }
        #endregion

        #region Insert Analyst
        public async Task<bool> InsertAnalystAsync(Analyst analyst)
        {
            await _appDBContext.Analyst.AddAsync(analyst);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Analyst by Id
        public async Task<Analyst> GetAnalystAsync(int Id)
        {
            Analyst analyst = await _appDBContext.Analyst.FirstOrDefaultAsync(c => c.BAID.Equals(Id));
            return analyst;
        }
        #endregion

        #region Update Analyst
        public async Task<bool> UpdateAnalystAsync(Analyst analyst)
        {
            _appDBContext.Analyst.Update(analyst);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteEmployee
        public async Task<bool> DeleteAnalystAsync(Analyst analyst)
        {
            _appDBContext.Remove(analyst);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

    }
}
