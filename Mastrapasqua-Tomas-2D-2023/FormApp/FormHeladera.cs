﻿using Clases;
using System.Diagnostics;

namespace FormApp
{
    public partial class Heladera : Form
    {

        Form FormLogin;
        Vendedor vendedorCarniceria;
        List<Cliente> listaClientes;
        List<Factura> facturas;
        public Heladera()
        {
            InitializeComponent();
            MessageBox.Show("sajshajshashahs");



        }

        public Heladera(Vendedor vendedor, Form formLogin, List<Cliente> listaClientes, List<Factura> facturas) : this()
        {

            this.vendedorCarniceria = vendedor;
            this.FormLogin = formLogin;
            dataGridViewCarne.CurrentCell = null;//ver
            this.listaClientes = listaClientes;
            this.facturas = facturas;
            cargarDataGridView(vendedorCarniceria);


        }

        private void FormVendedor_Load(object sender, EventArgs e)
        {
            inicializar();
            cargarDataGridView(vendedorCarniceria);
            saludo.Text = $"Bienvenido {vendedorCarniceria.Nombre}";



        }
        public void inicializar()
        {




            //MessageBox.Show($"{listaClientes.Count}");
            if (ListClientes.Items.Count == 0)
            {
                for (int i = 0; i < listaClientes.Count; i++)
                {

                    ListClientes.Items.Add(listaClientes[i].Nombre);


                }
            }
            cargarDataGridView(vendedorCarniceria);
            cargarListBox();





        }

        public void cargarDataGridView(Vendedor vendedor)
        {
            dataGridViewCarne.Rows.Clear();

            //vendedor = this.vendedorCarniceria;
            for (int i = 0; i < vendedor.Carne.Count; i++)
            {
                // Nueva fila para poder cargar datos del vendedor
                DataGridViewRow row = new DataGridViewRow();


                // Celda 1 creada
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Value = vendedor.Carne[i].CortesCarne;
                row.Cells.Add(cell);

                // Celda 2 creada
                DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = vendedor.Carne[i].TipoCarne.ToString();
                row.Cells.Add(cell2);

                // Celda 3 creada
                DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                cell3.Value = vendedor.Carne[i].PreciosCarne;
                row.Cells.Add(cell3);

                // Celda 4 creada
                DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                cell4.Value = vendedor.Carne[i].CantidadCarne;
                row.Cells.Add(cell4);
                //
                dataGridViewCarne.Rows.Add(row);
            }
        }

        public void cargarListBox()
        {
            foreach (Carniceria carne in vendedorCarniceria.Carne)
            {
                ListCarro.Items.Add(carne.CortesCarne);
            }
        }




        private void botonRegresar_Click(object sender, EventArgs e)
        {
            FormLogin.Show();
            this.Hide();

        }





        /*
         * Obtiene los cortes de carne desde el datagridview
         * 
         */
        public int obtenerVendedorDesdeDataGridView(DataGridView dgv)// NO SE USA
        {


            return 2;
        }

        public int GetCellValue(DataGridView dataGridView, int rowIndex, int columnIndex)//no lo uso
        {
            return 1;
        }


        private void botoAgregar_Click(object sender, EventArgs e)//BIEN
        {

            FormAlta formAlta = new FormAlta(vendedorCarniceria, this);
            formAlta.Show();
            this.Hide();

        }


        private void button1_Click_1(object sender, EventArgs e)//BIEN
        {
            MessageBox.Show($"1. Agregar es para ingresar un nuevo corte de carne a la carniceria\n2. Modificar se refiere a cambiar el valor de algun corte de carne. El corte de carne se selecciona en el ComboBox\n" +
                $"\n3. Eliminar es para borrar por completo un corte de carne ingresado\nPara ambas opciones es ecesario haber igresado los datos en cada campo ");
        }







        private void button7_Click(object sender, EventArgs e)
        {
            FormAlta formAlta = new FormAlta(vendedorCarniceria, true, this);
            formAlta.Show();
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            cargarDataGridView(vendedorCarniceria);

        }

