using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_NETCOREWEBSales.Core.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

    }

    public class CustomerFullNameDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        

    }

    public class CustomerCityDTO
    {
        public int Id { get; set; }
        public string City { get; set; }

    }

    public class CustomerOrderDTO 
    {
        public CustomerFullNameDTO customer { get; set; }
        public List<OrderDTO> orders { get; set; }
    }



}
