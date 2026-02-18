using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Entity
{
    public class Onlinemarket
    {
       
        private readonly List<Order> _orders = new List<Order>();
        private readonly List<User> _users = new List<User>();
        public IReadOnlyCollection<Order> Orders => _orders;
        public IReadOnlyCollection<User> Users => _users;
        public Onlinemarket() { }
    }
}
