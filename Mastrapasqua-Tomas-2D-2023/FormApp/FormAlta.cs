using Clases;

namespace FormApp
{
    public partial class FormAlta : Form
    {
        bool modificar;
        Form formHeladera;

        /// <summary>
        /// Constructor de la clase FormLogin
        /// Ingresa cuando se va a agregar un nuevo corte
        /// </summary>
        public FormAlta(Heladera heladera)//sacar el form de aca
        {

            InitializeComponent();
            this.modificar = false;
            this.formHeladera = heladera;


        }


        /// <summary>
        /// Constructor de la clase FormLogin
        /// Ingresa cuando se va a modificar un corte y modificar es true
        /// </summary>
        public FormAlta(bool modificar, Heladera heladera)
        {
            InitializeComponent();
            this.modificar = modificar;
           // this.carne = carne;
            ListaCortesCarne.Visible = true;
            cargarComboBox();
            BotonAgregar.ForeColor = Color.Yellow;
            BotonAgregar.Text = "modificar";
            TextModificar.ForeColor = Color.Yellow;
            this.formHeladera = heladera;
            this.Name = "Modificar el corte";


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
            List<Carniceria> carne = ListaCarne.Obtener();
            foreach(Carniceria corte in carne) 
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
            foreach(string tipo in tiposOrdenados)
            {
                ListaTipos.Items.Add(tipo);
            }

        }

        /// <summary>
        /// Al momento de la modificacion cuando el vendedor elige el corte se completan los campos con sus respectivos datos 
        /// </summary>
        private void ListaCortesCarne_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Carniceria> carne = ListaCarne.Obtener();
            TextBoxCorte.Text = carne[ListaCortesCarne.SelectedIndex].CortesCarne;
            Precio.Value = Convert.ToInt32(carne[ListaCortesCarne.SelectedIndex].PreciosCarne);
            Cantidad.Value = Convert.ToInt32(carne[ListaCortesCarne.SelectedIndex].CantidadCarne);
            ListaTipos.SelectedIndex = ListaTipos.FindStringExact(ListaCortesCarne.SelectedItem.ToString());

        }


        /// <summary>
        /// Dependiendo el valor de esModificar realiza acciones diferentes como agregar o modificar
        /// </summary>
        private void BotonAgregar_Click(object sender, EventArgs e)
        {

            //MessageBox.Show($"{carne.CortesCarne[1]}");
            if (modificar == false)
            {
                if (TextBoxCorte.Text != string.Empty && Precio.Value > 0 && ListaTipos.SelectedIndex > -1)
                {
                    
                    Carniceria carne = new Carniceria(TextBoxCorte.Text, Convert.ToInt32(Precio.Value), Convert.ToInt32(Cantidad.Value), ((Tipo)Enum.Parse(typeof(Tipo), ListaTipos.Items[ListaTipos.SelectedIndex].ToString())));
                    ListaCarne.Agregar(carne);
                    //this.carne.Carne.Add(carne);
                    //this.heladera.

                   // Heladera formHeladera = new Heladera();
                    formHeladera.Show();
                    this.Hide();
                }
                else
                {
                    TextError.ForeColor = Color.Red;
                }
            }
            else
            {

                if (ListaCortesCarne.SelectedIndex > -1 && TextBoxCorte.Text != string.Empty && Precio.Value > 0 && ListaTipos.SelectedIndex > -1)
                {
                    //carne.Carne[ListaCortesCarne.SelectedIndex].modificar(TextBoxCorte.Text, (Tipo)Enum.Parse(typeof(Tipo), ListaTipos.Items[ListaTipos.SelectedIndex].ToString()), Convert.ToInt32(Cantidad.Value), Convert.ToInt32(Precio.Value));

                    List<Carniceria> carne = ListaCarne.Obtener();

                    Carniceria carneModificar = carne[ListaCortesCarne.SelectedIndex];

                    carneModificar.modificar(TextBoxCorte.Text, ((Tipo)Enum.Parse(typeof(Tipo), ListaTipos.Items[ListaTipos.SelectedIndex].ToString())), Convert.ToInt32(Cantidad.Value), Convert.ToInt32(Precio.Value));
                   // Heladera formHeladera = new Heladera();
                    formHeladera.Show();
                    this.Hide();
                }
                else
                {
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



    

    
