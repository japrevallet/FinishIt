using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinishIt.Services
{
    public static class EmailService
    {
        public static void Send(string ToAdress, string Subject, string Body)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)  //You dont understand this well and you need to...
            {
                Credentials = new NetworkCredential("japrevallet@gmail.com","Fuckyoumicrosoft1}"),
                EnableSsl = true
            };
            client.Send("japrevallet@gmail.com", ToAdress, Subject, Body);  
        }
    }
}
