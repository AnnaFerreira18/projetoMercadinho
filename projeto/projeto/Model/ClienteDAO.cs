
namespace projeto.Model
{
    public class ClienteDAO
    {
        public void Gravar(Cliente cliente)
        {
            BancoDeDadosFake.clientes.Add(cliente);
        }
        public List<Cliente> Listar()
        {
            return BancoDeDadosFake.clientes;

        }
        public void excluir(int codigo)
        {
            BancoDeDadosFake.clientes.RemoveAt(codigo);

        }
    }
}
