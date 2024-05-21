using System.Windows;
using WpfApp_Boss.Az.MyPropertyChanged;
using System.Collections.ObjectModel;
using WpfApp_Boss.Az.Models.Employee_Model;
using System.Windows.Input;
using WpfApp_Boss.Az.Commands;
using WpfApp_Boss.Az.DataBase;
using WpfApp_Boss.Az.Views;
using System.Windows.Controls;
using WpfApp_Boss.Az.Models.Recruiter_Model;
using System.Diagnostics.Metrics;

namespace WpfApp_Boss.Az.ViewModels;

public class CVPageViewModel: BasePropertyChanged
{

	public Employee? employee { get; set; }

	public Employee? Employees { get => employee; set { employee = value; OnPropertyChanged(); } }


	private List<string>? citis;

	private List<string>? ages;

	private List<string>? experience;

	private List<string>? education;	

	private List<string>? category;

	private List<string> vendor;

	private List<string> salary;

	public List<string>? Category { get => category; set { category = value; OnPropertyChanged(); } }

	public List<string>? Ages { get => ages; set { ages = value; OnPropertyChanged(); } }

	public List<string>? Education { get => education; set { education = value; OnPropertyChanged(); } }

	public List<string>? Experience { get => experience; set { experience = value; OnPropertyChanged(); } }

	public List<string>? Citis { get => citis; set { citis = value; OnPropertyChanged(); } }

	public List<string> Vendor { get => vendor; set { vendor = value; OnPropertyChanged(); } }
	public List<string> Salary { get => salary; set { salary = value; OnPropertyChanged(); } }





	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public ICommand ElanKecmekCommand { get; set; }

	public ICommand CvYerlestirCommand {  get; set; }

	public CVPageViewModel()	
    {
		Vendor = new List<string> { "Kisi", "Qadin" };
		Employees = new Employee();
		CvYerlestirCommand = new RelayCommand(isCvOkey,isCvOkeyTrue);
		ElanKecmekCommand = new RelayCommand(isCvElanKecmekOkey, isCvElanKecmekTrue);
		CtreateAge();
		CreateCity();
		CtreateSalary();
		CreateExperience();
		CreateEducation();
		CreateCategory();
	}
    public void CtreateAge()
	{
		Ages = new List<string>();
		for( int age = 18; age <= 65; age++ )
		{
			Ages.Add(age.ToString());
		}
	}

	public void CreateCity()
	{
		Citis = new List<string>()
		{
			"Baku","Ganja","Sumqayit","Lankaran","Mingachevir","Nakhchivan","Shaki",
			"Shirvan","Shamakhi","Quba","Yevlakh","Agdam","Agjabadi","Agstafa","Agsu","Astara",
			"Barda","Beylagan","Bilasuvar","Dashkasan","Fizuli","Gabala","Gobustan","Goranboy",
			"Goychay","Goygol","Haciqabul","Imishli","Ismayilli","Jabrayil"
		};
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

	public void CreateExperience()
	{
		Experience = new List<string>()
		{
			"1 iden asagi","1 - 3 qeder","3 - 5 qeder","5 iden artiq"
		};
	}

	public void CreateEducation()
	{
		Education = new List<string>()
		{
			"Elmi Derece","Ali Tehsil","Orta","Orta Texniki","Orta Xususi","Natamam Tetsil"
		};
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

	public bool isCvOkeyTrue(object? obj)
	{

		if(!string.IsNullOrEmpty(Employees!.Ad) && !string.IsNullOrEmpty(Employees.Soyad) && !string.IsNullOrEmpty(Employees.Ata_Adi) &&

			!string.IsNullOrEmpty(Employees.Cinsi) && !string.IsNullOrEmpty(Employees.Tehsil) && !string.IsNullOrEmpty(Employees.Is_tecrubesi) &&

			!string.IsNullOrEmpty(Employees.Email) && !string.IsNullOrEmpty(Employees.Seher) && !string.IsNullOrEmpty(Employees.Telefon) &&

			!string.IsNullOrEmpty(Employees.Kategoriya) && !string.IsNullOrEmpty(Employees.Yas) && !string.IsNullOrEmpty(Employees.Yas) )
			return true;

		return false;
	}

	public void isCvOkey(object? obj)
	{
		AllDatabases.AddNewEmployee(Employees!);
		AllDatabases.RefseshAllModels();
		Employees = new Employee();
	}


	public bool isCvElanKecmekTrue(object? obj)
	{
		return true;
	}

	public void isCvElanKecmekOkey(object? obj)
	{

		Page? page = obj as Page;

		if(page != null)
		{ 
			page.NavigationService?.Navigate(new IsElaniYerlesdirPage());
		}

	}
}
