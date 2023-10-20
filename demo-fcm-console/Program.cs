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

            var deviceToken = "dptzaAI5TUS4vAnd_VjrRr:APA91bF1pcrd2hq9EcqSG1WfU0_Hoy4fYMpgI7si_zUnN9t8aRbcWFJCFQYHZAXVu4ghFUOqMxQ3YBNso2xZOkPlNeNBSTsyinst2dj5I3e-Ei_RkPdTyu2iz3dmDFQrDzTqhWo5dnl9";

            // See documentation on defining a message payload.
            var message = new Message()
            {
                //push notification
                Notification = new Notification
                {
                    Title = "Demo FCM",
                    Body = "Hello World From .NET console"
                },

                //payload data
                Data = new Dictionary<string, string>()
                    {
                        { "score", "850" },
                        { "time", DateTime.Now.ToString() },
                    },
                Token = deviceToken,
            };

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }
    }
}