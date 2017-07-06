
using System;
/// <summary>
/// Provides a simple, easy to understand/user interface over a large and sophisticated body of code
/// Build a Façade to provide a simplified API over a set of classes
/// May wish to (optionally) expose internals through the façade
/// May allow users to escalate to use more complex APIs if they need to
/// </summary>
namespace Façade
{
    public class Cadin
    {
        public bool EstaNoCadin(Cliente cliente)
        {
            Console.WriteLine("Verificando o CADIN para o cliente " + cliente.Nome);
            return false;
        }
    }
}
