using AngApp.Model;
using AngApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngApp.Repository
{
    public class CustomerRepository
    {
        AngAppContext _Context;

        public CustomerRepository(AngAppContext appContext)
        {
            _Context = appContext;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> obj = _Context.Customers.ToList();
            return obj;
                        
                      
        }

        public List<State> GetStates()
        {
            return _Context.States.OrderBy(s => s.Name).ToList();
        }

        public IQueryable<CustomerSummary> GetCustomersSummary(out int totalRecords)
        {
            var query = _Context.Customers
               .Include("States")
               .OrderBy(c => c.LastName);

            totalRecords = query.Count();

            return query.Select(c => new CustomerSummary
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                City = c.City,
                State = c.State,
                OrderCount = c.Orders.Count(),
                Gender = c.Gender
            }).AsQueryable();
        }

        public OperationStatus CheckUnique(int id, string property, string value)
        {
            switch (property.ToLower())
            {
                case "email":
                    var unique = !_Context.Customers.Any(c => c.Id != id && c.Email == value);
                    return new OperationStatus { Status = unique };
                default:
                    return new OperationStatus();
            }
        }

        public Customer GetCustomerById(int id)
        {
            return _Context.Customers
                    .Include("Orders")
                    .Include("State")
                    .SingleOrDefault(c => c.Id == id);
        }

        public OperationStatus InsertCustomer(Customer customer)
        {
            var opStatus = new OperationStatus { Status = true };
            try
            {
                _Context.Customers.Add(customer);
                _Context.SaveChanges();
            }
            catch (Exception exp)
            {
                opStatus.Status = false;
                opStatus.ExceptionMessage = exp.Message;
            }
            return opStatus;
        }

      

        public OperationStatus DeleteCustomer(int id)
        {
            var opStatus = new OperationStatus { Status = true };
            try
            {
                var cust = _Context.Customers.SingleOrDefault(c => c.Id == id);
                if (cust != null)
                {
                    _Context.Customers.Remove(cust);
                    _Context.SaveChanges();
                }
                else
                {
                    opStatus.Status = false;
                    opStatus.ExceptionMessage = "Customer not found";
                }
            }
            catch (Exception exp)
            {
                opStatus.Status = false;
                opStatus.ExceptionMessage = exp.Message;
            }
            return opStatus;
        }
    }
}