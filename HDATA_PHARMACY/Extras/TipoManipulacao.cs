using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDATA_PHARMACY.Extras
{
    [Flags]
    public enum TipoManipulacao
    {
        CREATE = 0,
        UPDATE = 1,
       // DELETE = 2,
        READ_ALL =3,
        READ_SINGLE = 4
    }
}
