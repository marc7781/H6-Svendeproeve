namespace BlazorWebsite.Components.Pages
{
    public partial class CreateOrder
    {
        private bool tempBool = false;
        protected override async Task OnAfterRenderAsync(bool firstRernder)
        {
            if(firstRernder)
            {
                tempBool = true;
                StateHasChanged();
            }
        }
        private string Greeting = "Welcome to Blazor!";

        private void UpdateGreeting()
        {
            Greeting = "Hello, .NET 8!";
            StateHasChanged();
        }
    }
}
