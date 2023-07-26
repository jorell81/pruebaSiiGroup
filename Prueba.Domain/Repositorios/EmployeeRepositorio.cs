using Prueba.Core.Entidades;
using Prueba.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Prueba.Infraestructura.Repositorios
{
    public class EmployeeRepositorio : IEmployee
    {

        //private readonly IConfiguration _configuration;
        //private object configurtion;

        public EmployeeRepositorio() { }
        //public EmployeeRepositorio(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //public EmployeeRepositorio(IConfiguration configuration, object configurtion) : this(configuration)
        //{
        //    this.configurtion = configurtion;
        //}

        public async Task<List<Employee>> GetEmployees()
        {
            //string? apiUrl = _configuration.GetSection("services:urlGetEmployees").Value;
            string apiUrl = "http://dummy.restapiexample.com/api/v1/employees";
            List<Employee> ObjResultado = new List<Employee>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    Result<List<Employee>>? result = JsonConvert.DeserializeObject<Result<List<Employee>>>(responseData);
                    foreach (var item in result.data)
                    {
                        item.employee_anual_salary = item.employee_salary * 12;
                    }
                    ObjResultado = result.data;
                }
                else
                {
                    throw new Exception("Error en la solicitud. Código de estado: " + response.StatusCode);
                }
            }
            return ObjResultado;
        }

        public async Task<Employee> GetxId(int id)
        {
            //string apiUrl = _configuration.GetSection("services:urlGetxId").Value;
            string apiUrl = "http://dummy.restapiexample.com/api/v1/employee/";
            apiUrl += id;
            Employee employee = new Employee();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    Result<Employee>? result = JsonConvert.DeserializeObject<Result<Employee>>(responseData);
                    employee = result.data;
                    employee.employee_anual_salary = employee.employee_salary * 12;
                }
                else
                {
                    throw new Exception("Error en la solicitud. Código de estado: " + response.StatusCode);
                }
            }
            return employee;
        }
    }


}
