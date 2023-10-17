using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace demo_fcm_console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential
                    .FromJson(File.ReadAllText("fir-fcm-da2ef-firebase-adminsdk-517ao-747f868825.json"))
            });

            var registrationToken = "fU9t2lfWST-abKPJC2bvPf:APA91bEHHsk1F2Pwkko7cCnx1fbUOPb9dRC5YrLtkcGM8Miogj30vviyMHgCSZIBLlOpr0h3joFU7BBx1kIcX1z_MDYFXddN1KoSwsiQN4K_8VL8wK796abw2pkLGd5Q6-f-3VYRP18_";

            // See documentation on defining a message payload.
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "Demo",
                    Body = "Hello World"
                },
                Data = new Dictionary<string, string>()
                    {
                        { "score", "850" },
                        { "time", "2:45" },
                    },
                Token = registrationToken,
            };

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }
    }
}