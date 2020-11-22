using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace XamarinPlayground.ViewModels
{
	public class ImagePageViewModel : ObservableObject, INavigatedAware
	{

		private string color;
		public string Color
		{
			get => color;
			set => SetProperty(ref color, value);
		}

		private string imageUri;
		public string ImageUri
		{
			get => imageUri;
			set => SetProperty(ref imageUri, value);
		}
		
		public void OnNavigatedFrom(INavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			Color = (string)parameters["color"];
			ImageUri = (string)parameters["imageUri"];
		}
	}
}
