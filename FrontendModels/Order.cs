using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public string Address { get; set; }
        public int Weight { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ImageUrl { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public int DriverId { get; set; }
        public User Driver { get; set; }
        public int TruckTypeId { get; set; }
        public TruckType TruckType { get; set; }
    }
}
