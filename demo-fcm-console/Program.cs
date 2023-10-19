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

            var registrationToken = "fLx0b-aFQ_CyylT8OBd9ii:APA91bFMa1pSEJHyrRZ3hLJkatjpKyl8ZnCdppRhkhanOtKJZ4r_wEqWpxFoFFlg79k7AOuSs2KJxM6a0q9DAv4uKZ21iilWLeb_vlpKaW7jhzyyNhbA7rApMtydVB-X89TQ5G2SRD2d";

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