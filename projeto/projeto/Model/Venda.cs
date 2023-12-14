
using System.Data;

namespace projeto.Model
{
    public class Venda
    {
        public DateTime data {  get; set; }
        public Cliente cliente { get; set; }

        public List<ItemVenda> Items { get; set; }

        public Venda()
        {
             Items = new List<ItemVenda>();
        }
    }
}
