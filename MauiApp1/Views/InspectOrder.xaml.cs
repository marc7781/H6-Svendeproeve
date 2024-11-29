using FrontendModels;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class InspectOrder : ContentPage
{
	public InspectOrder(Order selectedOrder)
	{
		InitializeComponent();
		BindingContext = new InspectOrderViewModel(selectedOrder);
	}
}