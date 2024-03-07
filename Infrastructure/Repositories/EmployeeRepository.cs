using Contracts.Interfaces;
using Core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EmployeeManagementConnectionString");
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<Employee>("SELECT * FROM employees");
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<Employee>("SELECT * FROM employees WHERE employeeid = @Id", new { Id = id });
        }

        public async Task AddAsync(Employee employee)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = "INSERT INTO employees (employeeid, employeename, employeesalary) VALUES (@EmployeeId, @EmployeeName, @EmployeeSalary)";
            await connection.ExecuteAsync(sql, employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var sql = "UPDATE employees SET employeename = @EmployeeName, employeesalary = @EmployeeSalary WHERE employeeid = @EmployeeId";
            await connection.ExecuteAsync(sql, employee);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM employees WHERE employeeid = @Id", new { Id = id });
        }
    }
}
