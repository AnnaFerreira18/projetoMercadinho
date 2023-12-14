
using projeto.Model;

namespace projeto.Control
{
    public class VendaController
    {
        private VendaDAO Dao;

        public VendaController()
        {
            Dao = new VendaDAO();
        }

        public void Gravar(Venda venda)
        {
            Dao.Gravar(venda);
        }

        public List<Venda> Listar()
        {
            return Dao.Listar();
        }
    }
}

