using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProceedToBuyService.Models;

namespace ProceedToBuyService.Repository
{
    public class ProceedToBuyRepository : IProceedToBuyRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyRepository));

        private List<Wishlist> Wlist;
        private List<Cart> Clist;
        private Vendor vendor = new Vendor { VendorId = 1, VendorName = "John", DeliveryCharge = 150  , Rating=9};
        public ProceedToBuyRepository()
        {
            Wlist = new List<Wishlist>() {
            new Wishlist { VendorId = 1, ProductId = 1, Quantity = 2, DateAddedToWishlist = DateTime.Parse("2021-09-03") } ,
            new Wishlist { VendorId = 2, ProductId = 2, Quantity = 1, DateAddedToWishlist = DateTime.Parse("2021-01-01") } ,
            new Wishlist { VendorId = 1, ProductId = 3, Quantity = 4, DateAddedToWishlist = DateTime.Parse("2020-12-12") } 
            };

            Clist = new List<Cart>() { 
            new Cart { CartId=1 ,ProductId=1 ,Zipcode=533048 ,DeliveryDate = DateTime.Parse("2021-09-03") ,VendorObj=vendor} ,
            new Cart {CartId=2  ,ProductId=1 ,Zipcode=533296 ,DeliveryDate = DateTime.Parse("2020-12-28") ,VendorObj=vendor} ,
            new Cart {CartId=3  ,ProductId=2 ,Zipcode=533047 ,DeliveryDate = DateTime.Parse("2021-01-05") ,VendorObj=vendor} ,
            new Cart {CartId=2  ,ProductId=2 ,Zipcode=533207 ,DeliveryDate = DateTime.Parse("2021-02-15") ,VendorObj=vendor}

            };
        }
        //public Cart addToCart(Cart entity)
        //{
        //    try
        //    {
        //        Clist.Add(entity);
        //        _log4net.Info("Item Added to Cart");
        //        return Clist;
        //    }
        //    catch
        //    {
        //        _log4net.Info("Item not Added to Cart");
        //        return null;
        //    }
           
        //}

        public IEnumerable<Wishlist> addToWishlist(Wishlist entity)
        {
            try
            {
                Wlist.Add(entity);
                _log4net.Info("Item Added to Wishlist");
                return Wlist;
            }
            catch
            {
                _log4net.Info("Item not Added to Wishlist");
                return null;
            }
        }
    }
}
