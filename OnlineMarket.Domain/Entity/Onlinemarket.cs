using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Entity
{
    public class Onlinemarket
    {
        private readonly List<Orders> _orders = new List<Orders>();
        private readonly List<User> _users = new List<User>();
        public IReadOnlyCollection<Orders> Orders => _orders;
        public IReadOnlyCollection<User> Users => _users;
    }
}
