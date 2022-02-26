using System;
using System.Text;

namespace Medea.Client.Adapter
{
    public static class DataUriExtensions
    {
        public static string GetMediaType(this Uri uri)
        {
            if (uri.Scheme.ToLower() != "data")
            {
                throw new ArgumentException($"Cannot determine media type of uri with scheme {uri.Scheme}");
            }

            var originalString = uri.OriginalString;

            if (!originalString.Contains(','))
            {
                return "text/plain;charset=US-ASCII";
            }

            var mediaType = originalString.Substring(5).Split(',')[0];

            if (mediaType == "")
            {
                return "text/plain;charset=US-ASCII";
            }

            return mediaType;
        }

        public static string GetContent(this Uri uri)
        {
            if (uri.Scheme.ToLower() != "data")
            {
                throw new ArgumentException($"Cannot get content of uri with scheme {uri.Scheme}");
            }

            var originalString = uri.OriginalString;

            if (!originalString.Contains(','))
            {
                return Uri.UnescapeDataString(originalString.Substring(5));
            }

            var rawContent = Uri.UnescapeDataString(originalString.Substring(5).Split(',')[1]);
            var mediaType = uri.GetMediaType();

            if (mediaType.EndsWith(";base64"))
            {
                var encoding = Encoding.GetEncoding("US-ASCII");

                foreach (var part in mediaType.Split(';'))
                {
                    if (part.StartsWith("charset="))
                    {
                        encoding = Encoding.GetEncoding(part.Substring(8));
                    }
                }

                return encoding.GetString(Convert.FromBase64String(rawContent));
            }

            return rawContent;
        }
    }
}
