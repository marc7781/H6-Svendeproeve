using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    partial class RatingComp
    {
        [Parameter]
        public string Reason { get; set; }
        [Parameter]
        public int Rating { get; set; }
        [Parameter]
        public string SenderName { get; set; }
    }
}
