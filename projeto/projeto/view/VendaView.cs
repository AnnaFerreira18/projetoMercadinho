
using projeto.Control;
using projeto.Model;

namespace projeto.view
{
    public class VendaView
    {
        private VendaController controller;

        public VendaView()
        {
            controller = new VendaController();
        }
        public void CriarMenu()
        {
            int opcao = 0;

            do
            {
                string menu = @"
                 ///// VENDA /////

                  Escolha uma opçao:

                  1 - Cadastrar
                  2 - Listar 
                  9 - Voltar ao menu principal 
                ";
                Console.WriteLine(menu);
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
            Console.WriteLine("CADASTRAR VENDA: ");
            var clienteController = new ClienteController();
            var listaClientes = clienteController.Listar();

            for ( int i = 0; i < listaClientes.Count; i++ )
            {
                Console.WriteLine(String.Format("{0} - {1} ({2})", i, listaClientes[i].Nome, listaClientes[i].Cpf));
            }
            Console.WriteLine(" INFORME O CODIGO DO CLIENTE ");
            int codigoCliente = Int32.Parse(Console.ReadLine());

            Venda venda = new Venda();
            venda.data = DateTime.Now;
            venda.cliente = listaClientes[codigoCliente];

            Console.WriteLine();

            var produtoController = new ProdutoController();
            var listaProdutos = produtoController.Listar();

            for (int i = 0; i < listaProdutos.Count; i++)
            {
                Console.WriteLine(String.Format("{0} - {1} ({2})", i, listaProdutos[i].descriçao, listaProdutos[i].valor));
            }

            int maisItem = 1;

            while (maisItem == 1)
            {
                Console.WriteLine(" INFORME O CODIGO DO PRODUTO ");
                int codigoProduto = Int32.Parse(Console.ReadLine());
                Console.WriteLine(" INFORME A QUANTIDADE ");
                int quantidade = Int32.Parse(Console.ReadLine());

                ItemVenda item = new ItemVenda();
                item.produto = listaProdutos[codigoProduto];
                item.quantidade = quantidade;

                venda.Items.Add(item);

                Console.WriteLine(" 1- CONTINUAR OU 2 - SAIR");
                maisItem = Int32.Parse(Console.ReadLine());
            }

            controller.Gravar(venda);
            Console.Clear();

        }
        private void Listar()
        {
            Console.WriteLine("LISTA DE VENDAS: ");
            var lista = controller.Listar();
            foreach (var v in lista)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Data: " + v.data.ToString("D"));
                Console.WriteLine(String.Format("Cliente: {0} - {1}", v.cliente.Nome, v.cliente.Cpf));
                Console.WriteLine(" itens: ");
                foreach( var i in v.Items)
                {
                    Console.WriteLine(String.Format(" {0} - {1} - {2}", i.produto.descriçao, i.quantidade, i.produto.valor));
                }
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
            }
        }
    }
}

