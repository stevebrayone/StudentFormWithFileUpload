using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using System.Diagnostics;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;

namespace studentform.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("FromEmail"));
            email.To.Add(MailboxAddress.Parse("studysteve07@gmail.com"));
            email.Subject = "test email from scope India";

            email.Body = new TextPart(TextFormat.Plain) 
            { 
                Text = "<h1> scope insia example <h1>"
            };
             using var smtp=new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("stevebrayoneeb", "viql imag gtli oalf");
            smtp.Send(email);
            smtp.Disconnect(true);
            ViewBag.Message = "a mail has been snd successully";
            return View();
        }
        
    }
}
