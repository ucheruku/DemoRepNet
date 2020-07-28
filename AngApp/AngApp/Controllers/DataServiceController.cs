using AngApp.Model;
using AngApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace AngApp.Controllers
{
    [Route("api/[controller]")]
    public class DataServiceController : Controller
    {
        CustomerRepository _Repository;
        //private readonly AngAppContext _context;
        //public DataServiceController(AngAppContext context)
        //{
        //    _Repository = new CustomerRepository(context);
        //}

        [HttpGet("[action]")]
        public List<Customer> GetCustomers()
        {
            List<Customer> objlist = new List<Customer>();
            objlist.Add(new Customer() { Id = 1, FirstName = "dhjdshsdd", LastName = "uihfgkhdfkhgkdf" });
            objlist.Add(new Customer() { Id = 2, FirstName = "mmmmmjusdjdsjf", LastName = "ppppfodgjdfj" });
            return objlist;
           
        }

        [HttpGet("[action]")]
        public List<State> States()
        {
            return _Repository.GetStates();
            
        }

       

      
    }
}