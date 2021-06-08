using M5_NETCOREWEBSales.Core.Enttites;
using System.Threading.Tasks;

namespace M5_NETCOREWEBSales.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> Authentication(string userName, string password);
    }
}