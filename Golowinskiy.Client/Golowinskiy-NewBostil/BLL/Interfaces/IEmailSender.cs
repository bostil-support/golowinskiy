using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.BLL.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
