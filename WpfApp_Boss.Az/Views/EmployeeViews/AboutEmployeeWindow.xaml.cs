﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.Views
{
	/// <summary>
	/// AboutEmployeeWindow.xaml etkileşim mantığı
	/// </summary>
	public partial class AboutEmployeeWindow : Window
	{
		public AboutEmployeeWindow()
		{
			InitializeComponent();
			DataContext = new AboutEmployeeWindowModel();
		}
	}
}
