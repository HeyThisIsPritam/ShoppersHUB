using LWP.ShoppersHubDAL;
using LWP.ShoppersHubDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace LWP.ShoppersHubServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        Repository repository;
        public ProductController()
        {
            repository = new Repository();
        }

        [HttpGet]
        #region GetAllProduts
        public JsonResult GetAllProducts()
        {
            List<Products> products = new List<Products>();
            try
            {
                products = repository.GetAllProducts();
            }
            catch (Exception)
            {
                products = null;
            }
            return Json(products);
        }
        #endregion

        #region GetProductById
        public JsonResult GetProductById(string productId)
        {
            Products product = null;
            try
            {
                product = repository.GetProductById(productId);
            }
            catch (Exception)
            {
                product = null;
            }
            return Json(product);
        }

        #endregion

        [HttpPost]
        #region Using Params
        
        public JsonResult AddProductUsingParams(string productName, byte categoryId, decimal price, int quantityAvailable)
        {
            bool status = false;
            string productId = null;
            string message;
            try
            {
                status = repository.AddProduct(productName, categoryId, price, quantityAvailable, out productId);
                if (status)
                {
                    message = "Successful addition operation, ProductId = " + productId;
                }
                else
                {
                    message = "Unsuccessful addition operation!";
                }
            }
            catch (Exception)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);
        }
        #endregion

        [HttpPost]
        #region AddProductByModels

        public JsonResult AddProductByModels(Products product)
        {
            bool status = false;
            string message;

            try
            {
                status = repository.AddProduct(product);
                if (status)
                {
                    message = "Successful addition operation, ProductId = " + product.ProductId;
                }
                else
                {
                    message = "Unsuccessful addition operation!";
                }
            }
            catch (Exception)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);
        }

        #endregion

        [HttpPut]
        #region Put Operations
        public bool UpdateProductByAPIModels(Models.Products product)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Products prodObj = new Products();
                    prodObj.ProductId = product.ProductId;
                    prodObj.ProductName = product.ProductName;
                    prodObj.CategoryId = product.CategoryId;
                    prodObj.Price = product.Price;
                    prodObj.QuantityAvailable = product.QuantityAvailable;
                    status = repository.UpdateProduct(prodObj);
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        #endregion

        [HttpDelete]
        #region Delete Product method 
        public JsonResult DeleteProduct(string productId)
        {
            bool status = false;
            try
            {
                status = repository.DeleteProduct(productId);
            }
            catch (Exception)
            {
                status = false;
            }
            return Json(status);
        }

        #endregion
        
    }


}
