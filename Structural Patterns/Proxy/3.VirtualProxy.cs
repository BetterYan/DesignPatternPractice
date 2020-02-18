using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.VirtualProxy
{
    //If you want the object constructed only when it is accessed.
    //And it's too late to modify the code with Lazy<T>
    //Then this kind of design helps.
    public interface IImage
    {
        void Draw();
    }

    internal class Bitmap : IImage
    {
        private readonly string filename;

        public Bitmap(string filename)
        {
            this.filename = filename;
            Console.WriteLine($"Loading the image from {filename}");
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing image {filename}");
        }
    }

    //we don't want the bitmap load the image before draw.
    internal class LazyBitmap : IImage
    {
        private readonly string filename;
        private Bitmap bitmap;

        public LazyBitmap(string filename)
        {
            this.filename = filename;
        }

        public void Draw()
        {
            if (bitmap == null)
            {
                bitmap = new Bitmap(this.filename);
            }
            bitmap.Draw();
        }
    }
}