using Loja.Infra.EF.Repositorio;
using Loja.Infra.LinQ.Repositorio;
using LojaDominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            /*Comentarios: botar comentario: CTRL + K, Ctrl + C remover: CTRL + K, Ctrl + U*/
            /*NewTonSoft.Json instalado para exibir Json*/

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

            ProdutoStringType.ForEach(p => Console.WriteLine("Nome: " + p.Nome.Substring(0, 4).Insert(4, " -Abreviado") + "/ Valor: " + p.Valor + "/ Dia: " + p.Dia)); /*R: Morango, Abacaxi e Melão*/

            Console.WriteLine("\n .Remove() e .Replace(): \n");
            ProdutoStringType.ForEach(p => Console.WriteLine(p.Nome.Remove(0, 1).Replace("a", "#"), p.Valor));

            #endregion
            

            #region Tutorial-5

            var ProdutosT5 = new Produto().Listar();            

            /* FirstOrDefault(): Primeiro elemento da lista*/
            Console.WriteLine("\n Primeiro elemento da lista \n");            
            var primeiroE = ProdutosT5.FirstOrDefault(); /* Não usar o "First(), porque ele retorna uma exeção!"*/
            Console.WriteLine(JsonConvert.SerializeObject(primeiroE));


            /* LastOrDefault(): Ultimo elemento da lista*/
            Console.WriteLine("\n Ultimo elemento da lista \n");            
            var ultimoE = ProdutosT5.LastOrDefault();/* Não usar o "Last(), porque ele retorna uma exeção!"*/
            Console.WriteLine(JsonConvert.SerializeObject(ultimoE));


            /* Any(): Informa se acoleção/lista tem elementos, retorna true ou false*/
            if (ProdutosT5.Any())
            {
                Console.WriteLine("\n Existe objetos na lista: retornou TRUE! \n ");
            }

            /* Any(): Retorna true e false, baseando em uma condição com elementos da coleção/lista!  */
            if (ProdutosT5.Any(p => p.Quantidade > 5)) /* Any() pode ser usado dentro do Where*/
            {
                Console.WriteLine("\n Existe produtos com a quantidade maior que 5? : Retornou TRUE! \n");
            }
            

            /* .AddRange() : adiciona uma lista em outra lista!  */
            Console.WriteLine("\n Adicionando uma lista na outra lista! \n");
            var Produtos3T5 = new Produto().Listar();
            var Produtos2T5 = new List<Produto>();

            Produtos2T5.Add(new Produto() { Nome = "Iphone X", Quantidade = 5 , Valor = 7900});
            Produtos2T5.Add(new Produto() { Nome = "Galaxy", Quantidade = 10, Valor = 2500 });

            Produtos2T5.AddRange(Produtos3T5);

            Produtos2T5.ForEach(p => Console.WriteLine(p.Nome));


            /* Retorna os elementos de um array, que está em outro array, retorna os que são comum! */
            Console.WriteLine("\n Retorna os elementos de um array, que está em outro array, retorna os que são comum!  \n");
            int[] NumerosPares = {2, 4, 6, 8, 10 };
            int[] NumerosImpares = { 1, 3, 5, 7, 9 };
            int[] NumerosMisturados = { 1, 2, 3, 4 };

            var TemNumerosPares = NumerosMisturados.Intersect(NumerosPares); /* 2 e 4 foram retornados*/



            /* Retorna os elementos de um array, que NÃO está em outro array, retorna os que são diferentes! */
            Console.WriteLine("\n Retorna os elementos de um array, que NÃO está em outro array, retorna os que são diferentes! \n");

            var NaoTemImpares = NumerosMisturados.Except(NumerosImpares); /* 2 e 4 foram retornados*/


            /* Range */
            Console.WriteLine("\n  Informando uma sequencia \n");
            var sequencia = Enumerable.Range(10, 3);/*Resultado: 10, 11, 12*/
            foreach (int item in sequencia)
            {
                Console.WriteLine(item.ToString());
            }

            /* Repeate*/
            Console.WriteLine("\n Repete a palavra 10 vezes \n");
            var repetir = Enumerable.Repeat("Lincoln", 10);
            foreach (string item in repetir)
            {
                Console.WriteLine("Nome: " +item.ToString());
            }


            #endregion


            #region Tutorial-6

            var ProdutosT6 = new Produto().Listar();


            /* Valor do produto mais caro */
            var valorPC = ProdutosT6.Max(p => p.Valor);
            Console.WriteLine("\n Valor do Produto mais caro: \n" + valorPC);


            /* Valor do produto mais barato */
            var valorPCm = ProdutosT6.Min(p => p.Valor);
            Console.WriteLine("\n Valor do Produto mais barato: \n" + valorPCm);


            /* Soma dos valores */
            var soma = ProdutosT6.Sum(p => p.Valor);
            Console.WriteLine("\n Soma dos valores: \n" + soma);


            /*  Média dos valores*/
            var media = ProdutosT6.Average(p => p.Valor);
            Console.WriteLine(" \n Média do valor: \n" + media.ToString());


            /* Agrupamento e Agregação */
            Console.WriteLine("\n _Agrupamento_ \n ");
            var ListaFruta = new ProdutoDoHMercado().ListarFrutas();
            var ListaEletronico = new ProdutoDoHMercado().ListaEletronicos();
            
            ListaFruta.AddRange(ListaEletronico);
            Console.WriteLine("\n Valores junstos: \n");
            ListaFruta.ForEach(p => Console.WriteLine(JsonConvert.SerializeObject(p)));

            /* Group By Into*/
            Console.WriteLine("\n Valores Agrupados: \n");
            var ListaTotal = (from p in ListaFruta
                              group p by p.Categoria into grupo
                              select new ProdutosAgrupados
                              {
                                  NomeDaCategoria = grupo.Key,
                                  ValorMinimo = grupo.Min(p => p.Valor),
                                  ValorMaximo = grupo.Max(p => p.Valor)

                              }
                              ).GroupBy(p => p.NomeDaCategoria);

            ListaTotal.ToList().ForEach(p => Console.WriteLine(JsonConvert.SerializeObject(p)));

            /* Agrupamento exibindo os valores */
            Console.WriteLine("\n Agrupamento exibindo os valores: \n");

            //var ListaTotal2 = from p in ListaFruta
            //                  group p by p.Categoria;
            /* Com LAMBDA */
            var ListaTotal2 = ListaFruta.GroupBy(p => p.Categoria);

            foreach (var ageGroup in ListaTotal2)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key); //Each group has a key 

                foreach (ProdutoDoHMercado s in ageGroup) // Each group has inner collection
                    Console.WriteLine("Student Name: {0}", s.Nome);
            }


            #endregion


            #region Tutorial-7

            Console.WriteLine("\n Rodando o Turorial 7 \n");

            /*Entity Fremework*/
            /*Estilo: EF Designer from database*/

            /* Insert *//*            
            new Infra.EF.Repositorio.RepositorioCategoria().AdicionarCategoria(1 ,"Frutas");
            new Infra.EF.Repositorio.RepositorioCategoria().AdicionarCategoria(2 ,"Eletronicos");*/

            /* Alterando *//*
            new Infra.EF.Repositorio.RepositorioCategoria().AlterarCategoria(1, "Frutas Doces");*/

            /* Remove *//*
           new Infra.EF.Repositorio.RepositorioCategoria().ExcluirCategoria(1);*/

            /*Retorna todos os produtos*//*
            var lista = new Infra.EF.Repositorio.RepositorioCategoria().ListarTudo();
            Console.WriteLine("--------------- EF: ");
            lista.ForEach(x => Console.WriteLine(x.Nome));*/

            /*=================== LinQ =======================*//*
            
            /* Insert */ /*
            new Infra.LinQ.Repositorio.RepositorioCategoria().AdicionarCategoria(3, "Roupas");
            new Infra.LinQ.Repositorio.RepositorioCategoria().AdicionarCategoria(4, "Games");*/

            /* Alterando *//*
            new Infra.LinQ.Repositorio.RepositorioCategoria().AlterarCategoria(4, "Carnes vermelha");*/

            /* Remover o valor*//*
            new Infra.LinQ.Repositorio.RepositorioCategoria().ExcluirCategoria(4);*/

            /*Retorna todos os produtos*//*
            var lista2 = new Infra.LinQ.Repositorio.RepositorioCategoria().ListarTudo();
            Console.WriteLine("--------------- LinQ: ");
            lista2.ForEach(x => Console.WriteLine(x.Nome));*/



            #endregion


            #region Tutorial-8
            /*
            try
            {
                int qtde = 1000000;
                string tempoProcessamentoNormal = ProcessamentoNormal(qtde);
                string tempoProcessamentoParalelo = ProcessamentoParalelo(qtde);

                Console.WriteLine("Tempo Processamento Paralelo " + tempoProcessamentoParalelo);
                Console.WriteLine("Tempo Processamento Normal " + tempoProcessamentoNormal);


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }*/
            #endregion

            Console.ReadKey();

        }


        /// <summary>
        /// Método do tutorial 8 processamento normal
        /// </summary>
        private static string ProcessamentoNormal(int qtde)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < qtde; i++)
            {
                Console.WriteLine("Escrevendo a linha: "+ i.ToString());
            }

            sw.Stop();

            return sw.Elapsed.ToString();
        }


        /// <summary>
        /// Método do tutorial 8 processamento paralelo
        /// </summary>
        private static string ProcessamentoParalelo(int qtde)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Parallel.For(0, qtde, index =>
           {
               Console.WriteLine("Escrevendo a linha: " + index.ToString());
           });

            sw.Stop();

            return sw.Elapsed.ToString();
        }



    }

    public class ItensSelecionados
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public int Dia { get; set; }
    }

    public class ProdutosAgrupados
    {
        public string NomeDaCategoria { get; set; }

        public int ValorMinimo { get; set; }

        public int ValorMaximo { get; set; }
        
    }
}
