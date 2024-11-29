using FrontendModels;

namespace MauiApp1.Views;

public partial class Profile : ContentPage
{
    Order order;
	public Profile()
	{
		InitializeComponent();
        mColloctionView.SelectionChanged += MColloctionView_SelectionChanged;
    }

    private async void MColloctionView_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null)
        {
            if (e.CurrentSelection.Count == 0)
            {
                return;
            }
            if (mColloctionView.SelectedItem == null)
            {
                return;
            }
            else
            {
                order = (e.CurrentSelection.FirstOrDefault() as Order);
                await Shell.Current.Navigation.PushModalAsync(new InspectOrder(order));
                mColloctionView.SelectedItem = null;
            }
        }
    }
}