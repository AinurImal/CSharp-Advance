using System;

namespace EventsAndDelegates
{
    public class MailService
    {
        // Define an event handler which has the same signature as defined by the delegate in the publisher
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            System.Console.WriteLine($"MailService: {e.Video.Title} processed. Sending an email ...");

        }


    }










}
