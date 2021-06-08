using M5_NETCOREWEBSales.Core.Enttites;
using M5_NETCOREWEBSales.Core.Interfaces;
using M5_NETCOREWEBSales.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace M5_NETCOREWEBSales.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        private readonly SalesContext _context;

        public UsersRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Users> Authentication(string userName, string password)
        {
            var user = await _context.Users.Where(x => x.Username == userName && x.Password == password).FirstOrDefaultAsync();
            return user;

        }


    }
}
