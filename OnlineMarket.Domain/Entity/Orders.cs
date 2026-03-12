using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Domain.Enums;

namespace OnlineMarket.Domain.Entity
{
    
    public class Orders
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        private decimal _price;
        private int _product;
        public string Name { get; init; } = string.Empty;
        public Status Status { get; private set; }
        public int Product
        {   
            get => _product;
            set
            {
               if (value <= 0)
               throw new ArgumentException("Ошибка товара");
               _product = value;
            } 
        }
        public decimal Price 
        {
          get => _price;
          set
          {
             if (value <= 0)
              throw new ArgumentException("Ошибка цены");
             _price = value;
          }
        }
        public Orders(string name, decimal price, int product)
        {
            Name = name;
            Price = price;
            Product = product;
            Status = Status.NotCreated;
        }
       public Orders() { }
        public void Created()
        {
            if (Status != Status.Created)
                Status = Status.Created;
        }
        public void NotCreated()
        {
            if(Status != Status.NotCreated)
        Status = Status.NotCreated;
        }
    }
}
