using AuthJwtbearer.Data;
using AuthJwtbearer.Inteface;
using AuthJwtbearer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJwtbearer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> LoginAsync(string username, string password)
        {
           var user = await  _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return user;
        }
    }
}
