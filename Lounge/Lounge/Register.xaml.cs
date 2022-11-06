using Lounge.ViewModels;

namespace Lounge;

public partial class Register : ContentPage
{
	public Register(RegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}