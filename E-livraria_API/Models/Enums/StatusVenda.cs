using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_livraria_API.Models.Enums
{
    public enum StatusVenda :int
    {
        pendende=0,
        pago=1,
        cancelada=2
    }
}
