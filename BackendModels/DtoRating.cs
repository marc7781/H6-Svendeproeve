using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendModels
{
    public class DtoRating
    {
        public int Id { get; set; }
        public int Ratings { get; set; }
        public string Reason { get; set; }
        public int SenderId { get; set; }
        public DtoUser Sender { get; set; }
        public int ReceiverId { get; set; }
        public DtoUser Receiver { get; set; }
    }
}
