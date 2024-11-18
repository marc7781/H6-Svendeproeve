using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendModels
{
    public class Rating
    {
        public int Id { get; set; }
        public int Ratings { get; set; }
        public string Reason { get; set; }
        public int SenderId { get; set; }
        public User? Sender { get; set; }
        public int ReceiverId { get; set; }
        public User? Receiver { get; set; }
    }
}
