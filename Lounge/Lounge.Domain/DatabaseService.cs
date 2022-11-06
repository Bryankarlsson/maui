using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Lounge.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Domain
{
    public class DatabaseService : IDatabaseService
    {
        public async Task Insert(UserInfo userInfo)
        {
            try
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = "d97c6ppkSnyqKUGMVL9rGBCOiVNKvzbvVwe0AeDT",
                    BasePath = "https://lounge-12f69-default-rtdb.europe-west1.firebasedatabase.app/"
                };

                var _client = new FirebaseClient(config);

                var response = await _client.PushAsync("users", userInfo);
                UserInfo result = response.ResultAs<UserInfo>(); //The response will contain the data written

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

    public class FiirebaseConfig : IFirebaseConfig
    {
        public string BasePath { get; set; }
        public string Host { get; set; }
        public string AuthSecret { get; set; }
        public TimeSpan? RequestTimeout { get; set; }
        public ISerializer Serializer { get; set; }
    }
}
