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
        private bool updateFailed { get; set; }
        private bool deleteOrdre { get; set; }
        private string errorMsg { get; set; }
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
        private void DeleteOrder()
        {
            deleteOrdre = true;
            StateHasChanged();
        }
        private void CancelDeleteOrder()
        {
            deleteOrdre = false;
            StateHasChanged();
        }
        private async Task ConfirmedDeleteOrder()
        {
            await orderRepo.DeleteOrderAsync(order.Id);
        }

        private async void SubmitChanges()
        {
            if(ValidateOrder())
            {
                if(await orderRepo.UpdateOrderAsync(order))
                {
                    navigationManager.NavigateTo("/");
                }
                else
                {
                    await ShowErrorMessageAsync("Kunne ikke opdater ordren på vores ende, prøv igen");
                }
            }
            else
            {
                await ShowErrorMessageAsync("Informationen på ordren er ikke korrekt");
            }
        }
        private async Task ShowErrorMessageAsync(string message)
        {
            errorMsg = message;
            updateFailed = true;
            StateHasChanged();
            ErrorTimeMessageAsync();
        }
        private async void ErrorTimeMessageAsync()
        {
            await Task.Delay(5000);
            updateFailed = false;
            StateHasChanged();
        }
        private void GoToMainPage()
        {
            navigationManager.NavigateTo("/");
        }
    }
}