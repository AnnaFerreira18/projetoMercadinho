
using projeto.Model;

namespace projeto.Control
{
    public class ProdutoController
    {
        private ProdutoDAO Dao;

        public ProdutoController()
        {
            Dao = new ProdutoDAO();
        }

        public void Gravar(Produto produto)
        {
            if (produto.EValido()) 
            {
                Dao.Gravar(produto); 
            }
            else
            {
                Console.WriteLine(" dados invalidos! ");
            }
        }

        public List<Produto> Listar() 
        {
            return Dao.Listar();
        }
        public void excluir(int codigo)
        {
            Dao.excluir(codigo);
        }
        
    }
}
