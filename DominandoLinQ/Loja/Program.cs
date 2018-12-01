﻿using LojaDominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Program
    {

        static void Main(string[] args)
        {
            var Produto = new Produto(); /*instanciando uma classe*/
            var Produtos = Produto.Listar(); /* Usando um método, e botando o resultado em uma variavel*/

            #region Turotial-3 


            /*Pode filtrar direito com Where*/
            var Produto2 = new Produto(); /*instanciando uma classe*/
            var Produtos2 = Produto2.Listar().Where(p => p.Quantidade > 4); /*R: Banana e Melão!*/


            /*Retorna somente os nomes de cada item!*/
            foreach (Produto item in Produtos)
            {
                Console.WriteLine(item.Nome);
            }


            /*Forech em uma unica linha!*/
            Console.WriteLine("\n Usando uma linha: ");

            new Produto().Listar().ForEach(item => Console.WriteLine(item.Nome)); /*R: todos os filtros*/



            /*Forech exibindo mais valores, filtrados e convertendo para lista!*/
            Console.WriteLine("\n Usando uma linha com filtro: ");

            new Produto().Listar().Where(item => item.Valor > 5).ToList().ForEach(item =>
            {
                Console.WriteLine(item.Nome);
                Console.WriteLine(item.Valor); /*R: Morango25, Pera12*/
            });


            #endregion


            #region Tutorial-4

            var ProdutosTutorial4 = new Produto().Listar(); /*Instnacia*/

            /* StratsWith: indica um valor que inicia com o caracter informado no parametro */
            /* EndsWith: indica um valor que finaliza com o caracter informado no parametro */
            Console.WriteLine("\n Json: \n");

            ProdutosTutorial4 = ProdutosTutorial4.Where(p => p.Nome.StartsWith("A") || p.Nome.EndsWith("o")).ToList();

            ProdutosTutorial4.ForEach(item =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(item)); /*R: Morango, Abacaxi e Melão*/
                Console.WriteLine(" ");

            });

            /* Objeto Anônimo pelo .Select */
            Console.WriteLine("\n Criando Objeto Anônimo: \n");

            var ProdutoT4 = new Produto().Listar();
            var ProdutosString = ProdutoT4
                .Where(p => p.Nome.StartsWith("A") || p.Nome.EndsWith("o"))
                .Select(p => new
                    {
                        Nome = p.Nome,
                        Valor = p.Valor
                    }
                )
                .ToList();

            ProdutosString.ForEach(p => Console.WriteLine(p)); /*R: Morango, Abacaxi e Melão*/


            /* Objeto Tipado pelo .Select() */
            /* Exemplo do .SubString(0,4): exibe somente os caracter do index 1° até o 4°*/
            /* Exemplo do .Insert(4, "texto"): inseri o texto depois do 4°index*/
            /* Exemplo do .Remove(IndexInicial, IndexFinal): remove de acordo com o index informado*/
            /* Exemplo do .Replace("a", "Z") : subistitui tudo que tem "a" por "Z" */
            Console.WriteLine("\n Criando Objeto Tipado, exemplo do .SubString() e .Insert() : \n");

            var ProdutoT42 = new Produto().Listar();
            var ProdutoStringType = ProdutoT42
                .Where(p => p.Nome.StartsWith("A") || p.Nome.EndsWith("o"))
                .Select(p => new ItensSelecionados()
                    {
                        Nome = p.Nome,
                        Valor = p.Valor,
                        Dia = p.DataDeVencimento.Day
                    }
                )
                .ToList();

            ProdutoStringType.ForEach(p => Console.WriteLine("Nome: "+ p.Nome.Substring(0,4).Insert(4," -Abreviado") +"/ Valor: "+ p.Valor +"/ Dia: "+ p.Dia)); /*R: Morango, Abacaxi e Melão*/

            Console.WriteLine("\n .Remove() e .Replace(): \n");
            ProdutoStringType.ForEach(p => Console.WriteLine(p.Nome.Remove(0, 1).Replace("a", "#"), p.Valor));

            #endregion


            Console.ReadKey();

        }
    }

    public class ItensSelecionados
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public int Dia { get; set; }
    }
}
