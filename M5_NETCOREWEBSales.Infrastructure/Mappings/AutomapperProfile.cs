using AutoMapper;
using M5_NETCOREWEBSales.Core.DTOs;
using M5_NETCOREWEBSales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5_NETCOREWEBSales.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();



        }
        




    }
}