        private void ListClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListClientes.SelectedIndex > -1 && listaClientes[ListClientes.SelectedIndex].ListaCompras.Count == 0)
            {
                //for (int i = 0; i < listaClientes[ListClientes.SelectedIndex].ListaCompras.Count; i++)
                {
                    BotonVerCarro.Text = $"Ver carro de {listaClientes[ListClientes.SelectedIndex].Nombre}";
                    ListClientes.Enabled = false;

                }

            }

        }

        private void BotonAceptar_Click(object sender, EventArgs e)
        {

            if (ListClientes.Items.Count > 0 && ListClientes.SelectedIndex >= 0)
            {

                if (listaClientes[ListClientes.SelectedIndex].ListaCompras.Count > 0)
                {
                    float total = listaClientes[ListClientes.SelectedIndex].ObtenerPrecioTotal();

                    restarCantidad(listaClientes[ListClientes.SelectedIndex]);
                    crearFacturas(listaClientes[ListClientes.SelectedIndex], total, vendedorCarniceria);
                    listaClientes[ListClientes.SelectedIndex].ListaCompras.Clear();
                    ListClientes.SelectedIndex = -1;
                    ListClientes.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No agrego nada al carro");
                }


            }
            else
            {
                MessageBox.Show($"No selecciono un cliente");
            }
        }

        private void BotonUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{vendedorCarniceria.Mostrar()}");
        }

        private void BotonFacturas_Click(object sender, EventArgs e)
        {
            if (vendedorCarniceria.ListaFacturas != null && vendedorCarniceria.ListaFacturas.Count > 0)
            {


                FormCarro formFacturas = new FormCarro(vendedorCarniceria.ListaFacturas, true);
                formFacturas.Show();

            }
            else
            {
                MessageBox.Show("No hay facturas disponibles");

            }
        }

        public void restarCantidad(Cliente listado)
        {

            for (int i = 0; i < listado.ListaCompras.Count; i++)
            {
                for (int j = 0; j < vendedorCarniceria.Carne.Count; j++)
                {
                    if (listado.ListaCompras[i].Producto == vendedorCarniceria.Carne[j].CortesCarne)
                    {

                        if (vendedorCarniceria.Carne[j].CantidadCarne >= listado.ListaCompras[i].CantidadComprada)
                        {
                            //MessageBox.Show($"{vendedorCarniceria.Carne[j].CantidadCarne} // {listado.ListaCompras[i].CantidadComprada}");
                            //vendedorCarniceria.Carne[j].CantidadCarne = vendedorCarniceria.Carne[j].CantidadCarne - listado.ListaCompras[i].CantidadComprada;
                            MessageBox.Show($"// {vendedorCarniceria.Carne[j].restarCantidad(listado.ListaCompras[i].CantidadComprada)}");
                        }
                        else
                        {
                            MessageBox.Show($"El corte de carne {vendedorCarniceria.Carne[j].CortesCarne} no se vendio debido a que no hay stock suficiente");
                        }
                    }

                }
            }


        }

        /// <summary>
        /// Crea la factura al cliente
        /// </summary>
        public void crearFacturas(Cliente cliente, float total, Vendedor vendedor)
        {


            if (esRecargo.Checked != true)
            {
                Factura f = vendedor.crearFacturas(total, cliente.Nombre, false);
                //vendedorCarniceria.ListaFacturas.Add(f);
            }
            else
            {

                Factura f = vendedor.crearFacturas(total, cliente.Nombre, true);
                //vendedorCarniceria.ListaFacturas.Add(f);

            }
        }

        private void BotonVerCarro_Click(object sender, EventArgs e)
        {
            if (ListClientes.SelectedIndex > -1)
            {
                FormCarro formCarro = new FormCarro(listaClientes[ListClientes.SelectedIndex]);
                formCarro.Show();
            }
            else
            {
                MessageBox.Show("No selecciono ningun cliente");
            }
        }

        private void FormVender_Click(object sender, EventArgs e)
        {

            if (ListCarro.SelectedIndex > -1 && ListClientes.SelectedIndex > -1 && Cantidad.Value > 0)
            {
                if (Convert.ToInt32(dataGridViewCarne.Rows[ListCarro.SelectedIndex].Cells[3].Value) > 0 && Cantidad.Value > 0)
                {
                    string corteCarne = dataGridViewCarne.Rows[ListCarro.SelectedIndex].Cells[0].Value.ToString();
                    int cantidad = Convert.ToInt32(Cantidad.Value);
                    int precioTotal = Convert.ToInt32(dataGridViewCarne.Rows[ListCarro.SelectedIndex].Cells[2].Value) * cantidad;


                    ListaCompras carro = new ListaCompras(corteCarne, precioTotal, cantidad);

                    listaClientes[ListClientes.SelectedIndex].ListaCompras.Add(carro);
                }
                else
                {
                    MessageBox.Show("No hay mas stock de ese corte de carne seleccionado");
                }

            }
            else
            {
                MessageBox.Show("No selecciono ningun corte de carne");
            }
        }

        private void ListCarro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cantidad.Maximum = vendedorCarniceria.Carne[ListCarro.SelectedIndex].CantidadCarne;
            Cantidad.Value = 0;
            PrecioKilo.Text = $"Precio (KILO): {vendedorCarniceria.Carne[ListCarro.SelectedIndex].PreciosCarne.ToString()}$";
            PrecioTotal.Text = $"Precio total: {(vendedorCarniceria.Carne[ListCarro.SelectedIndex].PreciosCarne * Cantidad.Value).ToString()}$";


        }

        private void Cantidad_ValueChanged(object sender, EventArgs e)
        {
            PrecioTotal.Text = $"Precio total: {(vendedorCarniceria.Carne[ListCarro.SelectedIndex].PreciosCarne * Cantidad.Value).ToString()}$";
        }

        private void BotonCancelarCliente_Click(object sender, EventArgs e)
        {
            if ((ListClientes.SelectedIndex > -1))
            {
                listaClientes[ListClientes.SelectedIndex].vaciarCarro();
                ListClientes.Enabled = true;
                ListClientes.SelectedIndex = -1;
            }else
            {
                MessageBox.Show("No hay ningun cliente seleccionado para calcelar la compra");
            }


        }
    }
}
