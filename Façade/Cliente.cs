/// <summary>
/// Provides a simple, easy to understand/user interface over a large and sophisticated body of code
/// Build a Façade to provide a simplified API over a set of classes
/// May wish to (optionally) expose internals through the façade
/// May allow users to escalate to use more complex APIs if they need to
/// </summary>
namespace Façade
{
    public class Cliente
    {
        public string Nome { get; set; }
        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}
