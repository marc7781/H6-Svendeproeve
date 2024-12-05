using BlazorRepository;
using FrontendModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorWebsite.Components.Pages
{
    partial class UpdateOrder
    {
        [Inject]
        protected IOrderRepository orderRepo {  get; set; }
        private Order order { get; set; }
        [Parameter]
        public int Id { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                try
                {
                    order = await orderRepo.GetOrderFromIdAsync(Id);
                }
                catch
                {
                    navigationManager.NavigateTo("/");
                }

                StateHasChanged();
            }
        }
        private bool ValidateOrder()
        {
            if (string.IsNullOrEmpty(order.Description) || order.Description.Length < 4)
            {
                return false;
            }
            if (string.IsNullOrEmpty(order.Description) || order.Destination.Length < 4)
            {
                return false;
            }
            if (string.IsNullOrEmpty(order.Address) || order.Address.Length < 4)
            {
                return false;
            }
            if (order.Weight <= 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(order.Size) || order.Size.Count(x => x == '*') > 2 && order.Size.Count(x => x == '*') < 4 && order.Size.Length > 5)
            {
                return false;
            }
            if (order.Price <= 0)
            {
                return false;
            }
            if (order.ExpirationDate < DateTime.Now)
            {
                return false;
            }
            if (string.IsNullOrEmpty(order.ImageUrl) || order.ImageUrl.Length < 5)
            {
                return false;
            }
            return true;
        }
        private async void SubmitChanges()
        {
            if(ValidateOrder())
            {
                if(await orderRepo.UpdateOrderAsync(order))
                {
                    //it worked
                }
                else
                {
                    //it didn't
                }
            }
        }
    }
}