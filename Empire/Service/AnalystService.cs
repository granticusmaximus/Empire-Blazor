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

        public void UpdateAnalystDetails(Analyst analyst)
        {
            try
            {
                _dbContext.Entry(analyst).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Analyst GetAnalystData(int id)
        {
            try
            {
                Analyst? analyst = _dbContext.Analyst.Find(id);
                if (analyst != null)
                {
                    return analyst;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                Analyst? analyst = _dbContext.Analyst.Find(id);
                if (analyst != null)
                {
                    _dbContext.Analyst.Remove(analyst);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
