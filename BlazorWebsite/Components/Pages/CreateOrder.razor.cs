using FrontendModels;
using BlazorRepository;

namespace BlazorWebsite.Components.Pages
{
    public partial class CreateOrder
    {
        protected OrderRepository orderRepo;
        public Order CreatedOrder { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRernder)
        {
            if(firstRernder)
            {
                orderRepo = new OrderRepository();
                CreatedOrder = new Order();
                CreatedOrder.TruckType = new TruckType();
                CreatedOrder.ExpirationDate = DateTime.Now;
                StateHasChanged();
            }
        }
        private bool ValidateOrder()
        {
            if(CreatedOrder.Description.Length < 4)
            {
                return false;
            }
            if(CreatedOrder.Destination.Length < 4)
            {
                return false;
            }
            if(CreatedOrder.Address.Length < 4)
            {
                return false;
            }
            if(CreatedOrder.Weight == 0)
            {
                return false;
            }
            if(CreatedOrder.Size.Count(x => x == '*') > 2 && CreatedOrder.Size.Count(x => x == '*') < 4 && CreatedOrder.Size.Length > 5)
            {
                return false;
            }
            if(CreatedOrder.Price == 0)
            {
                return false;
            }
            if(CreatedOrder.ExpirationDate < DateTime.Now)
            {
                return false;
            }
            if(CreatedOrder.ImageUrl.Length < 5)
            {
                return false;
            }
            if(CreatedOrder.TruckType == null)
            {
                return false;
            }
            return true;
        }
        private async void SubmitOrder()
        {
            bool checkIfSucces = await orderRepo.CreateOrderAsync(CreatedOrder);
            if (checkIfSucces)
            {
                
            }
            if (ValidateOrder())
            {

            }
        }
    }
}
