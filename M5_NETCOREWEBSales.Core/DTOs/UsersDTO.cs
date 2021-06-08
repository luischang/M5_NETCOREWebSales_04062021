using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_NETCOREWEBSales.Core.DTOs
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }

    }

    public class UsersAuthDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}