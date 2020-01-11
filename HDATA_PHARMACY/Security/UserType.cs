using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDATA_PHARMACY.Security
{
    [Flags]
    public  enum UserType
    {
        
        Simples = 1,
        Admin = 0,
        SuperAdmin = 2
    }

    [Flags]
    public enum StatusType
    {
        Desactivo = 0,
        Activo = 1
    }
}
