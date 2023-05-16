using System.Text;

namespace Clases
{
    /// <summary>
    /// Esta clase representa un usuario que va a ser necesario para logearse
    /// </summary>
    public class Usuario
    {
        int id;
        int edad;
        string nombre;
        string mail;
        string password;
        int rol;

        public Usuario(Usuario usuario)
        {
            this.id = usuario.id;
            this.edad = usuario.edad;
            this.nombre = usuario.nombre;
            this.mail = usuario.mail;
            this.password = usuario.password;
            this.rol = usuario.rol;
        }

        public Usuario(int id, int edad, string nombre, string mail, string password, int rol)
        {

            this.id = id;
            this.edad = edad;
            this.nombre = nombre;
            this.mail = mail;
            this.password = password;
            this.rol = rol;
        }

        /// <summary>
        /// Propiedad Id con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Propiedad Edad con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        /// <summary>
        /// Propiedad Nombre con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Propiedad Mail con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        /// <summary>
        /// Propiedad Password con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Propiedad Rol con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        /// <summary>
        /// Muestra los datos del usuario mediante un stringbuilder, la clase es virtual porque permite que las clases derivadas
        /// usen y le den implementación a este método. Todo esto usando polimorfismo
        /// </summary>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {nombre}\n");
            sb.Append($"Edad: {edad}\n");
            sb.Append($"Mail: {mail}\n");
            sb.Append($"Id: {id}  \n");

            return sb.ToString();
        }

        /// <summary>
        /// Compara 2 usuarios por su mail, si son iguales retorna true
        /// </summary>
        public static bool operator ==(Usuario user1, Usuario user2)
        {

            if (user1.Mail.Equals(user2.Mail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compara 2 usuarios por su mail y si son diferentes retorna false
        /// </summary>
        public static bool operator !=(Usuario user1, Usuario user2)
        {

            return !(user1 == user2);
        }
    }
}
