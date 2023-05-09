using System.Text;

namespace Clases
{
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

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {nombre}\n");
            sb.Append($"Edad: {edad}\n");
            sb.Append($"Mail: {mail}\n");
            sb.Append($"Id: {id}  \n");

            return sb.ToString();
        }
    }
}
