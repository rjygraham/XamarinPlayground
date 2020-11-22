using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPlayground.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhotoTemplate : DataTemplate
	{
		public PhotoTemplate()
		{
			InitializeComponent();
		}
	}
}