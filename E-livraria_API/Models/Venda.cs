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

        public Venda(Livro livrosVenda, Cliente cliente)
        {
            status = StatusVenda.pendende;
            dataCompra = DateTime.Now;
            verificaPagamento(cliente, livrosVenda);           
        }
        protected bool verificaPagamento(Cliente cliente , Livro livrosVenda)
        {
            getTotal(livrosVenda);
            //To do -> adicionar metodos de pagamento, e verificar compra aprovada se for aprovada continua.
            if (true /*metodo de pagamento resposta = 'OK'*/)
            {
                vendaConcluida(cliente, livrosVenda);
            }
            else //Caso não aprovada mudar o status para não paga.
            {
                vendaCancelada();
            }
            return true;
        }

        public void getTotal(Livro livros)
        {
            /*
            this.valor = 0.0;
            for (int i = 0; i < livros.Count; i++)
            {
                this.valor += livros.ElementAt(i).preco;
            }*/
            this.valor = livros.preco;
        }

        private void vendaConcluida(Cliente cliente, Livro livrosVenda)
        {
            status = StatusVenda.pago;
            itemVenda = new ItemVenda(cliente, livrosVenda);
        }

        private void vendaCancelada()
        {
            status = StatusVenda.cancelada;
        }
    }
}
