using AuthJwtbearer.Models;
using System.Threading.Tasks;

namespace AuthJwtbearer.Inteface
{
    public interface IUserRepository
    {
        Task<User> LoginAsync(string username, string password);
    }
}
