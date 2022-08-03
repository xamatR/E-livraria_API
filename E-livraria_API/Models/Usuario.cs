using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_livraria_API.Models.Enums;
using System.ComponentModel.DataAnnotations;


namespace E_livraria_API.Models
{
    public abstract class Usuario
    {
        public int id { get; protected set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string nome { get; protected set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        [DataType(DataType.EmailAddress)]
        public string login { get; protected set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        [DataType(DataType.Password)]
        public string password { get; protected set; }
        public bool auth { get; protected set; }
        [Required]
        public accountType accType { get; protected set; }

        protected Usuario()
        {
        }

        protected Usuario(int id, string nome, string login, string password)
        {
            this.id = id;
            this.nome = nome;
            this.login = login.ToUpper();
            this.password = password;
            this.auth = false;
        }

        public bool verificaLogin(string login, string password)
        {
            if(!(login.ToUpper() == this.login && password == this.password)){
                this.auth = false;
                return auth;
            }
            this.auth = true;
            return auth;
        }

        public void logout()
        {
            this.auth = false;
        }
    }
}
