

using projeto.Control;
using projeto.Model;

namespace projeto.view
{
    public class ClenteView
    {
        private ClienteController controller;

        public ClenteView()
        {
            controller = new ClienteController();
        }
        public void CriarMenu()
        {
            int opcao = 0;

            do
            {
                string menu = @"
                 ///// CLIENTE /////
                 
                  Escolha uma opçao:

                  1 - Cadastrar
                  2 - Listar 
                  3 - Excluir 
                  9 - Voltar ao menu principal
                
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
            Console.WriteLine(" CADASTRAR CLIENTE: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cpf: ");
            string cpf =Console.ReadLine();

            Cliente c = new Cliente();
            c.Nome = nome;
            c.Cpf = cpf;

            ClienteController control = new ClienteController();
            controller.Gravar(c);
            Console.Clear();
        }
        private void Listar()
        {
            Console.WriteLine(" LISTA DE CLIENTES: ");
            var lista = controller.Listar();
            int cont = 0;
            foreach (var p in lista)
            {
                Console.WriteLine(String.Format("{0} - {1} {2}", cont++, p.Nome, p.Cpf));
            }
        }
        private void Excluir()
        {
            this.Listar();
            Console.WriteLine();
            Console.WriteLine(" EXCLUIR CLIENTE: ");
            Console.WriteLine("Digite o cpf a ser excluído:");
            int codigo = Int32.Parse(Console.ReadLine());

            controller.excluir(codigo);
            Console.Clear();
        }
    }
}
   
