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

        public Vendedor(Usuario usuario,List<Carniceria> carniceria, int horasTrabajadas, int sueldo) : this(usuario)
        {
            this.carne = carniceria;
            this.sueldo = sueldo;
            this.horasTrabajadas = horasTrabajadas;
            

        }

        public int HorasTrabajadas
        {
            get { return horasTrabajadas; }
            set { horasTrabajadas = value; }
        }

        public int Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }

        public List<Carniceria> Carne
        {
            get { return carne; }
            set { carne = value; }
        }

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
