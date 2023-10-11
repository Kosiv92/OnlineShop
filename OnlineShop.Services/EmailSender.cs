using Microsoft.AspNetCore.Identity.UI.Services;

namespace OnlineShop.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //TODO Реализовать сервис отправки email сообщений
            await Task.CompletedTask;
        }
    }
}
