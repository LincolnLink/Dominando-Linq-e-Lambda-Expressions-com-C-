using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introducao
{
    class Program
    {
        static void Main(string[] args)
        {   
            /* Array */
            int[] numeros = { 5 ,10 ,3 ,4 ,1 ,8 ,7 ,9 ,6 ,2 };
            string[] cores = { "Preto", "Branco", "Verde", "Vermelho", "Azul" };


            #region Método Where e OrderBy

            /* Exemplo de filtro sem o LinQ */
            foreach (var numero in numeros)
            {
                if (numero > 4)
                {
                    Console.WriteLine(numero);
                }
            }
            

            /* Exemplo de filtro com o LinQ */
            var numerosFiltrados = numeros.Where(n => n <= 4);
            /*IEnumerable<int> numerosFiltrados = numeros.Where(n => n > 4);*/


            /* Comparando select do SQL com o do LinQ */
            //"select * from tabela"
            var resultado = from num in numeros
                            where num > 4
                            orderby num
                            select num;


            /* Criando uma interação LinQ + Lambda*/
            var resultado2 = numeros.Where(n => n > 4)
                .OrderBy(x => x);

            #endregion

            #region Método Contais

            /* Método Contains */
            var filtroDeCores1 = cores.Where(x => x.Contains("e"));

            /* pode usar && e || */
            var filtroDeCores2 = cores.Where(x => x.Contains("e") || x.Contains("z"));

            #endregion








            Console.ReadKey();            

        }
    }
}
