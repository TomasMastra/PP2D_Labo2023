using Clases;
using System.Media;


namespace FormApp
{
    public partial class FormLogin : Form
    {

        List<Vendedor> vendedorCarniceria = new List<Vendedor>();//Vendedor que entra a el form de heladera
        List<Cliente> clienteCarniceria = new List<Cliente>();//Cliente que entra al form de Venta y la lista al de heladera
        List<Usuario> usuario = new List<Usuario>();

        /// <summary>
        /// Constructor de la clase FormLogin
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();

        }


        /// <summary>
        /// Se ejecuta al cargar el formulario FormLogin, harcodea algunos usuarios e inicializa algunas cosas
        /// </summary>
        private void FormLogin_Load(object sender, EventArgs e)
        {


            this.usuario = harcodearUsuarios();//lista de usuarios a agregar
            harcodearCarniceria();

            this.clienteCarniceria.Add(harcodearCliente(usuario[1]));
            this.clienteCarniceria.Add(harcodearCliente(usuario[2]));

            this.vendedorCarniceria.Add(harcodearVendedor(usuario[0]));
            this.vendedorCarniceria.Add(harcodearVendedor(usuario[3]));

            establecerDatos();

            List<Carniceria> listaCortes = ListaCarne.Obtener();

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;



        }




        public List<Usuario> harcodearUsuarios()
        {
            Usuario usuario1 = new Usuario(1, 20, "Tomas Mastrapasqua", "tomas@gmail.com", "12345", 1);
            Usuario usuario2 = new Usuario(2, 34, "Mariano Martinez", "marianom@gmail.com", "12345", 0);
            Usuario usuario3 = new Usuario(3, 89, "Osvaldo Houston", "osvaldo@outlook.com", "12345", 0);
            Usuario usuario4 = new Usuario(3, 89, "Matias Perez", "matias@outlook.com", "1234567890", 1);


            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios.Add(usuario1);
            listaUsuarios.Add(usuario2);
            listaUsuarios.Add(usuario3);
            listaUsuarios.Add(usuario4);

            return listaUsuarios;
        }

        /// <summary>
        /// Genera una lista de objetos de tipo Carniceria harcodeados
        /// </summary>
        /// <returns>Lista de objetos Carniceria harcodeados.</returns>
        public List<Carniceria> harcodearCarniceria()
        {
            List<string> corteCarne = new List<string> { "Asado", "Vacio", "Bondiola", "Chorizo", "Pollo", "Huevos x 30", "Chimichurri", "Huevo de pavo x 7", "Bife de chorizo", "Matambre", "Morcilla", "Salchicha", "Pechuga de pollo", "Hígado de ternera" };
            List<int> precios = new List<int> { 3000, 2000, 3000, 1000, 900, 1700, 300, 1700, 2500, 1500, 1200, 800, 1100, 900 };
            List<int> cantidad = new List<int> { 2, 2, 3, 4, 0, 5, 9, 7, 3, 2, 4, 6, 0, 1 };
            List<Tipo> tipo = new List<Tipo> { Tipo.Vaca, Tipo.Vaca, Tipo.Cerdo, Tipo.Cerdo, Tipo.Gallina, Tipo.Gallina, Tipo.Condimento, Tipo.Pavo, Tipo.Vaca, Tipo.Vaca, Tipo.Cerdo, Tipo.Cerdo, Tipo.Gallina, Tipo.Vaca };

            for (int i = 0; i < corteCarne.Count; i++)
            {
                Carniceria carne = new Carniceria(corteCarne[i], precios[i], cantidad[i], tipo[i]);
                ListaCarne.Agregar(carne);
            }

            return ListaCarne.Obtener();

        }

        /// <summary>
        /// Genera un objeto de tipo Vendedor con datos harcodeados.
        /// </summary>
        /// <param name="usuario">Usuario asociado al vendedor.</param>
        /// <returns>Objeto Vendedor con datos harcodeados.</returns>
        public Vendedor harcodearVendedor(Usuario usuario)
        {


            Vendedor vendedor = new Vendedor(usuario, 200, 90000);

            return vendedor;
        }

        /// <summary>
        /// Genera un objeto de tipo Cliente con datos harcodeados.
        /// </summary>
        /// <param name="usuario">Usuario asociado al cliente.</param>
        /// <returns>Objeto Cliente con datos harcodeados.</returns>
        public Cliente harcodearCliente(Usuario usuario)
        {

            List<ListaCompras> listaCompras = new List<ListaCompras>();
            List<Clases.Factura> facturas = new List<Clases.Factura>();

            ListaCompras listaProductos = new ListaCompras();

            Cliente cliente = new Cliente(usuario, 20000, 2, listaCompras);


            return cliente;
        }

        /// <summary>
        /// Establece los datos del formulario
        /// </summary>
        public void establecerDatos()
        {
            TextMail.Text = "";
            TextPassword.Text = "";

        }


