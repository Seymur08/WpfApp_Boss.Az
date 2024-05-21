using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using WpfApp_Boss.Az.Commands;
using WpfApp_Boss.Az.DataBase;
using WpfApp_Boss.Az.Models.Employee_Model;
using WpfApp_Boss.Az.Models.Recruiter_Model;
using WpfApp_Boss.Az.MyPropertyChanged;
using WpfApp_Boss.Az.Views;

namespace WpfApp_Boss.Az.ViewModels;

public class StartMainPageModel : BasePropertyChanged
{
	public bool check = true;
	

	public ObservableCollection<Recruiter>? Recruiters { get; set; } = new ObservableCollection<Recruiter>();

	public ObservableCollection<Employee>? Employees { get; set; } = new ObservableCollection<Employee>();
	

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public ICommand ElanYerlesdirCommand {  get; set; }
	public ICommand IsElanLariCommand { get; set; }
	public ICommand IsAxtaranlarCommand { get; set; }	
	public ICommand MaliyyeCommand { get; set; }	
	public ICommand MarketinqCommand { get; set; }
	public ICommand InformasiyaCommand { get; set; }	
	public ICommand InzibatiCommand { get; set; }
	public ICommand SatısCommand { get; set; }
	public ICommand DizaynCommand { get; set; }
	public ICommand HuquqsunaslıqCommand { get; set; }
	public ICommand TehsilCommand { get; set; }
	public ICommand SenayiCommand { get; set; }
	public ICommand XidmetCommand { get; set; }
	public ICommand TibbCommand { get; set; }
	public ICommand MuxtelifCommand { get; set; }
	public ICommand HaqqindaCommand { get; set; }
	public ICommand AxtarCommand { get; set; }


	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


	private static string? kategoriya;
	public string? Kategoriya { get => kategoriya; set { kategoriya = value; OnPropertyChanged(); } }

	private static string? maas_min;
	public string? Maas_min { get => maas_min; set { maas_min = value; OnPropertyChanged(); } }

	private static string? maas_max;
	public string? Maas_max { get => maas_max; set { maas_max = value; OnPropertyChanged(); } }

	private List<string> salary;
	public List<string> Salary { get => salary; set { salary = value; OnPropertyChanged(); } }

	private List<string> category;

	
	public List<string> Category { get => category; set { category = value; OnPropertyChanged(); } }


	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



	public StartMainPageModel()
	{

		CtreateSalary();
		CreateCategory();


		Recruiters = AllDatabases.Recruiters;

		Employees = AllDatabases.Employees;

		AxtarCommand = new RelayCommand(IsAxtarCommand, IsAxtarCommandTrue);

		ElanYerlesdirCommand = new RelayCommand(ElanYerlestir);

		IsElanLariCommand = new RelayCommand(IsElanVerBtnOkey);

		IsAxtaranlarCommand = new RelayCommand(isIsAxtarOkay, isIsAxtarTrue);

		MaliyyeCommand = new RelayCommand(isMaliyyeCommandOkey, isMaliyyeCommand);

		MarketinqCommand = new RelayCommand(isMarketingCommandOkey, isMarketingCommand);

		InformasiyaCommand = new RelayCommand(isInformasiyaCommandOkey, isInformasiyaCommand);

		InzibatiCommand = new RelayCommand(isInzibatiCommandOkey, isInzibatiCommand);

		SatısCommand = new RelayCommand(isSatısCommandOkey, isSatısCommand);

		DizaynCommand = new RelayCommand(isDizaynCommandOkey, isDizaynCommand);

		HuquqsunaslıqCommand = new RelayCommand(isHuquqsunaslıqCommandOkey, isHuquqsunaslıqCommand);

		TehsilCommand = new RelayCommand(isTehsilCommandOkey, isTehsilCommand);

		SenayiCommand = new RelayCommand(isSenayiCommandOkey, isSenayiCommand);

		XidmetCommand = new RelayCommand(isXidmetCommandOkey, isXidmetCommand);

		TibbCommand = new RelayCommand(isTibbCommandOkey, isTibbCommand);

		MuxtelifCommand = new RelayCommand(isMuxtelifCommandOkey, isMuxtelifCommand);

		HaqqindaCommand = new RelayCommand(isHaqqindaOkey, isHaqqindaCommand);



	}
	public void ElanYerlestir(object? obj)
	{
		AllDatabases.RefseshAllModels();

		Frame? frame = obj as Frame;

		if( frame is not null )
		{
			IsElaniYerlesdirPage page = new IsElaniYerlesdirPage();
			frame.Content = page;
			
		}
		
	}

	public bool is_IsElanVerBtn(object? obj)
	{

		return true;
	}


	public void IsElanVerBtnOkey(object? obj)
	{
		AllDatabases.RefseshAllModels();
		
		check = true;

		Frame? frame = obj as Frame;

		if( frame is not null )
		{
			StartMainPage page = new StartMainPage();
			frame.Content = page;
		}

	}



