﻿using Empire.Data;
using Empire.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empire.Service
{
    public class EmployeeService
    {
        #region Property
        private readonly ApplicationDbContext _appDBContext;
        private readonly UserManager<Employee> _userManager;
        #endregion

        #region Constructor
        public EmployeeService(ApplicationDbContext appDBContext, UserManager<Employee> userManager)
        {
            _appDBContext = appDBContext;
            _userManager = userManager;
        }
        #endregion

        #region Get List of Employees
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _appDBContext.Employee.ToListAsync();
        }
        #endregion

        #region Insert Employee
        public async Task<bool> InsertEmployeeAsync(Employee employee, int selectedRoleId)
        {
            var role = await _appDBContext.Roles.FindAsync(selectedRoleId);
            if (role == null)
            {
                throw new ArgumentException("Invalid role ID provided.");
            }

            employee.RoleId = selectedRoleId;

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
        public async Task<bool> UpdateEmployeeAsync(Employee employee, int selectedRoleId)
        {
            var role = await _appDBContext.Roles.FindAsync(selectedRoleId);
            if (role == null)
            {
                throw new ArgumentException("Invalid role ID provided.");
            }

            employee.RoleId = selectedRoleId;

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
