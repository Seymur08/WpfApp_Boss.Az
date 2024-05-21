using System.Windows;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.Views
{
	/// <summary>
	/// AboutPersonWindow.xaml etkileşim mantığı
	/// </summary>
	public partial class AboutRecruiterWindow : Window
	{
		public AboutRecruiterWindow()
		{
			InitializeComponent();
			DataContext = new AboutRecruiterWindowModel();
		}
	}	
}
