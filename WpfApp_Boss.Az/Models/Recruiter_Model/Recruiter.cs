using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using WpfApp_Boss.Az.MyPropertyChanged;
using WpfApp_Boss.Az.Commands;
using System.Windows.Controls;
using WpfApp_Boss.Az.DataBase;

namespace WpfApp_Boss.Az.Models.Recruiter_Model;

public class Recruiter: BasePropertyChanged 
{
	private string? email;
	private string? telefon;
	private string? kategoriya;
	private string? vezife;
	private string? seher;
	private string? sirket_Adi;
	private string? elaqeder_Sexs;
	private string? tehsil;
	private string? ıs_Tecrubesi;
	private string? maas_Min;
	private string? maas_Max;
	private string? yas_Min;
	private string? yas_Max;
	private string? maas;
	private string? yas;


	public string? Email { get => email; set { email = value; OnPropertyChanged(); } }
	public string? Telefon { get => telefon; set { telefon = value; OnPropertyChanged(); } }
	public string? Kategoriya { get => kategoriya; set { kategoriya = value; OnPropertyChanged(); } }
	public string? Vezife { get => vezife; set { vezife = value; OnPropertyChanged(); } }
	public string? Seher { get => seher; set { seher = value; OnPropertyChanged(); } }
	public string? Sirket_Adi { get => sirket_Adi; set { sirket_Adi = value; OnPropertyChanged(); } }
	public string? Elaqeder_Sexs { get => elaqeder_Sexs; set { elaqeder_Sexs = value;OnPropertyChanged(); } }
	public string? Tehsil { get => tehsil; set { tehsil = value; OnPropertyChanged(); } }
	public string? Is_Tecrubesi { get => ıs_Tecrubesi; set { ıs_Tecrubesi = value; OnPropertyChanged(); } }
	public string? Maas_Min { get => maas_Min; set { maas_Min = value; OnPropertyChanged(); } }

	public string? Maas_Max { get => maas_Max; set { maas_Max = value; Maas = Maas_Min + " - " + Maas_Max + " AZN"; OnPropertyChanged(); } }

	public string? Yas_Min { get => yas_Min; set { yas_Min = value; OnPropertyChanged(); } }
	public string? Yas_Max { get => yas_Max; set { yas_Max = value; Yas = Yas_Min + " - " + Yas_Max; OnPropertyChanged(); } }
	public string? Maas { get => maas; set { maas = value; OnPropertyChanged(); } }
	public string? Yas { get => yas; set { yas = value;  OnPropertyChanged(); } }


	public Recruiter(string? email, string? telefon, string? kategoriya, string? vezife, string? seher, string? sirket_Adi, string? elaqeder_Sexs, string? tehsil, string? ıs_Tecrubesi, string? maas_Min, string? maas_Max, string? yas_Min, string? yas_Max, string? maas)
	{
		Email = email;
		Telefon = telefon;
		Kategoriya = kategoriya;
		Vezife = vezife;
		Seher = seher;
		Sirket_Adi = sirket_Adi;
		Elaqeder_Sexs = elaqeder_Sexs;
		Tehsil = tehsil;
		Is_Tecrubesi = ıs_Tecrubesi;
		Maas_Min = maas_Min;
		Maas_Max = maas_Max;
		Yas_Min = yas_Min;
		Yas_Max = yas_Max;

	}
    public Recruiter(string email)
    {
		Email = email;
	}

    public Recruiter() { }


}
