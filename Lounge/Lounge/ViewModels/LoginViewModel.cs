using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Lounge.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [RelayCommand]
        async Task RegisterUserAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(Register)}", true);
        }

        [RelayCommand]
        async Task LoginUserAsync()
        {
            var test = this.Email;
            //var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            //try
            //{
            //    var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserName, UserPassword);
            //    var content = await auth.GetFreshAuthAsync();
            //    var serializedContent = JsonConvert.SerializeObject(content);
            //    Preferences.Set("FreshFirebaseToken", serializedContent);
            //    await this._navigation.PushAsync(new Dashboard());
            //}
            //catch (Exception ex)
            //{
            //    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            //    throw;
            //}
        }
    }
}
