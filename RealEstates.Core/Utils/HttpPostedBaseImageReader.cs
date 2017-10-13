using System.IO;
using System.Drawing;
using System;

namespace RealEstates.Core.Utils
{
	public class HttpPostedBaseImageReader
	{
		public static string ReadFully(Stream input)
		{
			var image = Image.FromStream(input, true, true);
			return ImageToByteArray(image);
		}

		private static string ImageToByteArray(Image imageIn)
		{
			using (MemoryStream m = new MemoryStream())
			{
				imageIn.Save(m, imageIn.RawFormat);
				byte[] imageBytes = m.ToArray();

				return Convert.ToBase64String(imageBytes);
			}
		}
	}
}
