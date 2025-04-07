using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegate
{
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo); //A delegate is a class derived from System.MulticastDelegate
        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            //System.Action<> //Action points to a method that returns void
            //System.Func<>//Func points to a method that returns a value (out TResult)

            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }

    public class Photo
    {
        public static Photo Load(string path)
        {
            // Load photo from path
            return new Photo();
        }

        public void Save()
        {
            // Save photo
        }
    }
}
