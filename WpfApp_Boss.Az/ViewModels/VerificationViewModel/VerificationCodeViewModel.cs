using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp_Boss.Az.Commands;
using WpfApp_Boss.Az.MyPropertyChanged;
using WpfApp_Boss.Az.Views;

namespace WpfApp_Boss.Az.ViewModels
{
	public class VerificationCodeViewModel : BasePropertyChanged
	{
		public static string? Code = null;

		private string? confirmationCode;

		public string? ConfirmationCode { get => confirmationCode; set { confirmationCode = value; OnPropertyChanged(); } }
		public ICommand? confirmation { get; set; }
		public ICommand? CancelCode { get; set; }
		public VerificationCodeViewModel()
        {

			confirmation = new RelayCommand(confirmation_is_okey, confirmation_is_true);
			CancelCode = new RelayCommand(CancelCodeWindow);

		}


		public bool confirmation_is_true(object? obj)
		{

			if( ConfirmationCode == Code )
			{
				return true;
			}

			return false;
		}


		public void confirmation_is_okey(object? obj)
		{
			VerificationCodeView? verificationCodeView = obj as VerificationCodeView;
			verificationCodeView!.Close();

		}

		public void CancelCodeWindow(object? obj)
		{
			VerificationCodeView? verificationCodeView = obj as VerificationCodeView;
			verificationCodeView!.Close();

		}

	}
}
