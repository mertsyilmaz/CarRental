using Global.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int id { get; set; }
        public int carId { get; set; }
        public int CustomerId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public bool IsSave { get; set; }

    }
}
