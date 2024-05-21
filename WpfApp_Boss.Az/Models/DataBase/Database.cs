using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using WpfApp_Boss.Az.Models.Employee_Model;
using WpfApp_Boss.Az.Models.Recruiter_Model;
using WpfApp_Boss.Az.MyPropertyChanged;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.DataBase;

public class AllDatabases : BasePropertyChanged
{

	public static ObservableCollection<Recruiter>? Recruiters { get; set; } = new ObservableCollection<Recruiter>();

	public static ObservableCollection<Employee>? Employees { get; set; } = new ObservableCollection<Employee>();


	public static ObservableCollection<Recruiter>? SelecktedRecruiters { get; set; } = new ObservableCollection<Recruiter>();

	public static ObservableCollection<Employee>? SelecktedEmployees { get; set; } = new ObservableCollection<Employee>();


	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	static AllDatabases()	
	{
		Read_Json_Data();
		
	}

	public static void Write_Json_data<T>(T list, string file)
	{
		try
		{
			var write = new JsonSerializerOptions { WriteIndented = true };
			string json_file = JsonSerializer.Serialize(list, write);
			File.WriteAllText(file, json_file);

		}
		catch( Exception ex )
		{
			MessageBox.Show($"WriteJsonData has a problem {ex.Message}");
		}


	}

	public static void Read_Json_Data()
	{

		string data = File.ReadAllText("IsVerenler.json");

		Recruiters = JsonSerializer.Deserialize<ObservableCollection<Recruiter>>(data);


		string data_1 = File.ReadAllText("IsAxtaranlar.json");

		Employees = JsonSerializer.Deserialize<ObservableCollection<Employee>>(data_1);

	}




	public static void SelectedItems(string category,bool check)
	{
		if(check)
		{
			foreach( var item in Recruiters! )
			{
				if( item.Kategoriya == category )
					SelecktedRecruiters!.Add(item);

			}
			Recruiters.Clear();
			foreach( var item in SelecktedRecruiters! )
			{
				Recruiters.Add(item);
			}
			SelecktedRecruiters.Clear();

		}
		else
		{
			foreach( var item in Employees! )
			{
				if( item.Kategoriya == category )
					SelecktedEmployees!.Add(item);

			}

			Employees.Clear();
			foreach( var item in SelecktedEmployees! )
			{
				Employees.Add(item);
			}
			SelecktedEmployees.Clear();

		}
	}


	public static void RefseshAllModels()
	{
		Read_Json_Data();

	}


	public static void AddNewEmployee(Employee emp)
	{
		Employees.Add(emp);
		Write_Json_data< ObservableCollection<Employee>>(Employees, "IsAxtaranlar.json");
	}


	public static void AddNewRecruiter(Recruiter recruiter)
	{
		Recruiters.Add(recruiter);
		Write_Json_data<ObservableCollection<Recruiter>>(Recruiters, "IsVerenler.json");
	}


	public static void SearchAdvert(string kategoriya,string maas_min, string maas_max,bool check)
	{
		if(check)
		{
			foreach( var item in Recruiters! )
			{
				if( item.Kategoriya == kategoriya && Convert.ToInt32(item.Maas_Min) >= Convert.ToInt32(maas_min)  && Convert.ToInt32(item.Maas_Max) <= Convert.ToInt32(maas_max))
					SelecktedRecruiters!.Add(item);

			}
			Recruiters.Clear();
			foreach( var item in SelecktedRecruiters! )
			{
				Recruiters.Add(item);
			}
			SelecktedRecruiters.Clear();
		}

		else
		{
			foreach( var item in Employees! )
			{
				string? maas = item.Maas!.Substring(0, item.Maas.IndexOf(" "));
				if( item.Kategoriya == kategoriya && 
					Convert.ToInt32(maas) >= Convert.ToInt32(maas_min) && 
					Convert.ToInt32(maas) <= Convert.ToInt32(maas_max) ) 
					SelecktedEmployees!.Add(item);

			}

			Employees.Clear();
			foreach( var item in SelecktedEmployees! )
			{
				Employees.Add(item);
			}
			SelecktedEmployees.Clear();

		}
	}






}	
