using System.Windows.Controls;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.Views;

public partial class IsAxtaranlarView : Page
{
	public IsAxtaranlarView()
	{
		InitializeComponent();
		DataContext = new StartMainPageModel();
	}
}
