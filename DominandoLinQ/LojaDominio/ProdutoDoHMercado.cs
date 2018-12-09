using System;
using System.Collections.Generic;
using System.Text;

namespace LojaDominio
{
    public class ProdutoDoHMercado
    {
        public string Nome { get; set; }

        public int Valor { get; set; }

        public string Categoria { get; set; }

        List<ProdutoDoHMercado> lista;

        public ProdutoDoHMercado()
        {
            lista = new List<ProdutoDoHMercado>();
        }

        public List<ProdutoDoHMercado> ListarFrutas()
        {
            lista.Add(new ProdutoDoHMercado() { Nome = "Pera", Valor = 4, Categoria = "Fruta"  });
            lista.Add(new ProdutoDoHMercado() { Nome = "Maça", Valor = 3, Categoria = "Fruta" });
            lista.Add(new ProdutoDoHMercado() { Nome = "Limão", Valor = 2, Categoria = "Fruta" });
            lista.Add(new ProdutoDoHMercado() { Nome = "Uva", Valor = 1, Categoria = "Fruta" });

            return lista;
        }

        public List<ProdutoDoHMercado> ListaEletronicos()
        {
            lista.Add(new ProdutoDoHMercado() { Nome = "Iphone X", Valor = 9000, Categoria = "Eletronico" });
            lista.Add(new ProdutoDoHMercado() { Nome = "Samsung", Valor = 3000, Categoria = "Eletronico" });
            lista.Add(new ProdutoDoHMercado() { Nome = "Nokia", Valor = 2000, Categoria = "Eletronico" });
            lista.Add(new ProdutoDoHMercado() { Nome = "Lenovo", Valor = 1000, Categoria = "Eletronico" });

            return lista;
        }

    }
}
