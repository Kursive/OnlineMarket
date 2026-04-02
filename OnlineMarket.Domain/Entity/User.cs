using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Domain.Enums;

namespace OnlineMarket.Domain.Entity
{
   public class User
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }=string.Empty;
        private string _email;
        public Status Status { get; private set; }
        public string Email
        { 
            get => _email; 
            set 
            {
                if (string.IsNullOrEmpty(value) || !value.Contains("@"))
                    throw new ArgumentException("Ошибка почты");
                _email = value;
            }
        }
        public string Password { get;private set; } = string.Empty;
        public User( string name, string? email, string password)
        {
            
            Name = name;
            Email = email;
            Password = password;
            Status = Status.NotCreated;
        }
        public User() { }
        public void Created()
        {
            if (Status != Status.Created)
                Status = Status.Created;
        }
        public void NotCreated()
        {
            if (Status != Status.NotCreated)
                Status = Status.NotCreated;
        }
        public void Update(string email,string name,string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }
    }
}
