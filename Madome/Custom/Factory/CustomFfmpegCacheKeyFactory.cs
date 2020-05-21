using System;
using System.Security.Cryptography;
using System.Text;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace Madome.Custom.Factory
{
	public class CustomFfmpegCacheKeyFactory : ICacheKeyFactory
    {
        private string GetHash(string url)
        {
            using (HashAlgorithm algorithm = MD5.Create())
            {
                byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(url));
                return BitConverter.ToString(hash);
            }
        }
        public string GetKey(ImageSource imageSource, object bindingContext)
        {
            if (imageSource == null){
                return null;
            }

            UriImageSource uriImageSource = imageSource as UriImageSource;
            if (uriImageSource != null)
                return GetHash(uriImageSource.Uri.ToString());
            else
                throw new NotImplementedException("ImageSource type not supported");
        }
    }
}
