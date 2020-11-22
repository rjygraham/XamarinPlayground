using Blurhash.Core;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;
using XamarinPlayground.Models;

namespace XamarinPlayground.Converters
{
	public class BlurhashToStreamConverter : CoreDecoder, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var photo = value as Photo;
			if (photo == null)
			{
				return null;
			}

			var width = 100;

			var height = System.Convert.ToInt32(width * (photo.height / photo.width));

			height = height > 0
				? height
				: 50;

			return ImageSource.FromStream(() => Decode(photo.blur_hash, width, height));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		private Stream Decode(string hash, int width, int height)
		{
			var outputPixels = CoreDecode(hash, width, height);

			using (Image<Rgba32> image = new Image<Rgba32>(outputPixels.GetLength(0), outputPixels.GetLength(1)))
			{
				for (int y = 0; y < image.Height; y++)
				{
					Span<Rgba32> pixelRowSpan = image.GetPixelRowSpan(y);
					for (int x = 0; x < image.Width; x++)
					{
						pixelRowSpan[x] = new Rgba32(
							System.Convert.ToByte(MathUtils.LinearTosRgb(outputPixels[x, y].Red)),
							System.Convert.ToByte(MathUtils.LinearTosRgb(outputPixels[x, y].Green)),
							System.Convert.ToByte(MathUtils.LinearTosRgb(outputPixels[x, y].Blue))
						);
					}
				}

				var output = new MemoryStream();
				image.Save(output, JpegFormat.Instance);

				return output;
			}
		}
	}
}