	public bool isIsAxtarTrue(object? obj) { return true; }
	public void isIsAxtarOkay(object? obj)
	{
		AllDatabases.RefseshAllModels();
		check = false;

		Frame? frame = obj as Frame;

		if( frame is not null )
		{
			IsAxtaranlarView page = new IsAxtaranlarView();
			frame.Content = page;
		}

	}


	public bool isMaliyyeCommand(object? obj) { return true; }
	public void isMaliyyeCommandOkey(object? obj)
	{

		AllDatabases.SelectedItems("Maliyye",check);


	}


	public bool isMarketingCommand(object? obj) { return true; }
	public void isMarketingCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Marketing",check);

	}


	public bool isInformasiyaCommand(object? obj) { return true; }
	public void isInformasiyaCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Informasiya Texnologiyalari", check);
	}


	public bool isInzibatiCommand(object? obj) { return true; }
	public void isInzibatiCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Inzibati", check);

	}


	public bool isSatısCommand(object? obj) { return true; }
	public void isSatısCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Satis", check);

	}


	public bool isDizaynCommand(object? obj) { return true; }
	public void isDizaynCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Dizayn", check);

	}


	public bool isHuquqsunaslıqCommand(object? obj) { return true; }
	public void isHuquqsunaslıqCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Huquqsunas", check);

	}


	public bool isTehsilCommand(object? obj) { return true; }

	public void isTehsilCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Tehsil ve Elm", check);

	}


	public bool isSenayiCommand(object? obj) { return true; }
	public void isSenayiCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Senayi ve kent tesserrufati", check);

	}


	public bool isXidmetCommand(object? obj) { return true; }
	public void isXidmetCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Xidmet", check);

	}


	public bool isTibbCommand(object? obj) { return true; }
	public void isTibbCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Tibb ve Ezzaciliq", check);

	}


	public bool isMuxtelifCommand(object? obj) { return true; }
	public void isMuxtelifCommandOkey(object? obj)
	{
		AllDatabases.SelectedItems("Muxtelif", check);

	}


	public bool isHaqqindaCommand(object? obj) { return true; }
	public void isHaqqindaOkey(object? obj)
	{

		Button? btn = obj as Button;

		if( btn is not null )
		{
			if( btn!.DataContext is Recruiter )
			{
				Recruiter? selectbtn = btn.DataContext as Recruiter;

				AboutRecruiterWindow aboutRecruiterWindow = new AboutRecruiterWindow();

				AboutRecruiterWindowModel.recruiter1 = new Recruiter(selectbtn.Email, selectbtn.Telefon, selectbtn.Kategoriya, selectbtn.Vezife,
					 selectbtn.Seher, selectbtn.Sirket_Adi, selectbtn.Elaqeder_Sexs, selectbtn.Tehsil, selectbtn.Is_Tecrubesi,
					selectbtn.Maas_Min, selectbtn.Maas_Max, selectbtn.Yas_Min, selectbtn.Yas_Max, selectbtn.Maas);
				aboutRecruiterWindow.ShowDialog();
			}

			else if( btn!.DataContext is Employee )
			{
				Employee? selectbtn = btn.DataContext as Employee;

				AboutEmployeeWindow aboutEmployeeWindow = new AboutEmployeeWindow();

				AboutEmployeeWindowModel.employee1 = new Employee(selectbtn.Ad, selectbtn.Soyad, selectbtn.Ata_Adi, selectbtn.Cinsi, selectbtn.Tehsil,
					selectbtn.Is_tecrubesi, selectbtn.Seher, selectbtn.Email, selectbtn.Telefon, selectbtn.Kategoriya, selectbtn.Yas, selectbtn.Maas);

				aboutEmployeeWindow.ShowDialog();
			}
		}

	}
	public bool IsAxtarCommandTrue(object? obj)
	{
		if( !string.IsNullOrEmpty(Kategoriya) && !string.IsNullOrEmpty(Maas_min) && !string.IsNullOrEmpty(Maas_max) )
		{
			return true;
		}
		return false;
	}

	public void IsAxtarCommand(object? obj)
	{
		AllDatabases.SearchAdvert(Kategoriya, Maas_min, Maas_max, check);
	}


	public void CtreateSalary()
	{
		Salary = new List<string>();
		for( int i = 200; i <= 3000; )
		{
			if( i < 1000 )
				i += 100;
			else if( i >= 1000 )
				i += 200;

			Salary.Add(i.ToString());

		}
	}

	public void CreateCategory()
	{
		Category = new List<string>()
		{
			"Maliyye","Marketing","Informasiya Texnologiyalari",
			"Inzibati","Satis","Dizayn","Huquqsunans","Tehsil ve Elm",
			"Senayi ve kent tesserrufati","Xidmet","Tibb ved Ezzaciliq","Muxtelif"
		};
	}








}
