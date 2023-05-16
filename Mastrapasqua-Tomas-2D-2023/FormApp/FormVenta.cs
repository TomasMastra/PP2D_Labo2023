using Clases;
using System.Security.Cryptography.X509Certificates;

namespace FormApp
{
    public partial class FormVenta : Form
    {


        private Vendedor vendedorCarniceria;
        private List<Carniceria> carne;
        private Cliente cliente;
        private List<Factura> facturas;
        float sumaCarroActual;
        Form formLogin;
        float monto;
        float precioCarro;

        public FormVenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de la clase FormVenta.
        /// </summary>
        /// <param name="carne">Lista de objetos Carniceria</param>
        /// <param name="cliente">Objeto Cliente</param>
        /// <param name="vendedor">Objeto Vendedor</param>
        /// <param name="formLogin">Formulario de inicio de sesión (login)</param>
        public FormVenta(List<Carniceria> carne, Cliente cliente, Vendedor vendedor, Form formLogin) : this()
        {


            this.carne = carne;
            this.cliente = cliente;
            this.formLogin = formLogin;
            this.vendedorCarniceria = vendedor;


        }

        private void FormCliente_Load(object sender, EventArgs e)
        {

            inicializar();
            this.precioCarro = 0;
            this.monto = 0;

        }

        /// <summary>
        /// Inicializa el formulario y carga la lista de objetos Carniceria en el control ListBox
        /// </summary>
        public void inicializar()
        {
            for (int i = 0; i < carne.Count; i++)
            {

                DatosCarne.Items.Add(carne[i].CortesCarne);

            }


        }


        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "Regresar"
        /// Limpia la lista de compras del cliente y muestra el formulario de inicio de sesión
        /// </summary>
        private void botonRegresar_Click(object sender, EventArgs e)
        {
            cliente.ListaCompras.Clear();
            formLogin.Show();
            this.Hide();
        }



        /// <summary>
        /// Evento que se desencadena al hacer clic en el boton "Comprar carro"
        /// Agrega un producto al carro y le muestra al usuario el dinero que le queda
        /// Valida que tenga el dinero suficiente
        /// </summary>
        private void BotonComprar_Click(object sender, EventArgs e)
        {
            int totalPagar;

            if (int.TryParse(TotalPagar.Text, out totalPagar))
            {
                if (monto > 0)
                {
                    if (this.monto >= Convert.ToInt32(totalPagar) && CantidadComprar.Value > 0)
                    {
                        ListaCompras lista = new ListaCompras(carne[DatosCarne.SelectedIndex].CortesCarne, totalPagar, Convert.ToInt32(CantidadComprar.Value));

                        cliente.ListaCompras.Add(lista);
                        monto = monto - totalPagar;
                        TextoMonto.Text = $"Monto disponible: {monto.ToString()}";
                        MessageBox.Show($"Monto disponible: {monto}");
                        TotalComprar.Text = (Convert.ToInt32(TotalPagar.Text) + Convert.ToInt32(TotalComprar.Text)).ToString();

                    }
                    else
                    {
                        MessageBox.Show($"No puede agregar mas, no le alcanza el dinero");
                    }
                }
                else
                {
                    MessageBox.Show($"No agrego el monto maximo a pagar");

                }
            }


        }




