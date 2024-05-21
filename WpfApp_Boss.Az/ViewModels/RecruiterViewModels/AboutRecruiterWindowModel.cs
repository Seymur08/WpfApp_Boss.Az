using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_Boss.Az.Commands;
using WpfApp_Boss.Az.Models.Recruiter_Model;
using WpfApp_Boss.Az.MyPropertyChanged;
using WpfApp_Boss.Az.SendMessage;

namespace WpfApp_Boss.Az.ViewModels
{
	public class AboutRecruiterWindowModel : BasePropertyChanged
	{
		public static Recruiter? recruiter1;

		public Recruiter? recruiter { get => recruiter1; set { recruiter1 = value; OnPropertyChanged(); } }

		public ICommand	Send_Email { get; set; }

		public AboutRecruiterWindowModel()
        {
			Send_Email = new RelayCommand(isSendMessageOkay, isSendMessageTrue);
			
		}

		public bool isSendMessageTrue(object? obj)
		{
			TextBox? textBox = obj as TextBox;
			if (textBox != null && textBox.Text.EndsWith("@gmail.com"))
				return true;
			return false;
			
		}

		public void isSendMessageOkay(object? obj)
		{
			TextBox? textBox = obj as TextBox;
			MyNetwork.Send_Message(recruiter!.Email!, textBox!.Text);
			textBox.Text = null;

		}

	}
}
