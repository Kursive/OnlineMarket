using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Entity
{
   public class User
    {
        public Guid Id {  get; }
        public string Name { get; private set; }=string.Empty;
        private string _email;
        public string Email
        { get => _email; 
            set {
                if (!value.Contains("@") || !string.IsNullOrEmpty(value))
                    throw new ArgumentException("Ошибка почты");
                _email = value;
                }
        }
        public string Password { get; set; } = string.Empty;
        public User(Guid id, string name, string? email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
