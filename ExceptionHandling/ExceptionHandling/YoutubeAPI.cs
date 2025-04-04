using System;
using System.Collections.Generic;

namespace ExceptionHandling
{

    public class YoutubeAPI
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                //Access Youtube WebService
                //Read Data
                //Create a List of Video Objects

                //We could have here lots of Network Specific, low level errors here when working with a network stream.
                //But we don't want to expose these to users of the API Client.
                //Thus we can create Custom Errors for users.

                throw new Exception("Socket 425 Denying Access without Token."); //Simulating Low Level Exception.
            }
            catch (Exception ex)
            {
                //Log the Exception
                //Throw Custom Exception.
                //Pass the Inner Exception to YoutubeException, so we can troubleshoot easier.
                //We could see the low level exception eg Socket Error 101010 bla.
                throw new YoutubeException("Could not fetch the videos from Youtube.", ex);
            }
            return new List<Video>();
        }
    }
}