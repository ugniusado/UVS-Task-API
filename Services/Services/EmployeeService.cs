using Contracts.DTOs;
using Contracts.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
                EmployeeSalary = e.EmployeeSalary
            });
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return employee == null ? null : new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeeSalary = employee.EmployeeSalary
            };
        }

        public async Task CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                EmployeeId = employeeDto.EmployeeId,
                EmployeeName = employeeDto.EmployeeName,
                EmployeeSalary = employeeDto.EmployeeSalary
            };
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                EmployeeId = employeeDto.EmployeeId,
                EmployeeName = employeeDto.EmployeeName,
                EmployeeSalary = employeeDto.EmployeeSalary
            };
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
