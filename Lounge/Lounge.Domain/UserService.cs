using Firebase.Auth;
using Firebase.Storage;
using Lounge.Common;
using System.Runtime.CompilerServices;

namespace Lounge.Domain
{

    public class UserService : IUserService
    {
        public string webApiKey = "AIzaSyDYqPSYXv1lbmrE29S0KUo0BgLDw-dEOmM";
        private static string Bucket = "lounge-12f69.appspot.com";
        private static string AuthEmail = "admin@admin.com";
        private static string AuthPassword = "fisk12345";
        private static FirebaseAuthProvider _authProvider;
        private readonly IDatabaseService _databaseService;


        public UserService(IDatabaseService databaseService)
        {
            _authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            _databaseService = databaseService;
        }



        public async Task<UserInfo>? Authenticate(string email, string password)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

            if (auth.FirebaseToken is not null)
                return new UserInfo { Email = auth.User.Email, Id = auth.User.LocalId, Token = auth.FirebaseToken };

            return null;
        }

        public async Task Upload(FileStream stream, string fileName, string token)
        {
            try
            {
                //var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var a = await _authProvider.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(Bucket, new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                }).Child("images").Child(fileName).PutAsync(stream, cancellation.Token);

                var testar = await task;
                var user = await GetUser(token);

                user.ProfilePicture = testar;

                await _databaseService.Insert(user);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private async Task<UserInfo> GetUser(string token)
        {
            var user = await _authProvider.GetUserAsync(token);
            if (user is not null)
                return new UserInfo { Email = user.Email, Id = user.LocalId };

            return null;
        }

        public async Task Insert()
        {
            try
            {
                //var config = new FiirebaseConfig { AuthSecret = "d97c6ppkSnyqKUGMVL9rGBCOiVNKvzbvVwe0AeDT", BasePath = "https://lounge-12f69-default-rtdb.europe-west1.firebasedatabase.app/" };
                //var _client = new FirebaseClient(config);

                //IFirebaseConfig config = new FirebaseConfig
                //{
                //    AuthSecret = "d97c6ppkSnyqKUGMVL9rGBCOiVNKvzbvVwe0AeDT",
                //    BasePath = "https://lounge-12f69-default-rtdb.europe-west1.firebasedatabase.app/"
                //};
                //var _client = new FirebaseClient(config);
                //var todo = new Todo
                //{
                //    Name = "Execute Push",
                //    Priority = 2
                //};
                //var response = await _client.PushAsync("todos", todo);
                //Todo result = response.ResultAs<Todo>(); //The response will contain the data written

                ////var todo = new Todo
                ////{
                ////    Name = "Execute UPDATE!",
                ////    Priority = 1
                ////};

                //todo.Name = "Update execute push";
                //FirebaseResponse responsee = await _client.UpdateAsync("todos", todo);
                //var data = responsee.ResultAs<Todo>(); //The response will contain the data written

                //var todo = new Todo
                //{
                //    Name = "Execute PUSH",
                //};
                //PushResponse response = await _client.PushAsync("todos/push", todo);
                //var testar = response.Result.name; //The result will contain the child name of the new data that was added
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    //public class FiirebaseConfig : IFirebaseConfig
    //{
    //    public string BasePath { get; set; }
    //    public string Host { get; set; }
    //    public string AuthSecret { get; set; }
    //    public TimeSpan? RequestTimeout { get; set; }
    //    public ISerializer Serializer { get; set; }
    //}

    //public class Todo
    //{
    //    public string Name { get; set; }

    //    public int Priority { get; set; }
        
    //}
}