        /// <summary>
        /// Evento que se dispara al hacer clic en el botón de inicio de sesión
        /// Dependiendo del tipo de usuario se ingresa a un form o a otro
        /// </summary>
        private void BotonLogin_Click(object sender, EventArgs e)
        {

            /* int indexUserMail;
             int indexUserPassword;*/

            /*

            indexUserMail = buscarMail(usuario, TextMail.Text.ToString());
            indexUserPassword = buscarPassword(usuario, TextPassword.Text.ToString());//hacer que retorne un usuario y no el index*/

            string mail = TextMail.Text;
            string password = TextPassword.Text;

            Usuario usuario = buscarUsuario(this.usuario, mail, password);


            if (usuario != null)
            {
                /*SoundPlayer sonidoLogin = new SoundPlayer();
                sonidoLogin.SoundLocation = "C:/Users/Tomas Mastra/source/repos/FormApp/Resources";

                sonidoLogin.Play();*/

                if (usuario.Rol == 1)
                {
                    Vendedor vendedor = buscarVendedor(usuario, vendedorCarniceria);
                    Heladera formHeladera = new Heladera(vendedor, this, clienteCarniceria);//ver

                    formHeladera.Show();
                    this.Hide();


                }
                else
                {

                    if (usuario.Rol == 0)
                    {
                        Cliente cliente = buscarCliente(usuario, clienteCarniceria);
                        FormVenta formVenta = new FormVenta(cliente, this);//ver

                        formVenta.Show();
                        this.Hide();

                    }




                }
            }
            else
            {
                TextError.ForeColor = Color.Red;
                /*SoundPlayer sonidoError = new SoundPlayer();
                sonidoError.SoundLocation = "C:/Users/Tomas Mastra/source/repos/FormApp/Resources/Error.wav";
                sonidoError.Play();*/


            }

        }

        /// <summary>
        /// Busca el índice del usuario por correo electrónico
        /// </summary>
        /// <param name="usuario">Lista de usuarios.</param>
        /// <param name="mail">Correo electrónico a buscar.</param>
        /// <returns>Índice del usuario si se encuentra, de lo contrario, -1 (No se encontró nada)</returns>
        public Usuario buscarUsuario(List<Usuario> usuario, string mail, string password)//static
        {
            int index = -1;
            Usuario usuarioNuevo = null;


            foreach (Usuario user in usuario)
            {

                if (user.Mail == mail && user.Password == password)
                {
                    // index = i;
                    usuarioNuevo = user;
                    break;

                }
            }


            return usuarioNuevo;


        }

        /// <summary>
        /// Busca el índice del usuario por contraseña
        /// </summary>
        /// <param name="usuario">Lista de usuarios</param>
        /// <param name="password">Contraseña a buscar</param>
        /// <returns>Índice del usuario si se encuentra, de lo contrario, -1</returns>
      /*  public int buscarPassword(List<Usuario> usuario, string password)//borrar
        {
            int index = -1;
            for (int i = 0; i < usuario.Count; i++)
            {

                if (usuario[i].Password == password)
                {
                    index = i;

                    break;

                }
            }


            return index;


        }


        public int buscarUsuario(Usuario usuario, List<Vendedor> vendedor)
        {
            int index = -1;

            for (int i = 0; i < vendedor.Count; i++)
            {

                for (int j = 0; j < this.usuario.Count; j++)
                {

                    if (usuario.Mail == vendedor[i].Mail && usuario.Password == vendedor[i].Password)
                    {
                        index = i;
                    }
                }
            }

            return index;
        }*/

        /// <summary>
        /// Busca el índice del vendedor por usuario.
        /// </summary>
        /// <param name="usuario">Usuario asociado al vendedor.</param>
        /// <param name="vendedor">Lista de vendedores.</param>
        /// <returns>Índice del vendedor si se encuentra, de lo contrario, -1.</returns>
        public Vendedor buscarVendedor(Usuario usuario, List<Vendedor> vendedor)
        {
            int index = -1;
            Vendedor auxVendedor = null;

            foreach (Vendedor v in vendedor)
            {

                if (usuario.Mail == v.Mail && usuario.Password == v.Password)
                {
                    // index = i;
                    auxVendedor = v;
                }
            }

            return auxVendedor;
        }

        /// <summary>
        /// Busca el índice del cliente por usuario.
        /// </summary>
        /// <param name="usuario">Usuario asociado al cliente.</param>
        /// <param name="cliente">Lista de clientes.</param>
        /// <returns>Índice del cliente si se encuentra, de lo contrario, -1.</returns>
        public Cliente buscarCliente(Usuario usuario, List<Cliente> cliente)
        {
            int index = -1;
            Cliente auxCliente = null;

            foreach (Cliente c in cliente)
            {

                if (usuario.Mail == c.Mail && usuario.Password == c.Password)
                {
                    //index = i;
                    auxCliente = c;
                }


            }
            return auxCliente;
        }

        /// <summary>
        /// Sucede cuando se hace clic en el botón Cliente y completa los datos en los textBox 
        /// </summary>
        private void Cliente_Click(object sender, EventArgs e)
        {
            TextMail.Text = usuario[1].Mail;
            TextPassword.Text = usuario[1].Password;
        }

        /// <summary>
        /// Sucede cuando se hace clic en el botón Vendedor y completa los datos en los textBox 
        /// </summary>
        private void Vendedor_Click(object sender, EventArgs e)
        {
            TextMail.Text = usuario[0].Mail;
            TextPassword.Text = usuario[0].Password;
        }
    }

}
