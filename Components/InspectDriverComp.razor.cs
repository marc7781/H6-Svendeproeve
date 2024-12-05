using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontendModels;

namespace Components
{
    partial class InspectDriverComp
    {
        [Parameter]
        public User User { get; set; }
        [Parameter]
        public int AverageRating { get; set; }
        [Parameter]
        public EventCallback<int> WriteRatingEvent { get; set; }
        [Parameter]
        public EventCallback CloseInspectorEvent { get; set; }
        public async Task WriteRatingEventAsync()
        {
            await WriteRatingEvent.InvokeAsync(User.Id);
        }
        public async Task CloseInspectorEventAsync()
        {
            await CloseInspectorEvent.InvokeAsync();
        }
    }
}
