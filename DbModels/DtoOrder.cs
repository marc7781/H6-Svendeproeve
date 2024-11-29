using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DtoOrder
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
        [NotMapped]
        public DtoUser? Owner { get; set; }
        public int? DriverId { get; set; }
        public DtoUser? Driver { get; set; }
        public int TruckTypeId { get; set; }
        public DtoTruckType? TruckType { get; set; }
        public bool Pending { get; set; }
    }
}
