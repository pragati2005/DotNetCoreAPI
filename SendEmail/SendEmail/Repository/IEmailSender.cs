using SendEmail.Models;
using System.Threading.Tasks;

namespace SendEmail.Repository
{
    public interface IEmailSender
    {
        //void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}