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
        public DtoUser_credentials User_Credentials { get; set; }
        public int UserInfoId { get; set; }
        public DtoUser_info User_Info { get; set; }
        public int OrderId { get; set; }
        public DtoOrder? Order { get; set; }
        public int TruckTypeId { get; set; }
        public DtoTruckType? TruckType { get; set; }
        public int RatingId { get; set; }
        public List<DtoRating>? Ratings { get; set; }
    }
}
