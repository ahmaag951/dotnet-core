using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace send_email_gmail_smtp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                // create a gamail, and then go to this url https://www.google.com/settings/u/1/security/lesssecureapps
                // and Allow less secure apps: ON
                Credentials = new NetworkCredential("ahmaag951@gmail.com", "ThePassword")
            };

            client.Send("ahmaag951@gmail.com", "ahmaag951@gmail.com", "test subject", "test body");

            return "Sent";
        }

    }
}
