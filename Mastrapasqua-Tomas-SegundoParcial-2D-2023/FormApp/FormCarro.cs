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
        //Vendedor vendedor;
        List<Clases.Factura> facturas;
        //List<Cliente> listaFacturas;
        public FormCarro(Clases.Factura factura)
        {
            InitializeComponent();
            //this.vendedor = vendedor;
            //this.facturas = facturas;

            inicializarFacturas(factura);

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public FormCarro(Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            dataGridView1.Columns[0].HeaderText = "Corte";
            dataGridView1.Columns[1].HeaderText = "Cantidad";
            dataGridView1.Columns[2].HeaderText = "Precio Total";
            this.Name = $"Carro de {cliente.Nombre}";//ver


            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            inicializarCarro();

        }

        public FormCarro(List<Clases.Factura> facturas, bool esListado)
        {
            InitializeComponent();

            //this.listaFacturas = listaClientes;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (facturas.Count > 0 && facturas != null)
            {
                foreach (Clases.Factura factura in facturas)
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
        public void inicializarFacturas(Clases.Factura factura)
        {


            // Nueva fila para poder cargar datos del vendedor
            DataGridViewRow row = new DataGridViewRow();


            // Celda 1 creada
            DataGridViewCell cellNumero = new DataGridViewTextBoxCell();
            cellNumero.Value = factura.Numero;
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

        /// <summary>
        /// carga el carro del vendedor recorriendo la lista del Carro de compra
        /// </summary>
        public void inicializarCarro()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < cliente.ListaCompras.Count; i++)
            {

                Carniceria producto = Tienda.ObtenerCorteCarne(cliente.ListaCompras[i].IdProducto);
                float precioTotal = (cliente.ListaCompras[i].CantidadComprada * producto.PreciosCarne);

                if (producto != null)
                {

                    // Nueva fila para poder cargar datos del vendedor
                    DataGridViewRow row = new DataGridViewRow();


                    // Celda 1 creada (Nombre del producto)
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    cell.Value = producto.CortesCarne.ToString();
                    row.Cells.Add(cell);

                    // Celda 2 creada
                    DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                    cell2.Value = cliente.ListaCompras[i].CantidadComprada.ToString();
                    row.Cells.Add(cell2);

                    // Celda 3 creada
                    DataGridViewCell cellPrecio = new DataGridViewTextBoxCell();
                    cellPrecio.Value = precioTotal.ToString();  
                    row.Cells.Add(cellPrecio);


                    dataGridView1.Rows.Add(row);
                }

            }
        }




        private void FormCarro_Load(object sender, EventArgs e)
        {

        }
    }
}
