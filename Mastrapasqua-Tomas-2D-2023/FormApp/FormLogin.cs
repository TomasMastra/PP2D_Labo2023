using Clases;

namespace FormApp
{
    public partial class FormLogin : Form
    {

        List<Vendedor> vendedorCarniceria = new List<Vendedor>();
        List<Cliente> clienteCarniceria = new List<Cliente>();
        List<Carniceria> carne = new List<Carniceria>();
        List<Usuario> usuario = new List<Usuario>();
        public FormLogin() /*  */
        {
            InitializeComponent();


        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.usuario = harcodearUsuarios();
            this.carne = harcodearCarniceria();

            this.clienteCarniceria.Add(harcodearCliente(usuario[1]));
            this.clienteCarniceria.Add(harcodearCliente(usuario[2]));

            this.vendedorCarniceria.Add(harcodearVendedor(usuario[0]));
            this.vendedorCarniceria.Add(harcodearVendedor(usuario[3]));


            establecerDatos();


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
        public List<Carniceria> harcodearCarniceria()
        {
            List<string> corteCarne = new List<string> { "Asado", "Vacio", "Bondiola", "Chorizo", "Pollo", "Huevos x 30", "Chimichurri", "Huevo de pavo x 6" };
            List<int> precios = new List<int> { 3000, 2000, 3000, 1000, 900, 1700, 300, 1700 };
            List<int> cantidad = new List<int> { 2, 2, 3, 4, 0, 5, 9, 7 };
            List<Tipo> tipo = new List<Tipo> { Tipo.Vaca, Tipo.Vaca, Tipo.Cerdo, Tipo.Cerdo, Tipo.Gallina, Tipo.Gallina, Tipo.Condimento, Tipo.Pavo };


            List<Carniceria> listaCarne = new List<Carniceria>();
            for (int i = 0; i < corteCarne.Count; i++)
            {
                Carniceria carne = new Carniceria(corteCarne[i], precios[i], cantidad[i], tipo[i]);
                listaCarne.Add(carne);

            }


            return listaCarne;

        }

        public Vendedor harcodearVendedor(Usuario usuario)
        {

            Vendedor vendedor = new Vendedor(usuario, carne, 2, 2);

            return vendedor;
        }

        public Cliente harcodearCliente(Usuario usuario)
        {

            List<string> producto = new List<string> { "Asado", "Vacio", "Chimichurri" };
            List<int> precios = new List<int> { 3000, 2000, 1200 };
            List<int> cantidad = new List<int> { 1, 1, 4 };


            List<ListaCompras> listaCompras = new List<ListaCompras>();
            List<Factura> facturas = new List<Factura>();

            for (int i = 0; i < producto.Count; i++)
            {
                ListaCompras listaProductos = new ListaCompras(producto[i], precios[i], cantidad[i]);
                Factura listaFacturas = new Factura(i, 20000, usuario.Mail);

                listaCompras.Add(listaProductos);
                facturas.Add(listaFacturas);


            }
            Cliente cliente = new Cliente(usuario, 20000, 2, listaCompras, facturas);


            return cliente;
        }

        public void establecerDatos()
        {
            foreach (Usuario user in usuario)
            {
                comboBox1.Items.Add(user.Mail.ToString());
            }

            TextMail.Text = "";
            TextPassword.Text = "";


        }

        

        private void BotonLogin_Click(object sender, EventArgs e)
        {

            int indexUserMail;
            int indexUserPassword;


            indexUserMail = buscarMail(usuario, TextMail.Text.ToString());
            indexUserPassword = buscarPassword(usuario, TextPassword.Text.ToString());





            if (indexUserMail >= 0 && indexUserMail < usuario.Count && usuario[indexUserMail].Password == TextPassword.Text)
            {

                if (usuario[indexUserMail].Rol == 1)
                {
                    int index = buscarVendedor(usuario[indexUserMail], vendedorCarniceria);
                    Heladera vendedorMenu = new Heladera(vendedorCarniceria[index], this, clienteCarniceria);
                    vendedorMenu.Show();
                    this.Hide();
                }
                else
                {
                    if (indexUserMail >= 0 && indexUserMail < usuario.Count && usuario[indexUserMail].Password == TextPassword.Text)
                    {
                        if (usuario[indexUserMail].Rol == 0)
                        {
                            int index = buscarCliente(usuario[indexUserMail], clienteCarniceria);
                            FormVenta cliente = new FormVenta(carne, clienteCarniceria[index], this);
                            cliente.Show();
                            this.Hide();
                        }
                    }

                }
            }

        }


        public int buscarMail(List<Usuario> usuario, string mail)
        {
            int index = -1;
            for (int i = 0; i < usuario.Count; i++)
            {

                if (usuario[i].Mail == mail)
                {
                    index = i;

                    break;

                }
            }


            return index;


            return 6;
        }

        public int buscarPassword(List<Usuario> usuario, string password)
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


            return 7;
        }

        public int buscarVendedor(Usuario usuario, List<Vendedor> vendedor)
        {
            int index = -1;

            for (int i = 0; i < vendedor.Count; i++)
            {

                for (int j = 0; j < this.usuario.Count; j++)
                {

                    if (usuario.Mail == vendedor[i].Mail)
                    {
                        index = i;
                    }
                }
            }

            return index;
        }

        public int buscarCliente(Usuario usuario, List<Cliente> cliente)
        {
            int index = -1;

            for (int i = 0; i < cliente.Count; i++)
            {

                for (int j = 0; j < this.usuario.Count; j++)
                {

                    if (usuario.Mail == cliente[i].Mail)
                    {
                        index = i;
                    }
                }
            }
            return index;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexMail;


            indexMail = buscarMail(usuario, comboBox1.Items[comboBox1.SelectedIndex].ToString());

            if (indexMail >= 0 && indexMail < usuario.Count)
            {


                TextMail.Text = this.usuario[indexMail].Mail;
                TextPassword.Text = this.usuario[indexMail].Password;
            }




        }




    }

}
