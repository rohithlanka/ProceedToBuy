using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProceedToBuyService.Models;

namespace ProceedToBuyService.Repository
{
    public interface IProceedToBuyRepository
    {
        public IEnumerable<Wishlist> addToWishlist(Wishlist entity);
       // public Cart addToCart(Cart entity);
    }
}
