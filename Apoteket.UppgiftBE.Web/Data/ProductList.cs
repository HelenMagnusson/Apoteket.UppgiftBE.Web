using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Apoteket.UppgiftBE.Web.Models;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using Newtonsoft;
using Newtonsoft.Json;
using Apoteket.UppgiftBE.Web.Repositories;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Apoteket.UppgiftBE.Web.Data
{
    public interface IProductList
    {
        IReadOnlyList<Product> Get();
    }

    public class ProductList : IProductList
    {
        IReadOnlyList<Product> _products;
        private ApotekContext db = new ApotekContext();
        public ProductList()
        {
            // Check database for any products, if there is none call api
            if (!CheckDbForAnyItems())
            {
                // Hämta produktlistan med hjälp av RestSharp och lagra i Products
                // Observera att listan ändras en gång per timme
                GetProductsFromAPI();

            }

        }

        private bool CheckDbForAnyItems()
        {
            return db.Products.Any<Product>();
        }

        private void GetProductsFromAPI()
        {
            _products = new List<Product>();

            var client = new RestSharp.RestClient("https://apoteket-be.azurewebsites.net");
            client.ClearHandlers();
            var jsonDeserializer = new JsonDeserializer();
            client.AddHandler("application/json", jsonDeserializer);

            var request = new RestSharp.RestRequest("/api/products", RestSharp.Method.GET);
            request.AddHeader("X-key", "qwerty");
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Failed to get list");
            }
            else
            {
                _products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
                AddToDb(_products);
            }
        }

        private void AddToDb(IReadOnlyList<Product> products)
        {
            //delete all rows in Product table
            //db.Products.SqlQuery("TRUNCATE TABLE Product");
            //db.SaveChanges();
            foreach (Product p in products)
            {
                //Check if there is any nulls or empty strings in product, if there is go to next product
                if (p.Id is null) continue;
                if (p.Id.ToString() == "") continue;

                if (string.IsNullOrEmpty(p.Name)) continue;

                if (p.Price is null) continue;
                if (p.Price.ToString() == "") continue;

                //Update db if product is ok
                db.Products.Add(p);
            }
            db.SaveChanges();

        }

        public IReadOnlyList<Product> Get() => _products;
    }


}