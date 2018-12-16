using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.EF.Repositorio
{
    public class RepositorioCategoria
    {
        /// <summary>
        /// Insert
        /// </summary>
        public void AdicionarCategoria(int id, string nome)
        {
            /*Entity Framework*/
            Categoria categoria = new Categoria();
            categoria.Id = id;
            categoria.Nome = nome;            

            lojaEFEntities ef = new lojaEFEntities();
            ef.Categoria.Add(categoria);

            ef.SaveChanges();

        }

        /// <summary>
        /// Update
        /// </summary>
        public void AlterarCategoria(int id, string nome)
        {
            /*Entity Framework*/
            lojaEFEntities RespositorioDefault = new lojaEFEntities();

            var categoria = RespositorioDefault.Categoria.FirstOrDefault(x => x.Id == id);
                
            categoria.Nome = nome;

            RespositorioDefault.SaveChanges();
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void ExcluirCategoria(int id)
        {
            /*Entity Framework*/
            lojaEFEntities RespositorioDefault = new lojaEFEntities();            

            var categoria = RespositorioDefault.Categoria.FirstOrDefault(x => x.Id == id);

            if(categoria != null)
            RespositorioDefault.Categoria.Remove(categoria);

            RespositorioDefault.SaveChanges();

        }

        /// <summary>
        ///  Retorna todos os produtos
        /// </summary>
        public List<Produto> ListarTudo()
        {
            /*Entity Framework*/
            lojaEFEntities RespositorioDefault = new lojaEFEntities();

            return RespositorioDefault.Produto.ToList();
        }
    }
}
