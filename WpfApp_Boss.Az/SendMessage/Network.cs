using System.Net.Mail;
using System.Net;
using System.Windows.Controls;
using WpfApp_Boss.Az.Models.Employee_Model;
using System.Windows;
using WpfApp_Boss.Az.ViewModels;

namespace WpfApp_Boss.Az.SendMessage;

public class MyNetwork
{

	public static int Send_Message(string mail)
	{
		Random rand = new Random();

		int num = rand.Next(10000, 50000);

		string frame = ( $@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <title>Your Page Title</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f8f9fa;
        }}
        header {{
            background-color: #FFFF00;
            color: #000;
            width: 400px;
            padding: 40px;
            margin: auto;
            height: 200px;
            text-align: center;
        }}
   </style>
    

</head>
<body>
    <header>
        <h1>BOSS.AZ</h1>
    	<p>Valid for 5 minutes.</p>
        <h2>Verification Code</h2>
{Convert.ToString(num)}
    </header>

</body>
</html>
" );

		MailMessage message = new MailMessage();
		message.From = new MailAddress("seymur.quliyev.2015@gmail.com");
		message.To.Add(mail);
		message.Subject = "Boss.Az";
		message.Body = frame;
		message.IsBodyHtml = true;

		SmtpClient sms = new SmtpClient();
		sms.Port = 587;
		sms.Host = "smtp.gmail.com";
		sms.EnableSsl = true;
		sms.Credentials = new NetworkCredential("seymur.quliyev.2015@gmail.com", "uxrg uobx amzu pajx");
		sms.Send(message);
        VerificationCodeViewModel.Code = Convert.ToString(num);

		return num;

	}

	//#################################################################################################################
	public static bool Send_Message(string mail, string my_information)
	{
		MailMessage message = new MailMessage();
		message.From = new MailAddress("seymur.quliyev.2015@gmail.com");
		message.To.Add(mail);
		message.Subject = "Boss.Az";
		message.Body = my_information + "  Sizin Elan ile Maraglanir";
		message.IsBodyHtml = true;


		SmtpClient sms = new SmtpClient();
		sms.Port = 587;
		sms.Host = "smtp.gmail.com";
		sms.EnableSsl = true;
		sms.Credentials = new NetworkCredential("seymur.quliyev.2015@gmail.com", "uxrg uobx amzu pajx");
		sms.Send(message);

		return true;

	}

	public static void Send_Message(Employee list, string mail)
	{

		string info = ( $@"<!DOCTYPE html>
<html>
<head>
<style>
table {{font - family: arial, sans-serif;
  border-collapse: collapse;
  width: 120%;

		}}
td {{border: 2px solid #dddddd;
  text-align: left;
  padding: 12px;
}}


 th {{border: 2px solid #dddddd;
  text-align: left;
  padding: 12px;
}}

tr:nth-child(even) {{background - color: #dddddd;
}}
</style>
</head>
<body>

<h2>CV</h2>

<table>
  <tr>
    <th>Umumi Melumat</th>
   
  </tr>
  <tr>
    <td>AD</td>
    <td>{list.Ad}</td>
    
  </tr>
  <tr>
    <td>Soyad</td>
    <td>{list.Soyad}</td>
    
  </tr>
  <tr>
    <td>Yas</td>
    <td>{list.Ata_Adi}</td>
    
  </tr>
  <tr>
    <td>Telefon</td>
    <td>{list.Telefon}</td>
    
  </tr>
  <tr>
    <td>Mail</td>
    <td>{list.Email}</td>
    
  </tr>
  <tr>
    <td>Ixtisas</td>
    <td>{list.Cinsi}</td>
    
  </tr>
  
  
    <tr>
    <td>Mekteb</td>
    <td>{list.Kategoriya}</td>
    
  </tr>
  
    <tr>
    <td>Uni Bali</td>
    <td>{list.Seher}</td>
    
  </tr>
  
    <tr>
    <td>Diplom</td>
    <td>{list.Is_tecrubesi}</td>
    
  </tr>
  
    <tr>
    <td>Xarici Diller</td>
    <td>{list.Seher}</td>
    

  </tr>
</table>

</body>
</html>

" );



		MailMessage message = new MailMessage();
		message.From = new MailAddress("seymur.quliyev.2015@gmail.com");
		message.To.Add(mail);
		message.Subject = "Boss.Az";
		message.Body = info;
		message.IsBodyHtml = true;


		SmtpClient sms = new SmtpClient();
		sms.Port = 587;
		sms.Host = "smtp.gmail.com";
		sms.EnableSsl = true;
		sms.Credentials = new NetworkCredential("seymur.quliyev.2015@gmail.com", "uxrg uobx amzu pajx");
		sms.Send(message);

	}
}

