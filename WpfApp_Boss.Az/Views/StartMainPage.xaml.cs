using System.Windows.Controls;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.Views;


public partial class StartMainPage : Page
{

	public StartMainPage()
	{
		InitializeComponent();
		DataContext = new StartMainPageModel();

	}

}
