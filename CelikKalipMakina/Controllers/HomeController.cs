using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using CelikKalipMakina.Models;
using System.Text;

namespace CelikKalipMakina.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MailIndex(Contact contact)
        {
            StringBuilder body = new StringBuilder();
            body.AppendLine("<table border = '1' >");
            body.AppendLine("<tr><td>Adi Soyadi:</td><td>"+contact.AdiSoyadi+" </td></tr>");
            body.AppendLine("<tr><td>Mail:</td><td>"+contact.EMail+"</td></tr>");
            body.AppendLine("<tr><td>Telefon:</td><td>" + contact.Telefon + "</td></tr>");
            body.AppendLine("<tr><td>Konu:</td><td>" + contact.Konu + "</td></tr>");
            body.AppendLine("<tr><td>Mesaj:</td><td>" + contact.Mesaj + "</td></tr>");
            body.AppendLine("</table >");

            MailGonder(body.ToString());
            return Json(new {Success=true,Message="Mail Gönderimi Başarılı" });
        }

        public void MailGonder(string body)
        {
            string fromAdress = System.Web.Configuration.WebConfigurationManager.AppSettings["fromMailAdresi"];
            string mailSifre = System.Web.Configuration.WebConfigurationManager.AppSettings["mailSifre"];
            string toAdress = System.Web.Configuration.WebConfigurationManager.AppSettings["toMailAdresi"]; 
            const string subject = "celikkalipmakina.com'dan gelen mesaj";

            MailMessage mail = new MailMessage(); //yeni bir mail nesnesi Oluşturuldu.
            mail.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
            mail.To.Add(toAdress); //Kime mail gönderilecek.

            //mail kimden geliyor, hangi ifade görünsün?
            mail.From = new MailAddress(fromAdress, subject, System.Text.Encoding.UTF8);
            mail.Subject = subject;//mailin konusu

            //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smp = new SmtpClient();

            //mailin gönderileceği adres ve şifresi
            smp.Credentials = new NetworkCredential(fromAdress, mailSifre);
            smp.Port = 587;
            smp.Host = "smtp.gmail.com";//gmail üzerinden gönderiliyor.
            smp.EnableSsl = true;
            smp.Send(mail);
            //mail isimli mail gönderiliyor.
            //string fromAdress = System.Web.Configuration.WebConfigurationManager.AppSettings["fromMailAdresi"];
            //string mailSifre = System.Web.Configuration.WebConfigurationManager.AppSettings["mailSifre"];
            //string toAdress = System.Web.Configuration.WebConfigurationManager.AppSettings["toMailAdresi"]; 
            //const string subject = "celikkalipmakina.com'dan gelen mesaj";
            //try
            //{
            //    using (var smtp = new SmtpClient
            //    {
            //        Host = "smtp.live.com",
            //        Port = 465,
            //        EnableSsl = true,
            //        DeliveryMethod = SmtpDeliveryMethod.Network,
            //        UseDefaultCredentials = false,
            //        Credentials = new NetworkCredential(fromAdress, mailSifre)
            //    })
            //    {
            //        using (var message = new MailMessage(fromAdress, toAdress) { Subject = subject, Body = body })
            //        {
            //            smtp.Send(message);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.ToString());
            //}

        }
    }
}