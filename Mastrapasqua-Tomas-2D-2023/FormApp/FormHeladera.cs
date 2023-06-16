using Clases;
using System.Diagnostics;
using System.Text;

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
            cargarDataGridViewCortesCarne();
        }

        public Heladera(Vendedor vendedor, Form formLogin, List<Cliente> listaClientes) : this()
        {

            this.vendedorCarniceria = vendedor;
            this.FormLogin = formLogin;
            this.listaClientes = listaClientes;
            //dataGridViewCarne.CurrentCell = null;//ver
            //cargarDataGridView(vendedorCarniceria);

        }

        private void FormVendedor_Load(object sender, EventArgs e)
        {
            inicializar();
            saludo.Text = $"Bienvenido {vendedorCarniceria.Nombre}";
            Cantidad.Maximum = 0;

        }

        /// <summary>
        /// Método que inicializa algunos datos como la lista de clientes, el datagRidView y la listBox con los cortes para vender
        /// Se ejecuta al cargar el formulario
        /// </summary>
        public void inicializar()
        {

            cargarListBoxClientes();
            cargarDataGridViewCortesCarne();
            cargarListBoxCarne();

        }
        /// <summary>
        /// Método que inicializa el listBox de clientes, cargando el nombre
        /// </summary>
        public void cargarListBoxClientes()
        {
            if (ListClientes.Items.Count == 0 && listaClientes != null && listaClientes.Count > -1)
            {
                foreach (Cliente cliente in listaClientes)
                {
                    ListClientes.Items.Add(cliente.Nombre);
                }
            }

        }

        /// <summary>
        /// Carga los datos del vendedor en el DataGridView.
        /// </summary>
        /// <param name="vendedor">El vendedor cuyos datos se cargarán en el DataGridView.</param>
        public void cargarDataGridViewCortesCarne()
        {
            List<Carniceria> listaCortes = ListaCarne.Obtener();

            dataGridViewCarne.Rows.Clear();

            foreach (Carniceria corte in listaCortes)
            {
                DataGridViewRow row = new DataGridViewRow();

                // Celda 1 creada (Corte)
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Value = corte.CortesCarne;
                row.Cells.Add(cell);

                // Celda 2 creada (Tipo)
                DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = corte.TipoCarne.ToString();
                row.Cells.Add(cell2);

                // Celda 3 creada (Precio)
                DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                cell3.Value = corte.PreciosCarne;
                row.Cells.Add(cell3);

                // Celda 4 creada (Cantidad)
                DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                cell4.Value = corte.CantidadCarne;
                row.Cells.Add(cell4);

                dataGridViewCarne.Rows.Add(row);
            }
        }

        /// <summary>
        /// Carga los datos de la lista de cortes de carne en el ListBox
        /// </summary>
        public void cargarListBoxCarne()
        {
            foreach (Carniceria carne in ListaCarne.Obtener())
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

            FormAlta formAlta = new FormAlta(this);
            formAlta.ShowDialog();
            // this.Hide();

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
            FormAlta formAlta = new FormAlta(true, this);
            formAlta.ShowDialog();
            // this.Hide();
        }




        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Actualizar" 
        /// Vuelve a cargar los datos del vendedor en el DataGridView
        /// </summary>
        private void Actualizar_Click(object sender, EventArgs e)
        {
            cargarDataGridViewCortesCarne();

        }

        /// <summary>
        /// Método que se ejecuta cuando se selecciona un cliente en la lista 
        /// Habilita el botón "Ver carro" si el cliente tiene elementos en su carrito
        /// </summary>
        private void ListClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListClientes.SelectedIndex > -1 && listaClientes[ListClientes.SelectedIndex].ListaCompras.Count == 0)
            {

                Cliente cliente = listaClientes[ListClientes.SelectedIndex];
                BotonVerCarro.Text = $"Ver carro de {cliente.Nombre}";
                ListClientes.Enabled = false;

            }

        }

        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Aceptar" 
        /// Crea una factura para el cliente seleccionado y actualiza los datos del vendedor y del cliente
        /// </summary>
        private void BotonAceptar_Click(object sender, EventArgs e)
        {

            string noSeCompro;
            if (ListClientes.SelectedIndex > -1 && ListClientes.Items.Count > 0)
            {
                Cliente clienteComprar = listaClientes[ListClientes.SelectedIndex];
                

                    if (listaClientes[ListClientes.SelectedIndex].ListaCompras.Count > 0)
                    {

                        noSeCompro = ListaCarne.Comprar(clienteComprar);
                       
                        Restablecer();
                        if (noSeCompro.Length != 21)
                        {
                            MessageBox.Show($"{noSeCompro}");
                        }else
                    {
                        MessageBox.Show($"La compra se realizo con exito!!!");

                    }


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

        /// <summary>
        /// Restablece todos los controles por default luego de realizarse una compra
        /// </summary>
        public void Restablecer()
        {
            ListClientes.SelectedIndex = -1;
            ListClientes.Enabled = true;
            ListCarro.SelectedIndex = -1;
            Cantidad.Value = 0;
        }
        ///////////////////////////////////
        

      

        /// <summary>
        /// Crea la factura al cliente
        /// </summary>
        public void crearFacturas(Cliente cliente, float total)
        {
            Clases.Factura factura = new Clases.Factura(cliente.ListaCompras.Count, total, cliente.Mail);


            if (esRecargo.Checked != true)
            {

                ListaFacturas.Agregar(factura);
            }
            else
            {
                Clases.Factura facturaCredito = new Clases.Factura(1, Convert.ToSingle(total * 0.05), cliente.Mail);

                ListaFacturas.Agregar(facturaCredito);
            }
        }


        ///////////////////////////////////////////////////

        /// <summary>
        /// Muestra los datos del vendedor que inicio sesion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{vendedorCarniceria.Mostrar()}");
        }

        private void BotonFacturas_Click(object sender, EventArgs e)
        {

            List<Clases.Factura> facturas = ListaFacturas.Obtener();

            if (facturas != null && facturas.Count > 0)
            {


                Factura formFacturas = new Factura(facturas, true);
                formFacturas.Show();

            }
            else
            {
                MessageBox.Show("No hay facturas disponibles");

            }
        }


        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Vender"
        /// Agrega un corte de carne al carrito del cliente seleccionado
        /// </summary>
        private void FormVender_Click(object sender, EventArgs e)//Agregar al carro
        {
            bool existe;
            List<Carniceria> carne = ListaCarne.Obtener();
            if (ListClientes.SelectedIndex > -1)
            {
                if (ListCarro.SelectedIndex > -1 && Cantidad.Value > 0)
                {
                    if (Convert.ToInt32(dataGridViewCarne.Rows[ListCarro.SelectedIndex].Cells[3].Value) > 0 && Cantidad.Value > 0)
                    {

                        string corteCarne = carne[ListCarro.SelectedIndex].CortesCarne.ToString();
                        int cantidad = Convert.ToInt32(Cantidad.Value);
                        int precioTotal = Convert.ToInt32(carne[ListCarro.SelectedIndex].PreciosCarne) * cantidad;


                        ListaCompras carro = new ListaCompras(corteCarne, precioTotal, cantidad);




                        existe = listaClientes[ListClientes.SelectedIndex].AgregarCarro(carro);
                        PrecioTotal.Text = "";
                        //listaClientes[ListClientes.SelectedIndex].ListaCompras.Add(carro);//MODIFICAR Y HACER DENTRO DE LA CLASE DE CLIENTE

                    }
                    else
                    {
                        MessageBox.Show("No hay mas stock de ese corte de carne seleccionado");
                    }

                }
                else
                {
                    MessageBox.Show("No selecciono ningun corte de carne o no agrego cantidad");
                }
            }
            else
            {
                MessageBox.Show("No selecciono un cliente");

            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se selecciona un corte de carne en el ListBox
        /// Actualiza el precio total en función de la cantidad seleccionada
        /// </summary>
        private void ListCarro_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Carniceria> carne = ListaCarne.Obtener();

            if (ListCarro.SelectedIndex > -1)
            {
                Cantidad.Maximum = carne[ListCarro.SelectedIndex].CantidadCarne;
                Cantidad.Value = 0;
                PrecioKilo.Text = $"Precio (KILO): {carne[ListCarro.SelectedIndex].PreciosCarne.ToString()}$";
            }


        }

        /// <summary>
        /// Método que se ejecuta cuando se cambia la cantidad en el control NumericUpDown 
        /// Actualiza el precio total en función de la nueva cantidad seleccionada
        /// </summary>
        private void Cantidad_ValueChanged(object sender, EventArgs e)
        {
            if (ListCarro.SelectedIndex > -1)
            {
                List<Carniceria> carne = ListaCarne.Obtener();



                PrecioTotal.Text = $"Precio * {Cantidad.Value}KG: {(carne[ListCarro.SelectedIndex].PreciosCarne * Cantidad.Value).ToString()}$";
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
                listaClientes[ListClientes.SelectedIndex].VaciarCarro();
                ListClientes.Enabled = true;
                ListClientes.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("No hay ningun cliente seleccionado para calcelar la compra");
            }


        }

        private void BotonVerCarro_Click(object sender, EventArgs e)
        {
            if (ListClientes.SelectedIndex > -1)
            {
                Cliente cliente = listaClientes[ListClientes.SelectedIndex];
                Factura carro = new Factura(cliente);
                carro.Show();
            }
            else
            {
                MessageBox.Show("No selecciono ningun cliente");
            }
        }
    }


}

