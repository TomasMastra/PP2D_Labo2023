using Clases;




namespace FormApp
{
    public partial class FormVenta : Form
    {

        //Vendedor vendedorCariceria;

        private Vendedor vendedorCarniceria;
        private List<Carniceria> carne;
        private Cliente cliente;
        float sumaCarroActual;
        Form formLogin;
        float monto;
        float precioCarro;

        public FormVenta()
        {
            InitializeComponent();
        }

        public FormVenta(List<Carniceria> carne, Cliente cliente, Form formLogin) : this()
        {


            this.carne = carne;
            this.cliente = cliente;
            this.formLogin = formLogin;




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
                    if (this.monto >= Convert.ToInt32(totalPagar) && CantidadComprar.Value>0)
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
                FormCarro formCarro = new FormCarro(cliente, true);
                formCarro.Show();
            }

        }

        private void Facturas_Click(object sender, EventArgs e)
        {
            if (monto > 0)
            {
                FormCarro formCarro = new FormCarro(cliente);
                formCarro.Show();
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
            }
            else
            {
                MessageBox.Show("No es un valida esa cantidad ingresada!!!");

            }
        }


    }
}
