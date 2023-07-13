using Clases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Timers;

namespace FormApp
{
    public partial class Heladera : Form
    {
        Form FormLogin;
        Vendedor vendedorCarniceria;

        public Heladera()
        {
            InitializeComponent();
        }

        public Heladera(Vendedor vendedor, Form formLogin) : this()
        {
            this.vendedorCarniceria = vendedor;
            this.FormLogin = formLogin;
        }

        private void FormVendedor_Load(object sender, EventArgs e)
        {
            inicializar();
            saludo.Text = $"Bienvenido {vendedorCarniceria.Nombre}";
            Cantidad.Maximum = 0;
            //checkBoxStock.Checked = true;
            //BotonAgregarStock.Enabled = false;
        }

        /// <summary>
        /// Método que inicializa algunos datos como la lista de clientes, el datagRidView y la listBox con los cortes para vender
        /// Se ejecuta al cargar el formulario
        /// </summary>
        public void inicializar()
        {
            CargarListBoxClientes();
            CargarDataGridViewCortesCarne();
            CargarListBoxCarne();
        }


        /// <summary>
        /// Método que inicializa el listBox de clientes, cargando el nombre
        /// </summary>
        public void CargarListBoxClientes()
        {
            List<Cliente> clientes = Tienda.ObtenerClientes();
            if (ListClientes.Items.Count == 0 && clientes != null && clientes.Count > -1)
            {
                foreach (Cliente cliente in clientes)
                {
                    ListClientes.Items.Add(cliente.Nombre);
                }
            }

        }

        /// <summary>
        /// Carga los datos del vendedor en el DataGridView.
        /// </summary>
        /// <param name="vendedor">El vendedor cuyos datos se cargarán en el DataGridView.</param>
        public void CargarDataGridViewCortesCarne()
        {

            List<Carniceria> listaCortes = Tienda.ObtenerCarne();

            if (dataGridViewCarne.Rows.Count > 0)
            {
                dataGridViewCarne.Rows.Clear();

            }



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
        public void CargarListBoxCarne()
        {
            ListCarro.Items.Clear();

            foreach (Carniceria carne in Tienda.ObtenerCarne())
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
        private void botonAgregar_Click(object sender, EventArgs e)
        {
            FormAlta formAlta = new FormAlta(this);
            formAlta.ShowDialog();

            CargarDataGridViewCortesCarne();
            CargarListBoxCarne();
        }


        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "?" que tiene instrucciones sobre el programa y su funcionamiento
        /// Muestra un mensaje de ayuda con las instrucciones para agregar y modificar cortes de carne
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
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
            FormAlta formAlta = new FormAlta(2, this);
            formAlta.ShowDialog();

            CargarDataGridViewCortesCarne();
            CargarListBoxCarne();
        }




        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Actualizar" 
        /// Vuelve a cargar los datos del vendedor en el DataGridView
        /// </summary>
        private void Actualizar_Click(object sender, EventArgs e)
        {
            CargarDataGridViewCortesCarne();
            CargarListBoxCarne();

        }

        /// <summary>
        /// Método que se ejecuta cuando se selecciona un cliente en la lista 
        /// Habilita el botón "Ver carro" si el cliente tiene elementos en su carrito
        /// </summary>
        private void ListClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Cliente> clientes = Tienda.ObtenerClientes();

            if (ListClientes.SelectedIndex > -1)
            {
                Cliente cliente = clientes[ListClientes.SelectedIndex];//error

                if (ListClientes.SelectedIndex > -1)
                {
                    BotonVerCarro.Text = $"Ver carro de {cliente.Nombre}";
                    ListClientes.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Aceptar" 
        /// Crea una factura para el cliente seleccionado y actualiza los datos del vendedor y del cliente
        /// </summary>
        private void BotonAceptar_Click(object sender, EventArgs e)//compra del cliente
        {
            List<Cliente> clientes = Tienda.ObtenerClientes();
            string noSeCompro;
            string mensaje = null;


            if (ListClientes.SelectedIndex > -1 && ListClientes.Items.Count > 0)
            {
                Cliente clienteComprar = clientes[ListClientes.SelectedIndex];


                if (clienteComprar.ListaCompras.Count > 0)
                {
                    Restablecer();
                    noSeCompro = Tienda.Comprar(clienteComprar, esRecargo.Checked);

                    if (noSeCompro.Length != 0)
                    {
                        MessageBox.Show($"No se pudo comprar: \n{noSeCompro}");
                    }
                    else
                    {
                        MessageBox.Show("La compra se realizo con exito!!!");

                    }


                }
                else
                {
                    MessageBox.Show($"No hay nada en el carro de {clienteComprar}");

                }
            }
            else
            {
                MessageBox.Show("No selecciono ningun cliente");

            }

            CargarDataGridViewCortesCarne();
            CargarListBoxCarne();
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
            PrecioKilo.Text = "Precio por KG:";
        }



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

            List<Clases.Factura> facturas = Tienda.ObtenerFacturas();


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
            List<Carniceria> carne = Tienda.ObtenerCarne();
            List<Cliente> clientes = Tienda.ObtenerClientes();

            if (ListClientes.SelectedIndex > -1)
            {
                if (ListCarro.SelectedIndex > -1 && Cantidad.Value > 0)
                {
                    if (Convert.ToInt32(dataGridViewCarne.Rows[ListCarro.SelectedIndex].Cells[3].Value) > 0 && Cantidad.Value > 0)
                    {

                        int cantidad = Convert.ToInt32(Cantidad.Value);
                        int idCarro = Tienda.ObtenerUltimoIdCarro() + 1;
                        int idCliente = clientes[ListClientes.SelectedIndex].Id;
                        int idCarne = carne[ListCarro.SelectedIndex].IdCarne;

                        ListaCompras carro = new ListaCompras(idCarro, idCliente, idCarne, cantidad);

                        existe = clientes[ListClientes.SelectedIndex].AgregarCarro(carro);
                        PrecioTotal.Text = "";
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
            List<Carniceria> carne = Tienda.ObtenerCarne();

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
                List<Carniceria> carne = Tienda.ObtenerCarne();



                PrecioTotal.Text = $"Precio * {Cantidad.Value}KG: {(carne[ListCarro.SelectedIndex].PreciosCarne * Cantidad.Value).ToString()}$";
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se hace clic en el botón "Cancelar cliente" 
        /// Cancela la compra del cliente seleccionado y vacía su carrito
        /// </summary>
        private void BotonCancelarCliente_Click(object sender, EventArgs e)
        {
            List<Cliente> listaClientes = Tienda.ObtenerClientes();


            if ((ListClientes.SelectedIndex > -1))
            {           // MessageBox.Show($"{listaClientes[0].Nombre}{listaClientes[1].Nombre}");

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
            List<Cliente> listaClientes = Tienda.ObtenerClientes();

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


        private void Eliminar_Click(object sender, EventArgs e)
        {
            FormAlta formAlta = new FormAlta(3, this);
            formAlta.ShowDialog();



            CargarDataGridViewCortesCarne();
            CargarListBoxCarne();
        }

        
    }
}





