using Clases;
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
            Cantidad.Maximum = 0;



        }

        /// <summary>
        /// Método que inicializa algunos datos como la lista de clientes, el datagRidView y la listBox con los cortes para vender
        /// Se ejecuta al cargar el formulario
        /// </summary>
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
        /// <summary>
        /// Carga los datos del vendedor en el DataGridView.
        /// </summary>
        /// <param name="vendedor">El vendedor cuyos datos se cargarán en el DataGridView.</param>
        public void cargarDataGridView(Vendedor vendedor)
        {
            dataGridViewCarne.Rows.Clear();

            //vendedor = this.vendedorCarniceria;
            for (int i = 0; i < vendedor.Carne.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();


                // Celda 1 creada (Corte)
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Value = vendedor.Carne[i].CortesCarne;
                row.Cells.Add(cell);

                // Celda 2 creada (Tipo)
                DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = vendedor.Carne[i].TipoCarne.ToString();
                row.Cells.Add(cell2);

                // Celda 3 creada (Precio)
                DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                cell3.Value = vendedor.Carne[i].PreciosCarne;
                row.Cells.Add(cell3);

                // Celda 4 creada (Cantidad)
                DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                cell4.Value = vendedor.Carne[i].CantidadCarne;
                row.Cells.Add(cell4);
                
                dataGridViewCarne.Rows.Add(row);
            }
        }

        /// <summary>
        /// Carga los datos de la lista de cortes de carne en el ListBox
        /// </summary>
        public void cargarListBox()
        {
            foreach (Carniceria carne in vendedorCarniceria.Carne)
            {
                ListCarro.Items.Add(carne.CortesCarne);
            }
        }



        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Regresar"
        /// Muestra el formulario de inicio de sesión y oculta el formulario actual
        /// </summary>
        private void botonRegresar_Click(object sender, EventArgs e)
        {
            FormLogin.Show();
            this.Hide();

        }



        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Agregar"
        /// Abre el formulario de alta que permite agregar un nuevo corte de carne y oculta el formulario actual
        /// </summary>
        private void botoAgregar_Click(object sender, EventArgs e)//BIEN
        {

            FormAlta formAlta = new FormAlta(vendedorCarniceria, this);
            formAlta.Show();

        }


        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "?" que tiene instrucciones sobre el programa y su funcionamiento
        /// Muestra un mensaje de ayuda con las instrucciones para agregar y modificar cortes de carne
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)//BIEN
        {
            MessageBox.Show($"1. Agregar es para ingresar un nuevo corte de carne a la carniceria\n2. Modificar se refiere a cambiar el valor de algun corte de carne. El corte de carne se selecciona en el ComboBox\n" +
                $"\n3. Eliminar es para borrar por completo un corte de carne ingresado\nPara ambas opciones es ecesario haber igresado los datos en cada campo ");
        }






        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Modificar" 
        /// Abre el formulario de Alta que permite modificar un corte de carne agregado previamente y cierra este form
        /// </summary>
        private void BotonModificar_Click(object sender, EventArgs e)
        {
            FormAlta formAlta = new FormAlta(vendedorCarniceria, true, this);
            formAlta.Show();
        }

        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Actualizar" 
        /// Vuelve a cargar los datos del vendedor en el DataGridView
        /// </summary>
        private void Actualizar_Click(object sender, EventArgs e)
        {
            cargarDataGridView(vendedorCarniceria);

        }

        /// <summary>
        /// Método que se ejecuta cuando se selecciona un cliente en la lista 
        /// Habilita el botón "Ver carro" si el cliente tiene elementos en su carrito
        /// </summary>
        private void ListClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListClientes.SelectedIndex > -1 && listaClientes[ListClientes.SelectedIndex].ListaCompras.Count == 0)
            {
                
                    BotonVerCarro.Text = $"Ver carro de {listaClientes[ListClientes.SelectedIndex].Nombre}";
                    ListClientes.Enabled = false;               

            }

        }

        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Aceptar" 
        /// Crea una factura para el cliente seleccionado y actualiza los datos del vendedor y del cliente
        /// </summary>
        private void BotonAceptar_Click(object sender, EventArgs e)
        {

            if (ListClientes.Items.Count > 0 && ListClientes.SelectedIndex >= 0)
            {

                if (listaClientes[ListClientes.SelectedIndex].ListaCompras.Count > 0)
                {
                    //float total = listaClientes[ListClientes.SelectedIndex].ObtenerPrecioTotal();

                    restarCantidad(listaClientes[ListClientes.SelectedIndex]);
                    float total = listaClientes[ListClientes.SelectedIndex].ObtenerPrecioTotal();

                    crearFacturas(listaClientes[ListClientes.SelectedIndex], total, vendedorCarniceria);
                    MessageBox.Show($"{vendedorCarniceria.Carne[1].CantidadCarne}");


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
                           
                            vendedorCarniceria.Carne[j].restarCantidad(listado.ListaCompras[i].CantidadComprada);
                            listado.ListaCompras[i].Comprado = true;
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
            }
            else
            {

                Factura f = vendedor.crearFacturas(total, cliente.Nombre, true);

            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Ver carro" 
        /// Abre el formulario de visualización del carrito del cliente seleccionado
        /// </summary>
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

        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Vender"
        /// Agrega un corte de carne al carrito del cliente seleccionado
        /// </summary>
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

        /// <summary>
        /// Método que se ejecuta cuando se selecciona un corte de carne en el ListBox
        /// Actualiza el precio total en función de la cantidad seleccionada
        /// </summary>
        private void ListCarro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cantidad.Maximum = vendedorCarniceria.Carne[ListCarro.SelectedIndex].CantidadCarne;
            Cantidad.Value = 0;
            PrecioKilo.Text = $"Precio (KILO): {vendedorCarniceria.Carne[ListCarro.SelectedIndex].PreciosCarne.ToString()}$";
            PrecioTotal.Text = $"Precio total: {(vendedorCarniceria.Carne[ListCarro.SelectedIndex].PreciosCarne * Cantidad.Value).ToString()}$";


        }

        /// <summary>
        /// Método que se ejecuta cuando se cambia la cantidad en el control NumericUpDown 
        /// Actualiza el precio total en función de la nueva cantidad seleccionada
        /// </summary>
        private void Cantidad_ValueChanged(object sender, EventArgs e)
        {
            if (ListCarro.SelectedIndex > -1)
            {
                PrecioTotal.Text = $"Precio total: {(vendedorCarniceria.Carne[ListCarro.SelectedIndex].PreciosCarne * Cantidad.Value).ToString()}$";
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Cancelar cliente" 
        /// Cancela la compra del cliente seleccionado y vacía su carrito
        /// </summary>
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
