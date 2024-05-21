using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_Boss.Az.Commands;
using WpfApp_Boss.Az.DataBase;
using WpfApp_Boss.Az.Models.Recruiter_Model;
using WpfApp_Boss.Az.MyPropertyChanged;
using WpfApp_Boss.Az.SendMessage;
using WpfApp_Boss.Az.Views;


namespace WpfApp_Boss.Az.ViewModels;

public class IsElaniYerlesdirPageModel : BasePropertyChanged
{
	private Recruiter? recruiter;
	public Recruiter? NewRecruiter { get => recruiter; set { recruiter = value; OnPropertyChanged(); } }

	private List<string>? citis;

	private List<string>? ages;

	private List<string>? experience;

	private List<string>? education;

	private List<string>? salary;

	private List<string>? category;


	public List<string>? Category { get => category; set { category = value; OnPropertyChanged(); } }

	public List<string>? Ages { get => ages; set { ages = value; OnPropertyChanged(); } }

	public List<string>? Education { get => education; set { education = value; OnPropertyChanged(); } }

	public List<string>? Experience { get => experience; set { experience = value; OnPropertyChanged(); } }

	public List<string>? Salary { get => salary; set { salary = value; OnPropertyChanged(); } }

	public List<string>? Citis { get => citis; set { citis = value; OnPropertyChanged(); } }

	
	public ICommand? DavamEtCommand { get; set; }
	public ICommand? IsElanYerlastircommand { get; set; }

	public IsElaniYerlesdirPageModel()
	{
		NewRecruiter = new Recruiter();
		DavamEtCommand = new RelayCommand(DavamEtCommandOkey, IsDavamEtCommand);
		IsElanYerlastircommand = new RelayCommand(Checkokey, iSCheck);

		CtreateAge();
		CtreateSalary();
		CreateCity();
		CreateExperience();
		CreateEducation();
		CreateCategory();

	}

	public bool IsDavamEtCommand(object? obj)
	{
		string phone_pettern = @"^(070|077|050|051|055|012|099)\s\d{3}\s\d{2}\s\d{2}";

		if(!string.IsNullOrEmpty(NewRecruiter!.Email) && !string.IsNullOrEmpty(NewRecruiter.Telefon) )
		{
			if( NewRecruiter.Email.EndsWith("@gmail.com") && NewRecruiter.Telefon.Length > 0 && Regex.IsMatch(NewRecruiter.Telefon, phone_pettern) )
				return true;
			
		}
		return false;
	}

	public void DavamEtCommandOkey(object? obj)
	{
		MyNetwork.Send_Message(NewRecruiter!.Email!);
		VerificationCodeView verification = new VerificationCodeView();
		verification.ShowDialog();

		Grid? grid = obj as Grid;
		grid.Opacity = 1;


	}

	public bool iSCheck(object? obj)
	{
		if(!string.IsNullOrEmpty(NewRecruiter.Email) && !string.IsNullOrEmpty(NewRecruiter.Telefon) && !string.IsNullOrEmpty(NewRecruiter.Kategoriya) &&
			!string.IsNullOrEmpty(NewRecruiter.Vezife) && !string.IsNullOrEmpty(NewRecruiter.Seher) && !string.IsNullOrEmpty(NewRecruiter.Sirket_Adi) &&
			!string.IsNullOrEmpty(NewRecruiter.Elaqeder_Sexs) && !string.IsNullOrEmpty(NewRecruiter.Tehsil) && !string.IsNullOrEmpty(NewRecruiter.Is_Tecrubesi) &&
			!string.IsNullOrEmpty(NewRecruiter.Maas_Min)  && !string.IsNullOrEmpty(NewRecruiter.Maas_Max) && !string.IsNullOrEmpty(NewRecruiter.Yas_Min) &&
			!string.IsNullOrEmpty(NewRecruiter.Yas_Max) && !string.IsNullOrEmpty(NewRecruiter.Maas) )

			return true;

		return false;

	}


	public void Checkokey(object? obj)
	{

		AllDatabases.AddNewRecruiter(NewRecruiter!);
		AllDatabases.RefseshAllModels();
		NewRecruiter = new Recruiter();

	}

	public void CtreateSalary()
	{
		Salary = new List<string>();
		for( int age = 300; age <= 6000; age+=100 )
		{
			Salary.Add(age.ToString());
		}
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
			"Inzibati","Satis","Dizayn","Huquqsunas","Tehsil ve Elm",
			"Senayi ve kent tesserrufati","Xidmet","Tibb ve Ezzaciliq","Muxtelif"
		};
	}

}
