using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProceedToBuyService.Models;
using ProceedToBuyService.Repository;

namespace ProceedToBuyService.Provider
{
    public class ProceedToBuyProvider : IProceedToBuyProvider
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyProvider));

        private readonly IProceedToBuyRepository proceedToBuyRepository;
        public ProceedToBuyProvider(IProceedToBuyRepository repo)
        {
            proceedToBuyRepository = repo;
        }
        public bool Add(Wishlist entity)
        {
            try
            {
                _log4net.Info("Add To Wishlist Repository initiated");
                var result = proceedToBuyRepository.addToWishlist(entity);
                if(result ==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                _log4net.Info("Error in calling Wishlist Repository");
                return false;
            }
                

        }
        //  return proceedToBuyRepository.addToCart(entity);

        public async Task<CartDto> GetSupply(int prodid,int custid,int zipcode,DateTime delidt)
        {

            var client = new HttpClient();
            
                //client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage response = await client.GetAsync("api/Vendor/GetVendorDetails/"+ProductId);
                client.BaseAddress = new Uri("https://localhost:44388/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Vendor/GetVendorDetails/" + prodid);
                
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //var value = response.Content.ReadAsStringAsync().Result;

                    List<VendorDto> vendorsdto = JsonConvert.DeserializeObject<List<VendorDto>>(apiResponse);
            int max = 0;
            VendorDto tagged=vendorsdto.FirstOrDefault();
            foreach(VendorDto v in vendorsdto)
            {
                if(v.Rating>=max)
                {
                    max = v.Rating;
                    tagged = v;
                }
            }
            Random unid = new Random();
            CartDto finalcart = new CartDto()
            {
                CartId = unid.Next(1, 999),
                CustomerId = custid,
                ProductId = prodid,
                Zipcode = zipcode,
                DeliveryDate = delidt,
                VendorObj = tagged,
            };
            return finalcart;
                
            


        }
    }
}
