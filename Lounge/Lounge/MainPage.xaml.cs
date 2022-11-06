using Lounge.ViewModels;

namespace Lounge;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
}

