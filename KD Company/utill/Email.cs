﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace KD_Company.utill
{
    public class Email
    {
        public string SendEmail(string toAddress)
        {
            Random rn = new Random();
            int pass = rn.Next(100000);
            string Passd = pass.ToString();


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.UseDefaultCredentials = true;
            mail.From = new MailAddress("onlinerentingapp@gmail.com"); // From

            mail.To.Add(toAddress);// To
            mail.Subject = "Registration Completed";
            mail.Body = "Thanks For Registering" +
                "your password:"+Passd; 


           
            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment("Test.txt");
            //mail.Attachments.Add(attachment);



            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("onlinerentingapp@gmail.com", "Autogreen");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return Passd;
        }
    }
}
