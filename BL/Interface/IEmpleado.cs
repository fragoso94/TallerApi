using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerApiBasica.Models;

namespace TallerApiBasica.BL.Interface
{
    public interface IEmpleado
    {
        Task<List<Empleados>> ObtenerEmpleados();
        Task<Empleados> ObtenerEmpleados(string Id);
    }
}
