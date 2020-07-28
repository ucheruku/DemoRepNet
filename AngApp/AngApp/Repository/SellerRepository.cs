
using AngApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngApp.Repository
{
    public class SellerRepository
    {
        AngAppContext _Context;
       
        //public SellerRepository()
        //{
        //    _Context = new AngAppContext();
        //}

       
        public List<Seller> GetSellers()
        {
            List<Seller> objSellerLst = new List<Seller>();
            objSellerLst = _Context.Sellers.ToList();
            return objSellerLst;
        }
    }
}