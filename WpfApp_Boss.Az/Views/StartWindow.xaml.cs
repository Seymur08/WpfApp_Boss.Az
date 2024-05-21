using System.Windows.Navigation;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.Views;


public partial class StartWindow : NavigationWindow
{
	public StartWindow()
	{

		DataContext = new StartMainPageModel();

	}

}
