using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    /// <summary>
    /// Proporciona informacion sobrre el corte de carne
    /// </summary>
    public class InfoCarneEventArgs : EventArgs
    {
        private string corte;

        public string Corte
        {
            get { return this.corte; }
        }

        public InfoCarneEventArgs(Carniceria carne)
        {
            this.corte = carne.CortesCarne;
        }
    }
}
