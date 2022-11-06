using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lounge.Common;
using Lounge.Domain;
using System.Text.Json;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Lounge.ViewModels
{
    public partial  class AccountSetupViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        public AccountSetupViewModel(IUserService userService)
        {
            this.profilePicture = "https://t4.ftcdn.net/jpg/02/83/72/41/360_F_283724163_kIWm6DfeFN0zhm8Pc0xelROcxxbAiEFI.jpg";
            _userService = userService;
        }

        [ObservableProperty]
        string profilePicture;

        [ObservableProperty]
        string name;

        [RelayCommand]
        async Task UploadProfilePicture()
        {
            //await _userService.Insert();
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    var user = JsonSerializer.Deserialize<UserInfo>(await SecureStorage.Default.GetAsync("user"));
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using (Stream sourceStream = await photo.OpenReadAsync())
                    {
                        using (FileStream localFileStream = new FileStream(localFilePath, FileMode.Open))
                        {
                            await sourceStream.CopyToAsync(localFileStream);
                            await _userService.Upload(localFileStream, photo.FileName, user.Token);     
                        }
                    }
                    
                    ProfilePicture = localFilePath;
                }
            }
        }

        [RelayCommand]
        async Task SetupUser()
        {

        }
    }
}
