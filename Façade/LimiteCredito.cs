
using System;
/// <summary>
/// Provides a simple, easy to understand/user interface over a large and sophisticated body of code
/// Build a Façade to provide a simplified API over a set of classes
/// May wish to (optionally) expose internals through the façade
/// May allow users to escalate to use more complex APIs if they need to
/// </summary>
namespace Façade
{
    public class LimiteCredito
    {
        public bool PossuiLimiteCredito(Cliente cliente, double valor)
        {
            Console.WriteLine("Verificando o limite de crédito do cliente " + cliente.Nome);
            if (valor > 200000.00)
                return false;
            else
                return true;
        }
    }
}
