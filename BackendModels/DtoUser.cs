using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoUser
    {
        public int Id { get; set; }
        public bool Driver {  get; set; }
        public int UserCredentialsId { get; set; }
        public DtoUserCredentials UserCredentials { get; set; }
        public int UserInfoId { get; set; }
        public DtoUserInfo UserInfo { get; set; }
        public int OrderId { get; set; }
        public List<DtoOrder>? Order { get; set; }
        public int? TruckTypeId { get; set; }
        public DtoTruckType? TruckType { get; set; }
        public int RatingId { get; set; }
        public List<DtoRating>? Ratings { get; set; }
    }
}
