using System.Collections.ObjectModel;
using WpfApp_Boss.Az.MyPropertyChanged;

namespace WpfApp_Boss.Az.Models.Employee_Model;

public class Employee : BasePropertyChanged
{
	private string? ad;
	private string? soyad;
	private string? ata_Adi;
	private string? cinsi;
	private string? tehsil;
	private string? ıs_tecrubesi;
	private string? seher;
	private string? email;
	private string? telefon;
	private string? kategoriya;
	private string? yas;
	private string? maas;



	public string? Ad { get => ad; set { ad = value; OnPropertyChanged(); } }
	public string? Soyad { get => soyad; set { soyad = value; OnPropertyChanged(); } }
	public string? Ata_Adi { get => ata_Adi; set { ata_Adi = value; OnPropertyChanged(); } }
	public string? Cinsi { get => cinsi; set { cinsi = value; OnPropertyChanged(); } }
	public string? Tehsil { get => tehsil; set { tehsil = value; OnPropertyChanged(); } }
	public string? Is_tecrubesi { get => ıs_tecrubesi; set { ıs_tecrubesi = value; OnPropertyChanged(); } }
	public string? Seher { get => seher; set { seher = value; OnPropertyChanged(); } }
	public string? Email { get => email; set { email = value; OnPropertyChanged(); } }
	public string? Telefon { get => telefon; set { telefon = value; OnPropertyChanged(); } }
	public string? Kategoriya { get => kategoriya; set { kategoriya = value; OnPropertyChanged(); } }
	public string? Yas { get => yas; set { yas = value; OnPropertyChanged(); } }
	public string? Maas
	{
		get => maas;
		set
		{
			if( value!.EndsWith(" AZN") )
				maas = value;
			else
				maas = value + " AZN";

			OnPropertyChanged();
		}
	}


	public Employee() { }


	public Employee(string? ad, string? soyad, string? ata_Adi, string? cinsi, string? tehsil, string? ıs_tecrubesi, string? seher, string? email, string? telefon, string? kategoriya, string yas, string? maas)
	{
		Ad = ad;
		Soyad = soyad;
		Ata_Adi = ata_Adi;
		Cinsi = cinsi;
		Tehsil = tehsil;
		Is_tecrubesi = ıs_tecrubesi;
		Seher = seher;
		Email = email;
		Telefon = telefon;
		Kategoriya = kategoriya;
		Yas = yas;
		Maas = maas;
	}



}
