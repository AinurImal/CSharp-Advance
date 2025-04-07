

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder();        // Declare a publisher
            var mailService = new MailService();        // Declare a subscriber for the email service
            var messageService = new MessageService();  // Declare a subscriber for the text message service

            // Declare the subscription before initiating the call
            // This will get checked by the subcribers
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }
    }
}
