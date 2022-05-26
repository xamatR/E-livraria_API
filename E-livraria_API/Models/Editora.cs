using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_livraria_API.Models
{
    public class Editora : Usuario
    {
        public Editora(int id, string nome, string login, string password, bool auth, int accType) : base(id, nome, login, password, auth)
        {
            base.accType = accType;
        }
    }
}
