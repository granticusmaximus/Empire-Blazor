using Empire.Data;
using Empire.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Empire.Service
{
    public class EmployeeService
    {
        #region Property
        private readonly ApplicationDbContext _appDBContext;
        #endregion

        #region Constructor
        public EmployeeService(ApplicationDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Employees
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _appDBContext.Employee.ToListAsync();
        }
        #endregion

        #region Insert Employee
        public async Task<bool> InsertEmployeeAsync(Employee employee)
        {
            await _appDBContext.Employee.AddAsync(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Employee by Id
        public async Task<Employee> GetEmployeeAsync(int Id)
        {
            Employee employee = await _appDBContext.Employee.FirstOrDefaultAsync(c => c.EmpID.Equals(Id));
            return employee;
        }
        #endregion

        #region Update Employee
        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _appDBContext.Employee.Update(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteEmployee
        public async Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            _appDBContext.Remove(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
