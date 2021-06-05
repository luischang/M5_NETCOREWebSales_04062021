using M5_NETCOREWEBSales.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace M5_NETCOREWEBSales.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> DeleteCustomer(int id);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task InsertCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
    }
}