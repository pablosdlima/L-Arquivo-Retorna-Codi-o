using _220_Exercicio.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220_Exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indique o Caminho do Arquivo: ");
            string arquivo = Console.ReadLine();
            Console.WriteLine("Entre com o Sálario de Busca: ");
            double sal = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            

            List<Pessoa> listap = new List<Pessoa>();
            using (StreamReader sr = File.OpenText(arquivo)) //arquivo para a leitura.
            {
                while (!sr.EndOfStream) //enquanto arquivo não terminar de ser lido
                {
                    string[] campos = sr.ReadLine().Split(',');
                    string nome = campos[0];
                    string email = campos[1];
                    double salario = Convert.ToDouble(campos[2], CultureInfo.InvariantCulture);

                    listap.Add(new Pessoa(nome,email,salario));
                }
                var ordem = listap.Where(p => p.Salario > sal).OrderBy(p => p.Nome).Select(p => p.Email);
                var soma = listap.Where(p => p.Salario >= sal).Sum(p => p.Salario);

                Console.WriteLine("Emails ordenados: ");
                foreach (var p in ordem)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine("Soma dos Produtos: " + soma);
               

                
            }
        }
    }
}
