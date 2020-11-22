using Prism.AppModel;
using Prism.Events;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XamarinPlayground.Events;
using XamarinPlayground.Models;
using XamarinPlayground.Services;

namespace XamarinPlayground.ViewModels
{
	public class HomePageViewModel : ObservableObject, IPageLifecycleAware
	{
		private readonly INavigationService navigationService;
		private readonly IEventAggregator eventAggregator;
		private readonly IUnsplashService unsplashService;

		private bool hasAppeared = false;

		public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

		public HomePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IUnsplashService unsplashService)
		{
			this.navigationService = navigationService;
			this.eventAggregator = eventAggregator;
			this.unsplashService = unsplashService;

			ImageTappedCommand = new Command<Photo>(ExecuteImageTappedCommand);
		}

		public ICommand ImageTappedCommand { get; private set; }

		public void ExecuteImageTappedCommand(Photo photo)
		{
			var navigationParams = new NavigationParameters();
			navigationParams.Add("color", photo.color);
			navigationParams.Add("imageUri", photo.urls.regular);
			navigationService.NavigateAsync("ImagePage", navigationParams);
		}

		public void OnAppearing()
		{
			eventAggregator.GetEvent<TabActivatedEvent>().Publish(nameof(HomePageViewModel));

			if (!hasAppeared)
			{
				hasAppeared = true;

				Task.Run(async () =>
				{
					var photos = await unsplashService.GetRandomPhotosAsync(10);

					if (photos != null)
					{
						Device.BeginInvokeOnMainThread(() =>
						{
							Photos.Clear();
							foreach (var photo in photos)
							{
								Photos.Add(photo);
							}
						});
					}
				});
			}
		}

		public void OnDisappearing()
		{
			
		}
	}
}
