using Clases;

namespace FormApp
{
    public partial class FormAlta : Form
    {
        int estado;
        Form formHeladera;

        /// <summary>
        /// Constructor de la clase FormLogin
        /// Ingresa cuando se va a agregar un nuevo corte
        /// </summary>
        public FormAlta(Heladera heladera)//sacar el form de aca
        {

            InitializeComponent();
            this.estado = 1;
            this.formHeladera = heladera;


        }


        /// <summary>
        /// Constructor de la clase FormLogin
        /// Ingresa cuando se va a modificar un corte y modificar es true
        /// </summary>
        public FormAlta(int estado, Heladera heladera)
        {
            InitializeComponent();
            ListaCortesCarne.Visible = true;
            cargarComboBox();
            this.formHeladera = heladera;




            if (estado == 2)
            {
                this.estado = 2;
                BotonAgregar.ForeColor = Color.Yellow;
                BotonAgregar.Text = "modificar";
                this.Name = "Modificar el corte";



            }
            else
            {
                this.estado = 3;
                TextModificar.ForeColor = Color.Red;
                BotonAgregar.Text = "Eliminar";
                this.Name = "Eliminar el corte";

                GroupBoxDatos.Enabled = false;


            }



        }


        /// <summary>
        /// Inicializa algunos datos 
        /// </summary>
        private void FormAlta_Load(object sender, EventArgs e)
        {
            cargarTipos();

        }



        /// <summary>
        /// Carga el combobox con los datos. Esto sucede cuando se va a modificar y 
        /// el vendedor ingreso esModificar en true
        /// </summary>
        public void cargarComboBox()
        {
            List<Carniceria> carne = Tienda.ObtenerCarne();

            foreach (Carniceria corte in carne)
            {
                ListaCortesCarne.Items.Add(corte.CortesCarne);

            }

        }

        /// <summary>
        /// Carga los tipos en un combobox para que el vendedor pueda elegir cual asignarle al corte de carne
        /// </summary>
        public void cargarTipos()
        {
            List<string> tiposOrdenados = Enum.GetNames(typeof(Tipo)).OrderBy(x => x).ToList();

            foreach (string tipo in tiposOrdenados)
            {
                ListaTipos.Items.Add(tipo);
            }

        }

        /// <summary>
        /// Al momento de la modificacion cuando el vendedor elige el corte se completan los campos con sus respectivos datos 
        /// </summary>
        private void ListaCortesCarne_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Carniceria> listaCarne = Tienda.ObtenerCarne();
            Carniceria carne = listaCarne[ListaCortesCarne.SelectedIndex];

            TextBoxCorte.Text = carne.CortesCarne;
            Precio.Value = Convert.ToInt32(carne.PreciosCarne);
            Cantidad.Value = Convert.ToInt32(carne.CantidadCarne);
            ListaTipos.SelectedIndex = ListaTipos.FindStringExact(ListaCortesCarne.SelectedItem.ToString());

        }

        /// <summary>
        /// Pregunta si deasea realizar los cambios y guardar
        /// </summary>
        /// <returns></returns>
        public bool ConfirmarGuardar()
        {
            DialogResult resultado = MessageBox.Show("¿Desea guardar los cambios?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return resultado == DialogResult.Yes;
        }


        /// <summary>
        /// Dependiendo el valor de esModificar realiza acciones diferentes como agregar o modificar
        /// </summary>
        private void BotonAgregar_Click(object sender, EventArgs e)
        {



            if (GroupBoxDatos.Enabled == true)
            {
                if (Cantidad.Value > 0 && TextBoxCorte.Text != string.Empty && Precio.Value > 0 && ListaTipos.SelectedIndex > -1)
                {
                    string corteCarne = TextBoxCorte.Text;
                    int cantidad = Convert.ToInt32(Cantidad.Value);
                    int precio = Convert.ToInt32(Precio.Value);
                    Tipo tipo = ((Tipo)Enum.Parse(typeof(Tipo), ListaTipos.Items[ListaTipos.SelectedIndex].ToString()));

                    if (estado == 1 && ConfirmarGuardar() == true)
                    {

                        int id = Tienda.ObtenerId() + 1;

                        Carniceria carne = new Carniceria(id, corteCarne, precio, cantidad, tipo);
                        Tienda.AgregarCarne(carne);
                        CarniceriaDAO.AgregarCarne(carne);

                        this.Hide();

                    }
                    else
                    if (ConfirmarGuardar() == true)
                    {
                        if (ListaCortesCarne.SelectedIndex > -1)
                        {
                            List<Carniceria> carne = Tienda.ObtenerCarne();
                            Carniceria carneModificar = carne[ListaCortesCarne.SelectedIndex];

                            carneModificar.CantidadCarne = cantidad;
                            carneModificar.CortesCarne = corteCarne;
                            carneModificar.PreciosCarne = precio;
                            carneModificar.TipoCarne = tipo;

                            carneModificar.modificar(carneModificar);
                            CarniceriaDAO.ModificarCarne(carneModificar);

                            this.Hide();
                        }

                    }
                }
                else
                {
                    TextError.ForeColor = Color.Red;
                }


            }
            else
            {
                if (ListaCortesCarne.SelectedIndex > -1)
                {
                    if (ConfirmarGuardar() == true)
                    {
                        List<Carniceria> carne = Tienda.ObtenerCarne();
                        Carniceria carneEliminar = carne[ListaCortesCarne.SelectedIndex];
                        CarniceriaDAO.EliminarCarne(carneEliminar.IdCarne);

                        MessageBox.Show(carneEliminar.CortesCarne);

                        this.Hide();
                    }
                }
                else
                {
                    TextError.Text = "No selecciono el corte a eliminar";
                    TextError.ForeColor = Color.Red;
                }
            }

        }

        /// <summary>
        /// Boton para regresar al menu
        /// </summary>
        private void BotonRegresar_Click(object sender, EventArgs e)
        {
            // FormLogin formLogin = new FormLogin();
            formHeladera.Show();
            this.Hide();

        }

       



        
    }
}







