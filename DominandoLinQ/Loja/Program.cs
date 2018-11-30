using LojaDominio;
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





            Console.ReadKey();

        }
    }
}
