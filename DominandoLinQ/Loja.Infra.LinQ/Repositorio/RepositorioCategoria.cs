using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.LinQ.Repositorio
{
    public class RepositorioCategoria
    {
        public void AdicionarCategoria(int id, string nome)
        {
            /*Linq to SQL*/
            Categoria categoria = new Categoria();
            categoria.Id = id;
            categoria.Nome = nome;

            LojaLinqToSqlDataContext linq = new LojaLinqToSqlDataContext();
            linq.Categoria.InsertOnSubmit(categoria);

            linq.SubmitChanges();

        }

        public void AlterarCategoria(int id, string nome)
        {
            /*Linq to SQL*/
            LojaLinqToSqlDataContext linq = new LojaLinqToSqlDataContext();

            var categoria = linq.Categoria.FirstOrDefault(x => x.Id == id);
            
            categoria.Nome = nome;

            linq.SubmitChanges();

        }

        public void ExcluirCategoria(int id)
        {
            /*Linq to SQL*/
            LojaLinqToSqlDataContext linq = new LojaLinqToSqlDataContext();

            var categoria = linq.Categoria.FirstOrDefault(x => x.Id == id);
            
            if(categoria != null)
            linq.Categoria.DeleteOnSubmit(categoria);

            linq.SubmitChanges();

        }

        public List<Produto> ListarTudo()
        {
            /*Entity Framework*/
            LojaLinqToSqlDataContext RespositorioDefault = new LojaLinqToSqlDataContext();

            return RespositorioDefault.Produto.ToList();
        }
    }
}
