using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using VerticalLiftBSIAssignment.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;

namespace VerticalLiftBSIAssignment.Controllers
{
    public class ProductsController : Controller
    {
        Uri baseAddress = new Uri("http://fsesoportal.canadaeast.cloudapp.azure.com:8084/api");
        HttpClient client;


        public ProductsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }


        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/products").Result;
            if (responseMessage.IsSuccessStatusCode)
            {

                string data = responseMessage.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(data);

            }
            return View(products);


        }

        public ActionResult Dashboard()
        {
            List<Product> products = new List<Product>();
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/products").Result;
            if (responseMessage.IsSuccessStatusCode)
            {

                string data = responseMessage.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(data);

            }
            return View(products);


        }

        public ActionResult CreateProduct()
        {


            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress + "/Products/",content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult EditProduct(Guid id)
        {

            Product product = new Product();
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/products/"+id).Result;
            if (responseMessage.IsSuccessStatusCode)
            {

                string data = responseMessage.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(data);

            }
            return View("CreateProduct",product);
        }

        [HttpPatch]
        public ActionResult EditProduct(Product product )
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");


            HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress + "/Products/"+ product.id, content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");   
            }

            return View("CreateProduct", product);

        }

        public ActionResult ViewProduct(Guid id)    
        {

            Product product = new Product();
            HttpResponseMessage responseMessage = client.GetAsync(client.BaseAddress + "/products/" + id).Result;
            if (responseMessage.IsSuccessStatusCode)
            {

                string data = responseMessage.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(data);

            }
            return View(product);
        }

    }
}