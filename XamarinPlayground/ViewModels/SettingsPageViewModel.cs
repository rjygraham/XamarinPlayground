using Prism.AppModel;
using Prism.Events;
using Xamarin.CommunityToolkit.ObjectModel;
using XamarinPlayground.Events;

namespace XamarinPlayground.ViewModels
{
	public class SettingsPageViewModel : ObservableObject, IPageLifecycleAware
	{
		private readonly IEventAggregator eventAggregator;

		public SettingsPageViewModel(IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
		}

		public void OnAppearing()
		{
			eventAggregator.GetEvent<TabActivatedEvent>().Publish(nameof(SettingsPageViewModel));
		}

		public void OnDisappearing()
		{
			
		}
	}
}
