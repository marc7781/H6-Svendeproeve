using CommunityToolkit.Maui.Views;
using FrontendModels;
using MauiApp1.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.Views;

public partial class FindOrderPopUp : Popup
{
	public FindOrderPopUp(Order order)
	{
		InitializeComponent();
		BindingContext = new FindOrderPopUpViewModel(order);

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}