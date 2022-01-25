using System.Net;
using System.Web.Mvc;
using Apoteket.UppgiftBE.Web.Data;
using Apoteket.UppgiftBE.Web.ServiceReferenceCheckOut;


namespace Apoteket.UppgiftBE.Web.Controllers
{
    public class BasketController : Controller
    {
        private IBasket _basket;


        public BasketController(IBasket basket)
        {
            _basket = basket;
        }

        public ActionResult Index()
        {
            var model = _basket.GetProducts();
            return View(model);
        }

        public ActionResult Add(int id)
        {
            // Add item to basket
            _basket.AddProduct(id);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int id)
        {
            // Remove item from basket
            _basket.RemoveProduct(id);
            return RedirectToAction("Index", "Basket");
        }

        public ActionResult Checkout()
        {
            // Checka ut korgen och visa erhållet ordernummer

            OrderServiceClient client = new OrderServiceClient();

            // Use the 'client' variable to call operations on the service.
            

            // Always close the client.
            client.Close();

            throw new System.NotImplementedException();
        }


    }
}