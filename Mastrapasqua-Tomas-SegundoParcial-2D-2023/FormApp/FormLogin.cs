using Clases;
using System.Collections.Generic;
using System.Media;


namespace FormApp
{
    public partial class FormLogin : Form
    {
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


          
            Tienda.CargarTienda();

            establecerDatos();
            

            string currentDirectory = Environment.CurrentDirectory;


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
            
            List<Usuario> usuarios = Tienda.ObtenerUsuarios();
            List<Vendedor> vendedores = Tienda.ObtenerVendedores();
            List<Cliente> clientes = Tienda.ObtenerClientes();


            string mail = TextMail.Text;
            string password = TextPassword.Text;

            Usuario usuario = buscarUsuario(usuarios, mail, password); // Busca el usuario mediante el mail y la password



            if (usuario != null)
            {
                /*SoundPlayer sonidoLogin = new SoundPlayer();
                sonidoLogin.SoundLocation = "C:/Users/Tomas Mastra/source/repos/FormApp/Resources";

                sonidoLogin.Play();*/

                if (usuario.Rol == 1)
                {
                    if (vendedores != null)
                    {
                        Vendedor vendedor = buscarVendedor(usuario, vendedores);
                        Heladera formHeladera = new Heladera(vendedor, this);//ver

                        formHeladera.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("no hay vendedores");
                    }

                }
                else
                {

                    if (usuario.Rol == 2)
                    {
                        Cliente cliente = buscarCliente(usuario, clientes);
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
        public Usuario buscarUsuario(List<Usuario> usuario, string mail, string password)
        {
            /*  int index = -1;
              Usuario usuarioNuevo = null;


              foreach (Usuario user in usuario)
              {

                  if (user.Mail == mail && user.Password == password)
                  {
                      // index = i;
                      usuarioNuevo = user;
                      break;

                  }
              }*/

            return usuario.Find(u => u.Mail == mail && u.Password == password);
            


        }

        /// <summary>
        /// Busca el índice del vendedor por usuario.
        /// </summary>
        /// <param name="usuario">Usuario asociado al vendedor.</param>
        /// <param name="vendedor">Lista de vendedores.</param>
        /// <returns>Índice del vendedor si se encuentra, de lo contrario, -1.</returns>
        public Vendedor buscarVendedor(Usuario usuario, List<Vendedor> vendedor)
        {
            return vendedor.Find(v => usuario.Mail == v.Mail && usuario.Password == v.Password);

        }

        /// <summary>
        /// Busca el índice del cliente por usuario.
        /// </summary>
        /// <param name="usuario">Usuario asociado al cliente.</param>
        /// <param name="cliente">Lista de clientes.</param>
        /// <returns>Índice del cliente si se encuentra, de lo contrario, -1.</returns>
        public Cliente buscarCliente(Usuario usuario, List<Cliente> cliente)
        {
            return cliente.Find(c => usuario.Mail == c.Mail && usuario.Password == c.Password);

        }

        /// <summary>
        /// Sucede cuando se hace clic en el botón Cliente y completa los datos en los textBox 
        /// </summary>
        private void Cliente_Click(object sender, EventArgs e)
        {
            List<Cliente> cliente = Tienda.ObtenerClientes();

            TextMail.Text = cliente[0].Mail;
            TextPassword.Text = cliente[0].Password;
        }

        /// <summary>
        /// Sucede cuando se hace clic en el botón Vendedor y completa los datos en los textBox 
        /// </summary>
        private void Vendedor_Click(object sender, EventArgs e)
        {
            List<Vendedor> vendedor = Tienda.ObtenerVendedores();

            TextMail.Text = vendedor[0].Mail;
            TextPassword.Text = vendedor[0].Password;
        }
    }

}
