using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Factura
    {
        int numero;
        float total;
        string mailCompra;
        StringBuilder sbCompra;

        public Factura(int numero, float total, string mailCompra) 
        {
            this.numero = numero;
            this.total = total;
            this.mailCompra = mailCompra;
            this.sbCompra = sbCompra;
        
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        public string Mail
        {
            get { return mailCompra; }
            set { mailCompra = value; }
        }

        public StringBuilder Compra
        {
            get { return sbCompra; }
            set { sbCompra = value; }
        }
    }
}
