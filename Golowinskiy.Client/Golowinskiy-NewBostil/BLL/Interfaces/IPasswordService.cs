using Golowinskiy_NewBostil.DAL.Entities;
using System.Threading.Tasks;

namespace Golowinskiy_NewBostil.BLL.Interfaces
{
    public interface IPasswordService
    {
        Task<User> RecoveryPassword(string Email);
    }
}
