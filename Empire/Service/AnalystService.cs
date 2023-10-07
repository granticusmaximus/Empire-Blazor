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

        public Analyst GetListOfAnalyst(int id)
        {
            var analyst = _dbContext
               .Analyst
               .ToListAsync();
                return new Analyst();
        }

        public void Delete(int id)
        {
            var analyst = _dbContext.Analyst.SingleOrDefault(x => x.BAID == id);
            _dbContext.Remove(analyst);
            _dbContext.SaveChanges();
        }
    }
}
