using FrontendModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    partial class DeleteOrderComp
    {
        [Parameter]
        public EventCallback CancelDeleteEvent { get; set; }
        [Parameter]
        public EventCallback ConfirmDeleteEvent { get; set; }

        public async Task ConfirmDeleteEventAsync()
        {
            await ConfirmDeleteEvent.InvokeAsync();
        }
        public async Task CancelDeleteEventAsync()
        {
            await CancelDeleteEvent.InvokeAsync();
        }
    }
}
