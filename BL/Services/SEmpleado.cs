using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerApiBasica.BL.Interface;
using TallerApiBasica.Models;

namespace TallerApiBasica.BL.Services
{
    public class SEmpleado : IEmpleado
    {
        public async Task<List<Empleados>> ObtenerEmpleados()
        {
            var Lista = new List<Empleados>();
            try
            {
                using (var conexion = new SqlConnection(Helpers.ContextConfigurations.ConexionString))
                {
                    var command = new SqlCommand();
                    command.Connection = conexion;
                    command.CommandText = "dbo.ObtenerEmpleados";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", "ObtenerEmpleados");
                    conexion.Open();

                    var lectura = await command.ExecuteReaderAsync();
                    if (lectura.HasRows)
                    {
                        while (lectura.Read())
                        {
                            Lista.Add(new Empleados
                            {
                                Id = lectura.GetGuid(0),
                                Nombre = lectura.GetString(1),
                                Rfc = lectura.GetString(2),
                                Correo = lectura.GetString(3)
                            });
                        }
                    }
                    conexion.Close();
                    return Lista;
                }
            }
            catch(Exception e)
            {
                return Lista;
            }

        }

        public async Task<Empleados> ObtenerEmpleados(string Id)
        {
            var empleado = new Empleados();
            try
            {
                using (var conexion = new SqlConnection(Helpers.ContextConfigurations.ConexionString))
                {
                    var command = new SqlCommand();
                    command.Connection = conexion;
                    command.CommandText = "dbo.ObtenerEmpleados"; // nombre del procedimiento
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", "ObtenerEmpleado"); //nombre del método
                    command.Parameters.AddWithValue("@IdEmpleado", Id);
                    conexion.Open();

                    var lectura = await command.ExecuteReaderAsync();
                    if (lectura.HasRows)
                    {
                        while (lectura.Read())
                        {
                            empleado.Id = lectura.GetGuid(0);
                            empleado.Nombre = lectura.GetString(1);
                            empleado.Rfc = lectura.GetString(2);
                            empleado.Correo = lectura.GetString(3);
                        }
                    }
                    conexion.Close();
                    return empleado;
                }
            }
            catch(Exception e)
            {
                return empleado;
            }
        }
    }
}
