using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPlayground.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TransitionNavigationPage : SharedTransitionNavigationPage
	{
		public TransitionNavigationPage()
		{
			InitializeComponent();
		}
	}
}