using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_Boss.Az.Commands;
using WpfApp_Boss.Az.Models.Employee_Model;
using WpfApp_Boss.Az.MyPropertyChanged;
using WpfApp_Boss.Az.SendMessage;

namespace WpfApp_Boss.Az.ViewModels
{
	public class AboutEmployeeWindowModel : BasePropertyChanged
	{
		public static Employee? employee1;
		public Employee? Employee { get => employee1; set { employee1 = value; OnPropertyChanged(); } }

		public ICommand Send_Email { get; set; }

		public AboutEmployeeWindowModel()
		{
			Send_Email = new RelayCommand(isSendMessageOkay, isSendMessageTrue);
		}

		public bool isSendMessageTrue(object? obj)
		{
			TextBox? textBox = obj as TextBox;
			if( textBox != null && textBox.Text.EndsWith("@gmail.com") )
				return true;
			return false;

		}

		public void isSendMessageOkay(object? obj)
		{
			TextBox? textBox = obj as TextBox;
			MyNetwork.Send_Message(employee1!.Email!, textBox!.Text);
			textBox.Text = null;

		}

	}
}
