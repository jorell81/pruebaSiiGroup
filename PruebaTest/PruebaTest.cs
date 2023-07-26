using Prueba.Api.Controllers;
using Prueba.Core.Entidades;
using Prueba.Core.Interfaces;
using Prueba.Infraestructura.Repositorios;

namespace PruebaTest
{
    [TestClass]
    public class PruebaTest
    {
        private readonly EmployeeController _employeeController;
        private readonly IEmployee _employee;

        public PruebaTest()
        {
            _employee = new EmployeeRepositorio();
            _employeeController = new EmployeeController(_employee);
        }

        [TestMethod]
        public void Get_EmployeexId()
        {
            int a = 0;
            var expected = new Result<Employee>
            {
                data = {},
                status = "Success",
                message = "Consulta exitosa"
            };
            var actual =  _employeeController.GetxId(a);
            Assert.AreNotEqual(expected, actual);
        }
    
    }
}