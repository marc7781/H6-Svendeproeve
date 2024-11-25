using FrontendModels;

namespace BlazorWebsite.Components.Pages
{
    partial class Profile
    {
        private User user {  get; set; }
        private List<Order> activeOrders { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                //user = 
                StateHasChanged();
            }
        }
    }
}
