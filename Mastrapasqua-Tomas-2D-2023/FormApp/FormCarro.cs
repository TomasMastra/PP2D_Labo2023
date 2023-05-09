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
        List<Cliente> listaFacturas;
        bool esCarro;
        public FormCarro(Cliente cliente)
        {
            InitializeComponent();
            this.esCarro = false;
            this.cliente = cliente;
            this.Name = "FormFacturas";
            inicializarFacturas(cliente);
        }

        public FormCarro(Cliente cliente, bool esCarro)
        {
            InitializeComponent();

            this.cliente = cliente;
            if (esCarro = true)
            {
                inicializarCarro();
            }
        }

        public FormCarro(List<Cliente> listaClientes)
        {
            InitializeComponent();

            this.listaFacturas = listaClientes;


            foreach (Cliente c in listaFacturas)
            {
                inicializarFacturas(c);
            }

        }

        /// <summary>
        /// Carga una dataGriedView con las facturas del cliente, si se usa un form para llamar esta funcion
        /// se puede mostrar las facturas de todos los clientes, esto lo usa el vendedor para ver todas las facturas
        /// </summary>
        public void inicializarFacturas(Cliente cliente)
        {


            for (int i = 0; i < cliente.ListaFacturas.Count; i++)
            {


                // Nueva fila para poder cargar datos del vendedor
                DataGridViewRow row = new DataGridViewRow();


                // Celda 1 creada
                DataGridViewCell cellNumero = new DataGridViewTextBoxCell();
                cellNumero.Value = dataGridView1.RowCount + 1;
                row.Cells.Add(cellNumero);

                // Celda 2 creada
                DataGridViewCell cellTotal = new DataGridViewTextBoxCell();
                cellTotal.Value = cliente.ListaFacturas[i].Total.ToString();
                row.Cells.Add(cellTotal);

                // Celda 3 creada
                DataGridViewCell cellMail = new DataGridViewTextBoxCell();
                cellMail.Value = cliente.ListaFacturas[i].Mail;
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
