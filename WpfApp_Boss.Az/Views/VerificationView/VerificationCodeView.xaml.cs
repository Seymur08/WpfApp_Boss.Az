using System.Windows;
using System.Windows.Input;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.Views;


public partial class VerificationCodeView : Window
{
	public VerificationCodeView()
	{
		InitializeComponent();
		DataContext = new VerificationCodeViewModel();

	}
}
