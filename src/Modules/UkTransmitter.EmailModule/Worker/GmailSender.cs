using System;
using UkTransmitter.EmailModule.Service;

namespace UkSender.EmailAPI.EmailSenders
{
    internal sealed class GmailSender
    {
        //private Action _sendEmailAction;
        //private EmailService _gmailApiService;

        //public GmailSender()
        //{
        //    _gmailApiService = GmailController.GetService();
        //    _sendEmailAction = SendMessageAction;
        //}

        //public void SendMessageAndForget()
        //{
        //    Task.Run(_sendEmailAction);
        //}

        //private void SendMessageAction()
        //{
        //    Message message = new Message();
        //    var tempMail = GmailController.CreateMimeMessage();

        //    using (var stream = new MemoryStream())
        //    {
        //        tempMail.WriteTo(stream);

        //        var buffer = stream.ToArray();
        //        var base64 = Convert.ToBase64String(buffer)
        //            .Replace('+', '-')
        //            .Replace('/', '_')
        //            .Replace("=", "");

        //        message.Raw = base64;
        //    }

        //    _gmailApiService.Users.Messages.Send(message, GmailStaticConfiguration.HostAddress).Execute();
        //}
    }
}
