using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Data
{
   public class DCategoria
    {

     public   List<Categoria> GetCategorias(string nombreCategoria)
        {
            //Declarar
            List<Categoria> categorias = null;
            string commandText = string.Empty;
            SqlParameter[] parameters = null;

            try
            {
                //Instanciar
                commandText = "USP_ListarCategorias";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@NombreCategoria", System.Data.SqlDbType.VarChar);
                parameters[0].Value = nombreCategoria;
                categorias = new List<Categoria>();

                //Porque se utiliza automaticamente se borra de la memoria.
                using (SqlDataReader reader = 
                    SqlHelper.ExecuteReader(SqlHelper.Connection, commandText, 
                    System.Data.CommandType.StoredProcedure, parameters))
                    //SQL Helper te asegura que se van a cerrar siempre las conexiones
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            IdCategoria = reader["idcategoria"] != null ? Convert.ToInt32(reader["idcategoria"]) : 0,
                            NombreCategoria = reader["nombrecategoria"] != null ? Convert.ToString(reader["nombrecategoria"]) : "",
                            Descripcion = reader["descripcion"] != null ? Convert.ToString(reader["descripcion"]) : "",
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return categorias;
        }
    }
}
