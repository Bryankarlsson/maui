using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lounge.Domain;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Lounge.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public RegisterViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        string email;
        [ObservableProperty]
        string password;


        [RelayCommand]
        async Task RegisterUserAsync()
        {
            try
            {
                // Disable button in ui if email or password is missing
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                    return;

                var user = await _userService.Authenticate(email, password);

                if (user is not null)
                {
                    string serializedContent = JsonSerializer.Serialize(user);
                    await SecureStorage.Default.SetAsync("user", serializedContent);
                    await Shell.Current.GoToAsync($"{nameof(AccountSetup)}", true);
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }
    }
}
