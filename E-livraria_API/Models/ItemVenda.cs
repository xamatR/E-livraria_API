using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_livraria_API.Models
{
    public class ItemVenda
    {
        [Key]
        public int id { get; private set; }
        public int idCliente { get; private set; }
        public int idLivros { get; protected set; }

        public ItemVenda()
        {
        }

        public ItemVenda(int idCliente, int idLivros)
        {
            this.idCliente = idCliente;
            this.idLivros = idLivros;
        }
      
    }
}
