using Empire.Data;
using Empire.Models;

using Microsoft.EntityFrameworkCore;

using System;

namespace Empire.Service
{
    public class AnalystService
    {
        private readonly ApplicationDbContext _dbContext;

        public AnalystService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Analyst> GetAnalystAsList()
        {
            try
            {
                return _dbContext.Analyst.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddAnalyst(Analyst analyst)
        {
            try
            {
                _dbContext.Analyst.Add(analyst);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteAnalyst(int id)
        {
            var analyst = _dbContext.Analyst.SingleOrDefault(x => x.BAID == id);
            _dbContext.Remove(analyst);
            _dbContext.SaveChanges();
        }
    }
}
