using System;

namespace ExceptionHandling
{
    public class YoutubeException : Exception
    {
        public YoutubeException(string message, Exception innerException)
            : base(message, innerException) //Passing Message to Exception Base Class.
        {

        }
    }
}