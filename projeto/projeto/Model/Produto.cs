
namespace projeto.Model
{
    public class Produto
    {
        public string descriçao { get; set; }
        public double valor {  get; set; }

        public bool EValido()
        {
            if (descriçao != null && valor != 0)
            {
                return true;
            }

            return false;
        }

    }
}
