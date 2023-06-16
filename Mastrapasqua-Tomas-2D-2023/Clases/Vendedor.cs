using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Clases
{
    /// <summary>
    /// Clase de vendedor que hereda de Usuario
    /// </summary>
    public class Vendedor : Usuario
    {
        int horasTrabajadas;
        int sueldo;

        List<Vendedor> vendedor;

        /// <summary>
        /// Constructor del vendedor
        /// </summary>
        public Vendedor(Usuario usuario) : base(usuario)
        {
            this.sueldo = 0;
            this.horasTrabajadas = 0;

        }

        /// <summary>
        /// Constructor del vendedor, se le pasan los atributos y llama a this()
        /// </summary>
        public Vendedor(Usuario usuario, int horasTrabajadas, int sueldo) : this(usuario)
        {
            this.sueldo = sueldo;
            this.horasTrabajadas = horasTrabajadas;
            

        }

        

        /// <summary>
        /// Propiedad HorasTrabajadas con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int HorasTrabajadas
        {
            get { return horasTrabajadas; }
            set { horasTrabajadas = value; }
        }

        /// <summary>
        /// Propiedad Sueldo con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }

        

        public List<Vendedor> listaVendedores
        {
            get { return vendedor; }
            set { vendedor = value; }
        }
        

        public void MostrarVendedores()
        {
            foreach (Vendedor v in listaVendedores)
            {
                Console.WriteLine(v.ToString());
            }
        }

        /// <summary>
        /// Muestra datos del vendedor usando un stringBuilder que concatena todos los datos y sobrecarga. La clase es override
        /// porque necesita utilizar la clase Mostrar() de usuario. El .base hace referencia a eso mismo, la clase padre y en caso de no 
        /// ponerlo se llamaría asi misma lo que se conoce como método recursivo
        /// </summary>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.Append($"Horas trabajadas: {horasTrabajadas}\n");
            sb.Append($"Sueldo: {sueldo}\n");


            return sb.ToString();
        }

        /// <summary>
        /// Crea una factura dependiendo de si el cliente pago con recargo o no
        /// </summary>
      /*  public Factura crearFacturas(float total, string nombre,bool recargo)
        {


            if (recargo != false)
            {
                Factura factura = new Factura(1, Convert.ToSingle(total + total * 0.05), nombre);
                ListaFacturas.Add(factura);
                return factura;

            }
            else
            {

                Factura factura = new Factura(1, total, nombre);
                ListaFacturas.Add(factura);
                return factura;

            }

        }*/

        /// <summary>
        /// Modifica los datos del vendedor
        /// </summary>
        /// <param name="nuevoNombre"></param>
        /// <param name="nuevaEdad"></param>
        public void ModificarVendedor(string nuevoNombre, int nuevaEdad)
        {
            Nombre = nuevoNombre;
            Edad = nuevaEdad;
        }

        /// <summary>
        /// Agrega un corte de carne a la lista del vendedor
        /// </summary>
        /// <param name="carne"></param>
        /// <returns></returns>
      /*  public bool AgregarCarneListado(Carniceria carne)
        {
            bool ret = false;
            if (carne != null)
            {
                Carne.Add(carne);
                ret = true;
            }
            return ret;
        }*/






    }
}
