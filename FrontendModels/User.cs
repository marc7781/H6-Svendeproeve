using FrontendModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class User
    {
        public int Id { get; set; }
        public bool Driver { get; set; }
        public int UserCredentialsId { get; set; }
        public User_credentials User_Credentials { get; set; }
        public int UserInfoId { get; set; }
        public User_info User_Info { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int TruckTypeId { get; set; }
        public TruckType? TruckType { get; set; }
        public int RatingId { get; set; }
        public List<Rating>? Ratings { get; set; }
    }
}
