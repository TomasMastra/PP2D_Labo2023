﻿using Clases;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FormApp
{
    public delegate void MiDelegado(string mensaje);

    public partial class FormVenta : Form
    {
        //Cosas a mejorar /o cambiar
        //al momento de ingresar el monto poner un limite
        //validar que cuando ingrese float no se bugee
        //sacar texto de abajo del boton de comprar


        private Cliente cliente;
        float sumaCarroActual;
        Form formLogin;
        float monto;
        float precioCarro;
        public delegate void MiDelegado(string mensaje);


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
        public FormVenta(Cliente cliente, Form formLogin) : this()
        {

            this.cliente = cliente;
            this.formLogin = formLogin;

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
            List<Carniceria> carne = Tienda.ObtenerCarne();
            DatosCarne.Items.Clear();

            foreach (Carniceria corte in carne)
            {
                DatosCarne.Items.Add(corte.CortesCarne);
            }

            Tipo.Text = "";
            CantidadDisponible.Text = "";
            Precio.Text = "";
            CantidadComprar.Text = "";
            TotalComprar.Text = "0";
            TotalPagar.Text = "0";

        }

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "Regresar"
        /// Limpia la lista de compras del cliente y muestra el formulario de inicio de sesión
        /// </summary>
        private void botonRegresar_Click(object sender, EventArgs e)
        {
            //cliente.ListaCompras.Clear();
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
            bool existe = false;

            int idCarro = Tienda.ObtenerUltimoIdCarro() + 1;
            int idCliente = cliente.Id;
            int idProducto;
            int cantidad;


            if (int.TryParse(TotalPagar.Text, out totalPagar))
            {
                if (monto > 0)
                {
                    if (DatosCarne.SelectedIndex > -1)
                    {
                        List<Carniceria> carne = Tienda.ObtenerCarne();

                        if (this.monto >= Convert.ToInt32(totalPagar) && CantidadComprar.Value > 0)
                        {

                            ListaCompras carro = new ListaCompras(idCarro, cliente.Id, carne[DatosCarne.SelectedIndex].IdCarne, Convert.ToInt32(CantidadComprar.Value));
                            existe = cliente.AgregarCarro(carro);
                            Carniceria producto = Tienda.ObtenerCorteCarne(carro.IdProducto);



                            monto = monto - totalPagar;
                            TextoMonto.Text = $"Monto disponible: {monto.ToString()}";
                            TotalComprar.Text = (Convert.ToInt32(TotalPagar.Text) + Convert.ToInt32(TotalComprar.Text)).ToString();
                            DatosCarne.SelectedIndex = -1;
                            Tipo.Text = "";
                            CantidadDisponible.Text = "";
                            Precio.Text = "";
                            CantidadComprar.Text = "";

                        }
                        else
                        {
                            MessageBox.Show($"No puede agregar mas, no le alcanza el dinero / no selecciono la cantidad que desea comprar");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No selecciono un corte de carne");

                    }
                }
                else
                {
                    MessageBox.Show($"No agrego el monto maximo a pagar \n");
                }
            }



        }

        /// <summary>
        /// Evento que se desencadena al seleccionar un elemento en el control ListBox "DatosCarne"
        /// Muestra información detallada sobre el elemento seleccionado
        /// </summary>
        private void DatosCarne_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Carniceria> carne = Tienda.ObtenerCarne();

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
            buscarIndiceCarne(0, Tienda.ObtenerCarne().Count, buscar);

        }




        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotonSiguiente"
        /// Busca y selecciona el siguiente elemento en el control ListBox "DatosCarne" que coincide con el texto de búsqueda, a partir de la posición actual
        /// </summary>
        private void BotonSiguiente_Click(object sender, EventArgs e)
        {
            string buscar = TextBoxBuscar.Text.ToLower();
            buscarIndiceCarne(DatosCarne.SelectedIndex + 1, Tienda.ObtenerCarne().Count, buscar);

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
            List<Carniceria> carne = Tienda.ObtenerCarne();
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

            Factura formCarro = new Factura(cliente);
            formCarro.Show();

        }


        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotonCancelarCompra"
        /// Vacía el carrito de compras del cliente
        /// </summary>
        private void BotonCancelarCompra_Click(object sender, EventArgs e)
        {
            if (cliente.ListaCompras.Count > 0)
            {

                cliente.VaciarCarro();
                TotalPagar.Text = "0";
                TotalComprar.Text = "0";
                DatosCarne.SelectedIndex = -1;
                cliente.VaciarCarro();


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

        ////////////////////////////////////
        ///

        /// <summary>
        /// Evento que se desencadena al hacer clic en el botón "BotonIngresarMonto"
        /// Verifica y asigna el monto máximo de pago ingresado por el cliente
        /// </summary>
        private void BotonIngresarMonto_Click(object sender, EventArgs e)
        {
            float monto;
            if (float.TryParse(TextMontoMaximo.Text, out monto) && monto > 100)
            {
                if (monto > 100 && monto < 100000)
                {
                    this.monto = monto;
                    cliente.Dinero = monto;
                    TextoMonto.Text = $"Monto disponible: {monto.ToString()}";
                    TextoMonto.ForeColor = Color.Red;
                    Activar();
                }
                else
                {
                    MessageBox.Show("Debe ingresar una cantidad valida de dinero, SOLO aceptamos entre 100 a 100.000");


                }
            }
            else
            {
                MessageBox.Show("No PUEDE ingrese letras o simbolos!!!");

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
        /// Evento que se desencadena al hacer clic en el botón "BotónComprar"
        /// Realiza la compra de los productos en el carrito del cliente
        /// Actualiza la cantidad de carne disponible y crea una factura de compra
        /// </summary>
        private void BotonComprar_Click_1(object sender, EventArgs e)//modificar
        {

            List<Carniceria> carne = Tienda.ObtenerCarne();
            List<Clases.Factura> facturas = Tienda.ObtenerFacturas();
            string noSeCompro;


            if (cliente.ListaCompras.Count > 0 )
            {
                noSeCompro = Tienda.Comprar(cliente, Recargo.Checked);

                if (noSeCompro.Length != 0)
                {
                    MessageBox.Show($"No se pudo comprar:\n{noSeCompro}");
                }
                else
                {
                    MessageBox.Show("La compra se realizo con exito");

                }

                if (Convert.ToInt32(TotalComprar.Text) > 0)
                {

                    int lastIndexOf = facturas.Count - 1;

                    if( lastIndexOf > -1 ) {
                        Factura formCarro = new Factura(facturas[lastIndexOf]);
                        formCarro.Show();
                    }
                    else
                    {
                        MessageBox.Show("HUBO un error, No se pudo mostrar la factura!!!");
                    }
                    


                   
                }



            }
            else
            {
                MessageBox.Show("No hay nada en el carro para poder comprar");
            }




        }

      
    }
}