        /// <summary>
        /// Evento que se desencadena al seleccionar un elemento en el control ListBox "DatosCarne"
        /// Muestra información detallada sobre el elemento seleccionado
        /// </summary>
        private void DatosCarne_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DatosCarne.Items.Count > 0 && DatosCarne.SelectedIndex > -1 && DatosCarne.SelectedIndex < carne.Count)
            {
                DatosCorteCarne.Text = DatosCarne.Items[DatosCarne.SelectedIndex].ToString();
                Tipo.Text = "Tipo: " + carne[DatosCarne.SelectedIndex].TipoCarne.ToString();
                CantidadDisponible.Text = "Cantidad Disponible: " + carne[DatosCarne.SelectedIndex].CantidadCarne.ToString();
                Precio.Text = "Precio (KG): " + carne[DatosCarne.SelectedIndex].PreciosCarne.ToString();
                CantidadComprar.Value = 0;
                CantidadComprar.Maximum = carne[DatosCarne.SelectedIndex].CantidadCarne; ;


            }
        }

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "Buscar"
        /// Busca y selecciona el siguiente elemento en el control ListBox "DatosCarne" que coincide con el texto de búsqueda
        /// </summary>
        private void Buscar_Click(object sender, EventArgs e)
        {
            string buscar = TextBoxBuscar.Text.ToLower();
            buscarIndiceCarne(0, carne.Count, buscar);

        }

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotonSiguiente"
        /// Busca y selecciona el siguiente elemento en el control ListBox "DatosCarne" que coincide con el texto de búsqueda, a partir de la posición actual
        /// </summary>
        private void BotonSiguiente_Click(object sender, EventArgs e)
        {
            string buscar = TextBoxBuscar.Text.ToLower();
            buscarIndiceCarne(DatosCarne.SelectedIndex + 1, carne.Count, buscar);

        }

        /// <summary>
        /// Busca y selecciona un elemento del listBox desde un indice a otro
        /// </summary>
        public void buscarIndiceCarne(int from, int to, string buscar)
        {
            for (int i = from; i < to; i++)
            {
                string carne = DatosCarne.Items[i].ToString().ToLower();
                if (carne.Contains(buscar))
                {
                    DatosCarne.SelectedIndex = i;
                    break;
                }
            }


        }


        /// <summary>
        /// Evento que se desencadena al cambiar el valor en el control NumericUpDown "CantidadComprar"
        /// Calcula y muestra el total a pagar en función de la cantidad seleccionada y el precio de la carne
        /// </summary>
        private void CantidadComprar_ValueChanged(object sender, EventArgs e)
        {
            if (DatosCarne.SelectedIndex > -1)
            {
                TotalPagar.Text = (Convert.ToInt32(CantidadComprar.Value) * carne[DatosCarne.SelectedIndex].PreciosCarne).ToString();
            }
        }

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotónCarro"
        /// Abre el formulario "FormCarro" para mostrar el carrito de compras del cliente
        /// </summary>
        private void BotonCarro_Click(object sender, EventArgs e)
        {
            if (monto > 0)
            {
                FormCarro formCarro = new FormCarro(cliente);
                formCarro.Show();
            }

        }
        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotonCancelarCompra"
        /// Vacía el carrito de compras del cliente
        /// </summary>
        private void BotonCancelarCompra_Click(object sender, EventArgs e)
        {
            if (cliente.ListaCompras.Count > 0)
            {

                cliente.vaciarCarro();
                TotalPagar.Text = "0";
                TotalComprar.Text = "0";
                DatosCarne.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show($"No hay nada en el carro de {cliente.Nombre}");
            }
        }

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotonUsuario"
        /// Muestra la información del cliente en un mensaje de MessageBox
        /// </summary>
        private void BotonUsuario_Click(object sender, EventArgs e)
        {
            if (monto > 0)
            {
                MessageBox.Show(cliente.Mostrar());
            }
        }

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotonIngresarMonto"
        /// Verifica y asigna el monto máximo de pago ingresado por el cliente
        /// </summary>
        private void BotonIngresarMonto_Click(object sender, EventArgs e)
        {

            float monto;
            if (float.TryParse(TextMontoMaximo.Text, out monto) && monto > 100)
            {
                this.monto = monto;
                TextoMonto.Text = $"Monto disponible: {monto.ToString()}";
                TextoMonto.ForeColor = Color.Red;
                Activar();
            }
            else
            {
                MessageBox.Show("No es un valida esa cantidad ingresada!!!");

            }
        }

        /// <summary>
        /// Activa los controles y funcionalidades una vez que se ingresa el monto máximo de pago
        /// </summary>
        public void Activar()
        {
            BotonCarro.Enabled = true;
            BotonComprar.Enabled = true;
            BotonUsuario.Enabled = true;
            TextBoxBuscar.Enabled = true;
            Buscar.Enabled = true;
            BotonSiguiente.Enabled = true;
            DatosCarne.Enabled = true;
            GrupoCarne.Enabled = true;
            BotonAgregarCarro.Enabled = true;
            BotonBorrar.Enabled = true;
            Recargo.Enabled = true;


        }

        /// <summary>
        /// Crea una factura de compra para las compras realizadas por el cliente
        /// Si se selecciona el recargo, crea una factura con recargo
        /// </summary>
        /// <param name="total">El total a pagar</param>
        public void crearFacturasCompra(float total)
        {

            if (Recargo.Checked != true)
            {
                Factura factura = vendedorCarniceria.crearFacturas(total, cliente.Nombre, false);
            }
            else
            {

                Factura factura = vendedorCarniceria.crearFacturas(total, cliente.Nombre, true);

            }
        }

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotónComprar"
        /// Realiza la compra de los productos en el carrito del cliente
        /// Actualiza la cantidad de carne disponible y crea una factura de compra
        /// </summary>
        private void BotonComprar_Click_1(object sender, EventArgs e)
        {

            float total = 0;
            if (cliente.ListaCompras.Count > 0)
            {
                for (int i = 0; i < cliente.ListaCompras.Count; i++)
                {
                    total = cliente.ObtenerPrecioTotal();

                    for (int j = 0; j < carne.Count; j++)
                    {
                        if (cliente.ListaCompras[i].Producto == carne[j].CortesCarne)
                        {
                            if (carne[j].CantidadCarne >= cliente.ListaCompras[i].CantidadComprada)
                            {
                                carne[j].CantidadCarne = carne[j].CantidadCarne - cliente.ListaCompras[i].CantidadComprada;
                                cliente.ListaCompras[i].Comprado = true;
                            }
                            else
                            {
                                MessageBox.Show($"La bolsa con {carne[j].CortesCarne} no se pudo comprar debido a que no hay stock ");
                            }
                        }
                    }
                }

                crearFacturasCompra(total);
                DatosCarne.SelectedIndex = -1;
                FormCarro formCarro = new FormCarro(vendedorCarniceria.ListaFacturas[vendedorCarniceria.ListaFacturas.Count - 1]);
                formCarro.Show();
                cliente.ListaCompras.Clear();
            }
            else
            {
                MessageBox.Show("No hay nada en el carro para poder comprar");
            }




        }

        private void TotalPagar_Click(object sender, EventArgs e)
        {

        }
    }
}
