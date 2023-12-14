
using projeto.Control;
using projeto.Model;

namespace projeto.view
{
    public class ProdutoView
    {
        private ProdutoController controller;

        public ProdutoView() 
        {
            controller = new ProdutoController();
        }
        public void CriarMenu()
        {
            int opcao = 0;

            do
            {
                string menu = @"
                 ///// PRODUTO /////

                  Escolha uma opçao:

                  1 - Cadastrar
                  2 - Listar 
                  3 - Excluir 
                  9 - voltar ao menu principal
                   
                ";
                Console.WriteLine(menu);

                /*
                 * CRUD 
                 * C- CREATE INSERIR
                 * R- READ LER
                 * U- UPDATE ALTERAR
                 * D- DELETE DELETAR
                 * */

                try
                {

                    opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            Console.Clear();
                            this.Cadastrar();
                            break;
                        case 2:
                            Console.Clear();
                            this.Listar();
                            break;
                        case 3:
                            Console.Clear();
                            this.Excluir();
                            break;
                        case 9:
                            Console.Clear();
                            MenuView mv = new MenuView();
                            mv.CriarMenuPrincipal();
                            break;
                        default:
                            throw new Exception(" opçao selecionada nao existe ");
                    }

                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine(" opçao invalida ");
                }

            } while (opcao != 9);
        }

        private void Cadastrar()
        {
            Console.WriteLine(" CADASTRAR PRODUTO: ");
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Valor: ");
            double valor = Double.Parse(Console.ReadLine());

            Produto p = new Produto();
            p.descriçao = descricao;
            p.valor = valor;

            ProdutoController control = new ProdutoController();
            controller.Gravar(p);
            Console.Clear();
        }
        private void Listar()
        {
            Console.WriteLine("LISTA DE PRODUTOS: ");
            var lista = controller.Listar();
            int cont = 0;
            foreach (var p in lista)
            {
                Console.WriteLine(String.Format("{0} - {1} ({2})", cont++, p.descriçao, p.valor.ToString("C2")));
            }
        }
        private void Excluir()
        {
            this.Listar();
            Console.WriteLine();
            Console.WriteLine("EXCLUIR PRODUTO: ");
            Console.WriteLine("Digite o código a ser excluído:");
            int codigo = Int32.Parse(Console.ReadLine());

            controller.excluir(codigo);
            Console.Clear();
        }
    }
}