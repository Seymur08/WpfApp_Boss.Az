using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp_Boss.Az.Models.Employee_Model;


namespace WpfApp_Boss.Az.MyPropertyChanged
{
	public class BasePropertyChanged : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}
	