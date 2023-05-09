using Clases;

namespace FormApp
{
    public partial class Heladera : Form
    {

        Form FormLogin;
        Vendedor vendedorCarniceria;
        List<Cliente> listaClientes;
        public Heladera()
        {
            InitializeComponent();

        }

        public Heladera(Vendedor vendedor, Form formLogin, List<Cliente> listaClientes) : this()
        {

            this.vendedorCarniceria = vendedor;
            this.FormLogin = formLogin;
            dataGridViewCarne.CurrentCell = null;//ver
            this.listaClientes = listaClientes;



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

            FormAlta formAlta = new FormAlta(vendedorCarniceria);
            formAlta.Show();

        }


        private void button1_Click_1(object sender, EventArgs e)//BIEN
        {
            MessageBox.Show($"1. Agregar es para ingresar un nuevo corte de carne a la carniceria\n2. Modificar se refiere a cambiar el valor de algun corte de carne. El corte de carne se selecciona en el ComboBox\n" +
                $"\n3. Eliminar es para borrar por completo un corte de carne ingresado\nPara ambas opciones es ecesario haber igresado los datos en cada campo ");
        }







        private void button7_Click(object sender, EventArgs e)
        {
            FormAlta formAlta = new FormAlta(vendedorCarniceria, true);
            formAlta.Show();
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            cargarDataGridView(vendedorCarniceria);

        }

        private void ListClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaProductos.Items.Clear();
            //MessageBox.Show($"{listaClientes[ListClientes.SelectedIndex].ListaCompras.Count}");
            if (ListClientes.SelectedIndex >= 0 && listaClientes[ListClientes.SelectedIndex].ListaCompras.Count > 0)
            {
                for (int i = 0; i < listaClientes[ListClientes.SelectedIndex].ListaCompras.Count; i++)
                {
                    {
                        ListaProductos.Items.Add(listaClientes[ListClientes.SelectedIndex].ListaCompras[i].Producto.ToString());



                    }
                }

            }
            else
            {
                ListaProductos.Items.Add("No hay nada en la lista");
            }
        }

        private void BotonAceptar_Click(object sender, EventArgs e)
        {
            //FormLogin f = new FormLogin();
            // int index;

            //MessageBox.Show($"{listaClientes[ListClientes.SelectedIndex].Nombre}\n{listaClientes[ListClientes.SelectedIndex].ListaCompras[0].PrecioTotal}\n{listaClientes[ListClientes.SelectedIndex].ListaCompras[1].PrecioTotal}\n{listaClientes[ListClientes.SelectedIndex].ListaCompras[2].PrecioTotal}");
            //if (ListClientes.Items.Count > 0 && listaClientes[ListClientes.SelectedIndex].ListaCompras.Count > 0 && ListClientes.SelectedIndex >=)
            if (ListClientes.Items.Count > 0 && ListClientes.SelectedIndex >= 0 && listaClientes[ListClientes.SelectedIndex].ListaCompras.Count > 0)
            {
                float total = listaClientes[ListClientes.SelectedIndex].ObtenerPrecioTotal();

                    restarCantidad(listaClientes[ListClientes.SelectedIndex]);
                    crearFacturas(listaClientes[ListClientes.SelectedIndex], total);
                    listaClientes[ListClientes.SelectedIndex].ListaCompras.Clear();
                    //ListClientes.SelectedIndex = -1;
                    ListaProductos.Items.Clear();


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
            FormCarro formFacturas = new FormCarro(listaClientes);
            formFacturas.Show();
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
                            //MessageBox.Show($"{vendedorCarniceria.Carne[j].CantidadCarne -listado.ListaCompras[i].CantidadComprada}");

                            vendedorCarniceria.Carne[j].CantidadCarne = vendedorCarniceria.Carne[j].CantidadCarne - listado.ListaCompras[i].CantidadComprada;
                        }
                        else
                        {
                            MessageBox.Show($"El corte de carne {vendedorCarniceria.Carne[j].CortesCarne} no se vendeio debido a que no hay stock suficiente");
                        }
                    }

                }
            }


        }

        /// <summary>
        /// Crea la factura al cliente
        /// </summary>
        public void crearFacturas(Cliente cliente, float total)
        {


            if (esRecargo.Checked != false)
            {
                cliente.crearFacturas(total, false);
            }
            else
            {

                cliente.crearFacturas(total, false);
            }
        }


    }
}
