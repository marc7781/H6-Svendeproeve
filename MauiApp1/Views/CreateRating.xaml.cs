using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class CreateRatings : ContentPage
{
	public CreateRatings(int userid)
	{
		InitializeComponent();
        BindingContext = new CreateRatingsViewModel(userid);
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (star1 == sender)
        {
            star1.Source = "star_full.png";
            star2.Source = "star_empty.png";
            star3.Source = "star_empty.png";
            star4.Source = "star_empty.png";
            star5.Source = "star_empty.png";
        }
        else if (star2 == sender)
        {
            star1.Source = "star_full.png";
            star2.Source = "star_full.png";
            star3.Source = "star_empty.png";
            star4.Source = "star_empty.png";
            star5.Source = "star_empty.png";
        }
        else if (star3 == sender)
        {
            star1.Source = "star_full.png";
            star2.Source = "star_full.png";
            star3.Source = "star_full.png";
            star4.Source = "star_empty.png";
            star5.Source = "star_empty.png";
        }
        else if (star4 == sender)
        {
            star1.Source = "star_full.png";
            star2.Source = "star_full.png";
            star3.Source = "star_full.png";
            star4.Source = "star_full.png";
            star5.Source = "star_empty.png";
        }
        else
        {
            star1.Source = "star_full.png";
            star2.Source = "star_full.png";
            star3.Source = "star_full.png";
            star4.Source = "star_full.png";
            star5.Source = "star_full.png";
        }
    }
}