using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Core.Entidades;
using Prueba.Core.Interfaces;

namespace Prueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public async Task<Result<List<Employee>>> GetAll()
        {
            
            try
            {
                List<Employee> employess = await _employee.GetEmployees();
                return new Result<List<Employee>>()
                {
                    status = "Success",
                    data = employess,
                    message = "Consulta exitosa"

                };
            }
            catch (Exception ex)
            {
                List<Employee> listaVacia = new List<Employee>();
                return new Result<List<Employee>>()
                {
                    status = "Error",
                    data = listaVacia,
                    message = ex.Message
                };
            }
            
        }

        [HttpGet("{id}")]
        public async Task<Result<Employee>> GetxId(int id)
        {
            try
            {
                var employee = await _employee.GetxId(id);
                return new Result<Employee>
                {
                    status = "Success",
                    data = employee,
                    message = "Consulta exitosa"
                };
            }
            catch (Exception ex)
            {

                Employee listaVacia = new Employee();
                return new Result<Employee>
                {
                    status = "Error",
                    data = listaVacia,
                    message = ex.Message
                };
            }
            
        }
        
    }



}
