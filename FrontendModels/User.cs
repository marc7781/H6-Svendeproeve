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
        public UserCredentials UserCredentials { get; set; }
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
        public int OrderId { get; set; }
        public List<Order>? Order { get; set; }
        public int TruckTypeId { get; set; }
        public TruckType? TruckType { get; set; }
        public int RatingId { get; set; }
        public List<Rating>? Ratings { get; set; }
    }
}
