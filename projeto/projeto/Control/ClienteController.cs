
using projeto.Model;

namespace projeto.Control
{
    public class ClienteController
    {
        private ClienteDAO Dao;

        public ClienteController()
        {
            Dao = new ClienteDAO();
        }

        public void Gravar(Cliente cliente)
        {
            if (cliente.Valido())
            {
                Dao.Gravar(cliente);
            }
            else
            {
                Console.WriteLine(" dados invalidos! ");
            }
        }

        public List<Cliente> Listar()
        {
            return Dao.Listar();
        }
        public void excluir(int codigo)
        {
            Dao.excluir(codigo);
        }

    }
}
