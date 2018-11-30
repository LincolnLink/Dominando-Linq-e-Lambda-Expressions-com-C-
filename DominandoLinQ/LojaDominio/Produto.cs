using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDominio
{
    public class Produto
    {
        /*private ICollection<Produto> _produto3;*/
        /*private IEnumerable<Produto> _produto2;*/
        private List<Produto> _produtos;

        /*crt+R+G : limpa os using que não estão sendo usados*/

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataDeVencimento { get; set; }


        public Produto()
        {
            _produtos = new List<Produto>();
        }

        public List<Produto> Listar()
        {
            _produtos.Add(new Produto() { Id = Guid.NewGuid(), Nome = "Banana", Quantidade = 5, Valor = 2, DataDeVencimento = DateTime.Now.AddDays(5) });
            _produtos.Add(new Produto() { Id = Guid.NewGuid(), Nome = "Morango", Quantidade = 4, Valor = 25, DataDeVencimento = DateTime.Now.AddDays(2) });
            _produtos.Add(new Produto() { Id = Guid.NewGuid(), Nome = "Pera", Quantidade = 2, Valor = 12, DataDeVencimento = DateTime.Now.AddDays(3) });
            _produtos.Add(new Produto() { Id = Guid.NewGuid(), Nome = "Abacaxi", Quantidade = 1, Valor = 4, DataDeVencimento = DateTime.Now.AddDays(4) });
            _produtos.Add(new Produto() { Id = Guid.NewGuid(), Nome = "Melão", Quantidade = 35, Valor = 5, DataDeVencimento = DateTime.Now.AddDays(10) });

            return _produtos;
        }

    }
}
