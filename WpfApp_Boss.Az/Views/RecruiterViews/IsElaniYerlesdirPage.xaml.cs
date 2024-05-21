using System.Windows;
using System.Windows.Controls;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.Views
{

	public partial class IsElaniYerlesdirPage : Page
    {
        public IsElaniYerlesdirPage()
        {
            InitializeComponent();
			
			DataContext = new IsElaniYerlesdirPageModel();

		}

	}
}
