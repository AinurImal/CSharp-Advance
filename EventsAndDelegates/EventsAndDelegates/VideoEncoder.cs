using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }

    }
    public class VideoEncoder
    {
        /* We want to let someone know when the encoding has finished by sending them an email.
        Step 1. Define a delegate i.e. the agreement between the Publisher and Subscriber
        Step 2. Define an event based on this delegate  ff
        Step 3. Raise/publish the event
        */

        /* Step 1: Define the delegate. The name is always in the past tense of the action that we are performing in this
        class. The class is VideoEncoder so the delegate will be VideoEncoded. We always suffix with EventHandler.
        */
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        // Step 2: Define a public event using the above delegate. Instantiate with a past tense var name.
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video)
        {
            System.Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);
            // Notify subscribers
            OnVideoEncoded(video);
        }

        //Step 3: Method for creating the event. Always protected, virtual and void. Always prefixed with 'On'.

        protected virtual void OnVideoEncoded(Video video)
        {
            // Check if there are any subscribers to this event
            // Actually looking at the reference whcih is incremented in Program.cs with +=
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }

    }
}