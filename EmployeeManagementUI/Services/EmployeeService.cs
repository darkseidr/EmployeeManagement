
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EmployeeManagement.Shared.Models;



    public class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        private void EnsureAuthorizationHeader(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<List<Employee>> GetEmployees(string token)
        {
            EnsureAuthorizationHeader(token);
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employees/getEmployeeList");
        }

        public async Task<Employee> GetEmployee(int id, string token)
        {
        EnsureAuthorizationHeader(token);
            return await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/getEmployeeDetails/{id}");
        }

        public async Task CreateEmployee(Employee employee, string token)
        {
        EnsureAuthorizationHeader(token);
            await _httpClient.PostAsJsonAsync("api/Employees/addEmployee", employee);
        }

        public async Task UpdateEmployee(Employee employee, string token)
        {
        EnsureAuthorizationHeader(token);
            await _httpClient.PostAsJsonAsync($"api/Employees/updateEmployeeDetails", employee);
        }

        public async Task DeleteEmployee(int id, string token)
        {
        EnsureAuthorizationHeader(token);
            await _httpClient.DeleteAsync($"api/Employees/deleteEmployeeDetails/{id}");
        }
    }

