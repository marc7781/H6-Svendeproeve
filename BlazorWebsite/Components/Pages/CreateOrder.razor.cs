using FrontendModels;
using BlazorRepository;
using BlazorWebsite.Utils;

namespace BlazorWebsite.Components.Pages
{
    public partial class CreateOrder
    {
        protected OrderRepository orderRepo;
        public Order CreatedOrder { get; set; }
        private LocalStorageHelper localStorageHelper;
        private int ownerId {  get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRernder)
        {
            if(firstRernder)
            {
                localStorageHelper = new LocalStorageHelper(JS);
                try
                {
                    ownerId = Convert.ToInt32(await localStorageHelper.GetAsync("userId"));
                }
                catch
                {
                    navigationManager.NavigateTo("/Login");
                }
                if(ownerId == 0)
                {
                    navigationManager.NavigateTo("/Login");
                }
                orderRepo = new OrderRepository();
                CreatedOrder = new Order();
                CreatedOrder.TruckType = new TruckType();
                CreatedOrder.ExpirationDate = DateTime.Now;
                StateHasChanged();
            }
        }
        private bool ValidateOrder()
        {
            if(string.IsNullOrEmpty(CreatedOrder.Description) || CreatedOrder.Description.Length < 4)
            {
                return false;
            }
            if(string.IsNullOrEmpty(CreatedOrder.Description) || CreatedOrder.Destination.Length < 4)
            {
                return false;
            }
            if(string.IsNullOrEmpty(CreatedOrder.Address) || CreatedOrder.Address.Length < 4)
            {
                return false;
            }
            if(CreatedOrder.Weight <= 0)
            {
                return false;
            }
            if(string.IsNullOrEmpty(CreatedOrder.Size) || CreatedOrder.Size.Count(x => x == '*') > 2 && CreatedOrder.Size.Count(x => x == '*') < 4 && CreatedOrder.Size.Length > 5)
            {
                return false;
            }
            if(CreatedOrder.Price <= 0)
            {
                return false;
            }
            if(CreatedOrder.ExpirationDate < DateTime.Now)
            {
                return false;
            }
            if(string.IsNullOrEmpty(CreatedOrder.ImageUrl) || CreatedOrder.ImageUrl.Length < 5)
            {
                return false;
            }
            return true;
        }
        private async void SubmitOrder()
        {
            if(ValidateOrder())
            {
                CreatedOrder.TruckTypeId = 1;
                CreatedOrder.OwnerId = ownerId;
                bool checkIfSucces = await orderRepo.CreateOrderAsync(CreatedOrder);
                if (checkIfSucces)
                {
                    //order is created
                }
                else
                {
                    //order couldn't be created
                }
            }
            else
            {
                //validate failed
            }
        }
    }
}
