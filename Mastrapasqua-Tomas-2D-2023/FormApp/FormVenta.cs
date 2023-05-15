using Clases;
using System.Security.Cryptography.X509Certificates;

namespace FormApp
{
    public partial class FormVenta : Form
    {

        //Vendedor vendedorCariceria;

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

        public void inicializar()
        {
            for (int i = 0; i < carne.Count; i++)
            {

                DatosCarne.Items.Add(carne[i].CortesCarne);

            }


        }





        private void botonRegresar_Click(object sender, EventArgs e)
        {
            cliente.ListaCompras.Clear();
            formLogin.Show();
            this.Hide();
        }




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

                //CantidadDisponible.Text = "Cantidad disponible: " + carne.CantidadCarne[DatosCarne.SelectedIndex].ToString();

            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            string buscar = TextBoxBuscar.Text.ToLower();
            buscarIndiceCarne(0, carne.Count, buscar);

        }

        private void BotonSiguiente_Click(object sender, EventArgs e)
        {
            string buscar = TextBoxBuscar.Text.ToLower();
            buscarIndiceCarne(DatosCarne.SelectedIndex + 1, carne.Count, buscar);

        }

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



        private void CantidadComprar_ValueChanged(object sender, EventArgs e)
        {
            TotalPagar.Text = (Convert.ToInt32(CantidadComprar.Value) * carne[DatosCarne.SelectedIndex].PreciosCarne).ToString();
            //CalcularTotal((Convert.ToInt32(CantidadComprar.Value) * carne[DatosCarne.SelectedIndex].PreciosCarne).ToString());
        }

        private void BotonCarro_Click(object sender, EventArgs e)
        {
            if (monto > 0)
            {
                FormCarro formCarro = new FormCarro(cliente);
                formCarro.Show();
            }

        }

        private void BotonCancelarCompra_Click(object sender, EventArgs e)
        {
            if (cliente.ListaCompras.Count > 0)
            {
                /*FormCarro formCarro = new FormCarro(cliente);
                formCarro.Show();*/

                cliente.vaciarCarro();
            }
            else
            {
                MessageBox.Show($"No hay nada en el carro de {cliente.Nombre}");
            }
        }

        private void BotonUsuario_Click(object sender, EventArgs e)
        {
            if (monto > 0)
            {
                MessageBox.Show(cliente.Mostrar());
            }
        }

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

        public void crearFacturasCompra(float total)
        {

            if (Recargo.Checked != true)
            {
                Factura factura = vendedorCarniceria.crearFacturas(total, cliente.Nombre, false);
                //vendedorCarniceria.ListaFacturas.Add(f);
            }
            else
            {

                Factura factura = vendedorCarniceria.crearFacturas(total, cliente.Nombre, true);
                //vendedorCarniceria.ListaFacturas.Add(f);

            }
        }

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
                            }
                            else
                            {
                                MessageBox.Show($"La bolsa con {carne[j].CortesCarne} no se pudo comprar debido a que no hay stock // {carne[j].CantidadCarne}");
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
    }
}
