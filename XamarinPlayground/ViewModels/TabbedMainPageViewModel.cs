using Prism.AppModel;
using Prism.Events;
using Xamarin.CommunityToolkit.ObjectModel;
using XamarinPlayground.Events;

namespace XamarinPlayground.ViewModels
{
	public class TabbedMainPageViewModel : ObservableObject, IPageLifecycleAware
	{
		private bool isTitleVisible = true;
		public bool IsTitleVisible
		{
			get => isTitleVisible;
			set => SetProperty(ref isTitleVisible, value);
		}

		public TabbedMainPageViewModel(IEventAggregator eventAggregator)
		{
			eventAggregator.GetEvent<TabActivatedEvent>().Subscribe(value =>
			{
				IsTitleVisible = value.Equals(nameof(HomePageViewModel));
			});
		}

		public void OnAppearing()
		{
			
		}

		public void OnDisappearing()
		{
			
		}
	}
}
