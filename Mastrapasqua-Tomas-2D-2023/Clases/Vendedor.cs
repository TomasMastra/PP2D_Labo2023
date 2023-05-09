using System.Runtime.CompilerServices;
using System.Text;

namespace Clases
{
    public class Vendedor : Usuario
    {
        int horasTrabajadas;
        int sueldo;
        List<Carniceria> carne;

        public Vendedor(Usuario usuario) : base(usuario)
        {
            this.sueldo = 0;
            this.horasTrabajadas = 0;

        }

        /// <summary>
        /// Constructor del vendedor, se le pasan los atributos y llama a this()
        /// </summary>
        public Vendedor(Usuario usuario,List<Carniceria> carniceria, int horasTrabajadas, int sueldo) : this(usuario)
        {
            this.carne = carniceria;
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

        /// <summary>
        /// Propiedad Carniceria con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public List<Carniceria> Carne
        {
            get { return carne; }
            set { carne = value; }
        }

        /// <summary>
        /// Muestra datos del vendedor usando un stringBuilder que concatena todos los datos y sobrecarga. La clase es override
        /// porque necesita utilizar la clase Mostrar() de usuario. El .base hace referencia a eso mismo, la clase padre y en caso de no 
        /// ponerlo se llamaria asi misma lo que se conoce como metodo recursivo
        /// </summary>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.Append($"Horas trabajadas: {horasTrabajadas}\n");
            sb.Append($"Sueldo: {sueldo}\n");


            return sb.ToString();
        }

        


    }
}
