namespace projeto.view
{
    public class MenuView
    {
        public void CriarMenuPrincipal()
        {
            int opcao = 0;

            do
            {
                string menu = @"
                   <<<< ATACADÃO >>>>

                   Escolha uma opçao:

                   1 - Cliente 
                   2 - Produtos
                   3 - Vendas 
                   4 - Testando
                   9 - Sair 

                    ";
                Console.WriteLine(menu);

                try
                {

                    opcao = Int32.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                         case 1:
                            Console.Clear();
                            ClenteView cV = new ClenteView();
                            cV.CriarMenu();
                            break;
                         case 2:
                            Console.Clear();
                            ProdutoView pV = new ProdutoView();
                            pV.CriarMenu();
                            break;
                         case 3:
                            Console.Clear();
                            VendaView vV = new VendaView();
                            vV.CriarMenu();
                            break;
                         case 9:
                            Environment.Exit(0);// finalizar programa
                            break;
                         default:
                            throw new Exception(" opçao selecionada nao existe ");
                    }

                }
                catch (Exception)
                {
                    Console.Clear() ;
                    Console.WriteLine(" opçao invalida ");
                }

            } while (opcao != 9);
        }
    }
}
