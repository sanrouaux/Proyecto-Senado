using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class DAO : IArchivo<Votacion>
    {
        public Votacion Leer(string rutaArchivo)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(string rutaArchivo, Votacion objeto)
        {
            bool ok = false;
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion_bd);
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Votaciones (nombreLey, afirmativos, negativos, abstenciones, nombreAlumno) VALUES ('" + objeto.NombreLey + "'," +
                objeto.ContadorAfirmativo.ToString() +","+ objeto.ContadorNegativo.ToString() +","+ objeto.ContadorAbstencion.ToString() +",'Santiago Rouaux')";
            try
            {
                conexion.Open();
                if (comando.ExecuteNonQuery() > 0)
                {
                    ok = true;
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return ok;
        }
    }
}
