using Prueba.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Core.Interfaces
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetxId(int id);
    }
}
