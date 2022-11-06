using Lounge.ViewModels;

namespace Lounge;

public partial class AccountSetup : ContentPage
{
	public AccountSetup(AccountSetupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}