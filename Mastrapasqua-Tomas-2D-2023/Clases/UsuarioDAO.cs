using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class UsuarioDAO
    {
        private string connectionString;

        public UsuarioDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
