using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class FormCarro : Form
    {
        Cliente cliente;
        Vendedor vendedor;
        List<Factura> facturas;
        //List<Cliente> listaFacturas;
        public FormCarro(Factura factura)
        {
            InitializeComponent();
            //this.vendedor = vendedor;
            //this.facturas = facturas;
            this.Name = "FormFacturas";

            inicializarFacturas(factura);
        }

        public FormCarro(Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            
                inicializarCarro();
            
        }

        public FormCarro(List<Factura> facturas, bool esListado)
        {
            InitializeComponent();

            //this.listaFacturas = listaClientes;

            if (facturas.Count > 0 && facturas != null)
            {
                foreach(Factura factura in facturas)
                {
                    inicializarFacturas(factura);
                }
            }
            else
            {
                MessageBox.Show($"Hubo un error");
                this.Hide();
            }

        }

        /// <summary>
        /// Carga una dataGriedView con las facturas del cliente, si se usa un form para llamar esta funcion
        /// se puede mostrar las facturas de todos los clientes, esto lo usa el vendedor para ver todas las facturas
        /// </summary>
        public void inicializarFacturas(Factura factura)
        {




            //for (int i = 0; i < factura.Count; i++)
            {
                // Nueva fila para poder cargar datos del vendedor
                DataGridViewRow row = new DataGridViewRow();


                // Celda 1 creada
                DataGridViewCell cellNumero = new DataGridViewTextBoxCell();
                cellNumero.Value = dataGridView1.RowCount + 1;
                row.Cells.Add(cellNumero);

                // Celda 2 creada
                DataGridViewCell cellTotal = new DataGridViewTextBoxCell();
                cellTotal.Value = factura.Total.ToString();
                row.Cells.Add(cellTotal);

                // Celda 3 creada
                DataGridViewCell cellMail = new DataGridViewTextBoxCell();
                cellMail.Value = factura.Mail;
                row.Cells.Add(cellMail);


                dataGridView1.Rows.Add(row);
            }
            
        }

        /// <summary>
        /// carga el carro del vendedor recorriendo la lista del Carro de compra
        /// </summary>
        public void inicializarCarro()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < cliente.ListaCompras.Count; i++)
            {


                // Nueva fila para poder cargar datos del vendedor
                DataGridViewRow row = new DataGridViewRow();


                // Celda 1 creada
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Value = cliente.ListaCompras[i].Producto;
                row.Cells.Add(cell);

                // Celda 2 creada
                DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = cliente.ListaCompras[i].CantidadComprada.ToString();
                row.Cells.Add(cell2);

                // Celda 3 creada
                DataGridViewCell cellPrecio = new DataGridViewTextBoxCell();
                cellPrecio.Value = cliente.ListaCompras[i].PrecioTotal;
                row.Cells.Add(cellPrecio);


                dataGridView1.Rows.Add(row);

            }
        }


        

        private void FormCarro_Load(object sender, EventArgs e)
        {

        }
    }
}
