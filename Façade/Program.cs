
using System;
/// <summary>
/// Provides a simple, easy to understand/user interface over a large and sophisticated body of code
/// Build a Façade to provide a simplified API over a set of classes
/// May wish to (optionally) expose internals through the façade
/// May allow users to escalate to use more complex APIs if they need to
/// </summary>
namespace Façade
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria uma instância do Facade
            Facade concedeCredito = new Facade();

            // Cria uma instância de um  novo Cliente informando o nome
            Cliente cliente1 = new Cliente("Macoratti");

            //Utiliza o Facade para verificar condições de concessão ou não
            bool resultado = concedeCredito.ConcederEmprestimo(cliente1, 199000.00);

            //exibe o resultado
            Console.WriteLine("O empréstimo pleiteado pelo cliente " + cliente1.Nome + " foi  " + (resultado ? "Aprovado" : "Negado"));

            //aguarda
            Console.ReadKey();
        }
    }
}
