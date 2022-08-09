using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_livraria_API.Models.Enums;

namespace E_livraria_API.Models
{
    public class Venda{
        public int id { get; private set; }
        public DateTime dataCompra { get; private set; }
        public double valor { get; private set; }
        public StatusVenda status { get; private set; }
        public ItemVenda itemVenda { get; private set; }

        public Venda()
        {
        }

        public Venda(Livro livrosVenda)
        {
            status = StatusVenda.pendende;
            dataCompra = DateTime.Now;
            this.valor = livrosVenda.preco;
            this.itemVenda = itemVenda;
        }

        public void setStatus(StatusVenda status)
        {
            this.status = status;
        }

        public void setItemVenda(ItemVenda itemVenda)
        {
            this.itemVenda = itemVenda;
        }

        /*
        protected bool verificaPagamento(int idCliente, int idLivro)
        {
            //To do -> adicionar metodos de pagamento, e verificar compra aprovada se for aprovada continua.
            if (true /*metodo de pagamento resposta = 'OK')
            {
                vendaConcluida(idCliente, idCliente);
            }
            else //Caso não aprovada mudar o status para não paga.
            {
                vendaCancelada();
            }
            return true;
        }

        private void vendaConcluida(int idCliente, int idLivro)
        {
            status = StatusVenda.pago;
            itemVenda = new ItemVenda(idCliente, idLivro);
        }

        private void vendaCancelada()
        {
            status = StatusVenda.cancelada;
        }*/
    }
}
