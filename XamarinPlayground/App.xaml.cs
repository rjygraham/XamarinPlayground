using XamarinPlayground.Services;
using XamarinPlayground.ViewModels;
using XamarinPlayground.Views;
using Prism;
using Prism.Ioc;

namespace XamarinPlayground
{
	public partial class App
	{
		public App()
			: this(null)
		{
		}

		public App(IPlatformInitializer initializer)
			: base(initializer)
		{
		}

		protected override async void OnInitialized()
		{
			InitializeComponent();

			await NavigationService.NavigateAsync($"{nameof(TransitionNavigationPage)}/{nameof(TabbedMainPage)}?createTab={nameof(HomePage)}&createTab={nameof(SettingsPage)}");
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<TransitionNavigationPage>();
			containerRegistry.RegisterForNavigation<TabbedMainPage, TabbedMainPageViewModel>();
			containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
			containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
			containerRegistry.RegisterForNavigation<ImagePage, ImagePageViewModel>();

			containerRegistry.RegisterInstance<IUnsplashService>(new UnsplashService("UNSPLASH_API_KEY"));
		}

		protected override void OnStart()
		{
			base.OnStart();
		}
	}
}
