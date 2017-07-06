
using System;
/// <summary>
/// Provides a simple, easy to understand/user interface over a large and sophisticated body of code
/// Build a Façade to provide a simplified API over a set of classes
/// May wish to (optionally) expose internals through the façade
/// May allow users to escalate to use more complex APIs if they need to
/// </summary>
namespace Façade
{
    public class Facade
    {
        private LimiteCredito limite = new LimiteCredito();
        private Serasa serasa = new Serasa();
        private Cadin cadin = new Cadin();

        public bool ConcederEmprestimo(Cliente cliente, double valor)
        {
            Console.WriteLine("{0} esta pleitando um empréstimo no valor de {1:C}\n", cliente.Nome, valor);

            bool ConcederEmprestimo = true;

            if (serasa.EstaNoSerasa(cliente))
            {
                // Verifica o Serasa
                Console.WriteLine("Cliente " + cliente.Nome + " possui restrição no SERASA");
                ConcederEmprestimo = false;
            }
            else if (cadin.EstaNoCadin(cliente))
            {
                // Verifica o Cadin
                Console.WriteLine("Cliente " + cliente.Nome + " possui restrição no CADIN");
                ConcederEmprestimo = false;
            }
            else if (!limite.PossuiLimiteCredito(cliente, valor))
            {
                //verifica se o cliente tem limite de crédito para o valor requerido
                Console.WriteLine("O Cliente {0} possui limite de crédido inferior a {1:C}\n ", cliente.Nome, valor);
                ConcederEmprestimo = false;
            }
            //true-concede  false-nega
            return ConcederEmprestimo;
        }
    }
}
