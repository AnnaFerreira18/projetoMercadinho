using System.Drawing;

namespace projeto.Model
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }

        public bool Valido()
        {
            if (Cpf != null && Nome != null)
            {
                return true;
            }

            return false;
        }

    }
}
