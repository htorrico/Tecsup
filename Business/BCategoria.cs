using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BCategoria
    {
        private DCategoria dCategoria = null;
        public List<Categoria> GetCategoriasTop5(string NombreCategoria)
        {
            
            List<Categoria> categorias = null;

            try
            {
                dCategoria = new DCategoria();
                categorias = dCategoria.GetCategorias(NombreCategoria).Take(5).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return categorias;
        }
        public List<Categoria> GetCategoriasconSlash()
        {

            List<Categoria> categorias = null;

            try
            {
                dCategoria = new DCategoria();
                categorias = dCategoria.GetCategorias("/");
            }
            catch (Exception)
            {

                throw;
            }

            return categorias;
        }        
    }
}
