using LWP.ShoppersHubDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LWP.ShoppersHubDAL
{
    public class Repository
    {
        ShoppersHubDBContext context;
        public Repository()
        {
            context = new ShoppersHubDBContext();
        }
        //#region Code
        //#region GetAllCategories
        //public List<Categories> GetAllCategories()
        //{
        //    var catlist = (from category in context.Categories
        //                   orderby category.CategoryId
        //                   select category).ToList();
        //    return catlist;
        //}
        //#endregion

        //#region GetProductsOnCategoryId
        //public List<Products> GetProductsOnCategoryId(byte categoryId)
        //{
        //    List<Products> lstProducts = null;
        //    try
        //    {
        //        lstProducts = context.Products.Where(p => p.CategoryId == categoryId).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        lstProducts = null;
        //    }
        //    return lstProducts;
        //}
        //#endregion

        //#region FilterProducts
        //public Products FilterProducts(byte categoryId)
        //{
        //    Products product = null;
        //    try
        //    {
        //        product = context.Products.Where(p => p.CategoryId == categoryId).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        product = null;
        //    }
        //    return product;
        //}
        //#endregion

        //#region FilterProductsUsingLike
        //public List<Products> FilterProductsUsingLike(string pattern)
        //{
        //    List<Products> lstProduct = null;
        //    try
        //    {
        //        lstProduct = context.Products.Where(p => EF.Functions.Like(p.ProductName, pattern)).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        lstProduct = null;
        //    }
        //    return lstProduct;
        //}
        //#endregion

        //#region AddCategory
        //public bool AddCategory(string categoryName)
        //{
        //    bool status = false;
        //    Categories category = new Categories();
        //    category.CategoryName = categoryName;
        //    try
        //    {
        //        context.Categories.Add(category);
        //        context.SaveChanges();
        //        status = true;
        //    }
        //    catch (Exception)
        //    {
        //        status = false;
        //    }
        //    return status;
        //}
        //#endregion

        //#region AddMultipleProducts
        //public bool AddMultipleProducts(params Products[] products)
        //{
        //    bool status = false;
        //    try
        //    {
        //        context.Products.AddRange(products);
        //        context.SaveChanges();
        //        status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //    }
        //    return status;
        //}
        //#endregion

        //#region UpdateCategory
        //public bool UpdateCategory(byte id, string newName)
        //{
        //    bool status = false;
        //    Categories category = context.Categories.Find(id);
        //    try
        //    {
        //        if (category != null)
        //        {
        //            category.CategoryName = newName;
        //            context.SaveChanges();
        //            status = true;
        //        }
        //        else
        //        {
        //            status = false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        status = false;
        //    }
        //    return status;
        //}
        //#endregion

        //#region UpdateProduct
        //public int UpdateProduct(string id, decimal price)
        //{
        //    int status = -1;
        //    try
        //    {
        //        Products product = context.Products.Find(id);
        //        if(product != null)
        //        {
        //            product.Price = price;
        //            context.SaveChanges();
        //            status = 1;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        status = -99;
        //    }
        //    return status;
        //}
        //#endregion

        //#region UpdateMultipleProducts
        //public int UpdateMultipleProducts(byte categoryId, int quantityProcured)
        //{
        //    int status = -1;
        //    try
        //    {
        //        List<Products> productList = context.Products.Where(p => p.CategoryId == categoryId).ToList();
        //        foreach (var products in productList)
        //        {
        //            products.QuantityAvailable += quantityProcured;
        //        }
        //        if(productList.Count > 0)
        //        {
        //            context.UpdateRange(productList);
        //            context.SaveChanges();
        //            status = 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return 0;
        //}
        //#endregion

        //#region DeteleProduct
        //public bool DeleteProduct(string productId)
        //{
        //    Products product = null;
        //    bool status = false;
        //    try
        //    {
        //        product = context.Products.Find(productId);
        //        if (product != null)
        //        {
        //            context.Products.Remove(product);
        //            context.SaveChanges();
        //            status = true;
        //        }
        //        else
        //        {
        //            status = false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        status = false;
        //    }
        //    return status;
        //}
        //#endregion

        //#region DeleteMultiProduct
        //public bool DeleteMultiProduct(string subString)
        //{
        //    bool status = false;
        //    try
        //    {
        //        var deleteProducts = context.Products.Where(p => p.ProductName.Contains(subString));
        //        context.Products.RemoveRange(deleteProducts);
        //        context.SaveChanges();
        //        status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //    }
        //    return status;
        //}
        //#endregion
        //#endregion

        #region For Product Controller

        #region-To get all product details
        public List<Products> GetAllProducts()
        {
            List<Products> lstProducts = null;
            try
            {
                lstProducts = (from p in context.Products
                               orderby p.ProductId
                               select p).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                lstProducts = null;
            }
            return lstProducts;
        }
        #endregion

        #region-To get a product detail by using ProductId
        public Products GetProductById(string productId)
        {
            Products product = new Products();
            try
            {
                product = (from p in context.Products
                           where p.ProductId.Equals(productId)
                           select p).FirstOrDefault();
            }
            catch (Exception)
            {
                product = null;
            }
            return product;
        }
        #endregion

        #region- To generate new product id
        public string GenerateNewProductId()
        {
            string productId;
            try
            {
                productId = (from p in context.Products
                             select ShoppersHubDBContext.ufn_GenerateNewProductId()).FirstOrDefault();
            }
            catch (Exception)
            {
                productId = null;
            }
            return productId;
        }
        #endregion

        #region- To add a new product using Params
        public bool AddProduct(string productName, byte categoryId, decimal price, int quantityAvailable, out string productId)
        {
            bool status = false;
            productId = null;
            try
            {
                Products prodObj = new Products();
                prodObj.ProductId = GenerateNewProductId();
                productId = prodObj.ProductId;
                prodObj.ProductName = productName;
                prodObj.CategoryId = categoryId;
                prodObj.Price = price;
                prodObj.QuantityAvailable = quantityAvailable;
                context.Products.Add(prodObj);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                productId = null;
                status = false;

            }
            return status;
        }
        #endregion

        #region- To add a new product
        public bool AddProduct(Products product)
        {
            bool status = false;
            try
            {
                product.ProductId = GenerateNewProductId();
                context.Products.Add(product);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {

                status = false;

            }
            return status;
        }

        #endregion

        #region- To update the existing product details using Entity Models
        public bool UpdateProduct(Products products)
        {
            bool status = false;
            try
            {
                var product = (from prdct in context.Products
                               where prdct.ProductId == products.ProductId
                               select prdct).FirstOrDefault<Products>();
                if (product != null)
                {
                    product.ProductId = products.ProductId;
                    product.ProductName = products.ProductName;
                    product.Price = products.Price;
                    product.QuantityAvailable = products.QuantityAvailable;
                    product.CategoryId = products.CategoryId;
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region-To delete a existing product
        public bool DeleteProduct(string prodId)
        {
            bool status = false;
            try
            {
                var product = (from prdct in context.Products
                               where prdct.ProductId == prodId
                               select prdct).FirstOrDefault<Products>();
                context.Products.Remove(product);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #endregion

        #region For Category Controller

        #region-To get all category details
        public List<Categories> GetAllCategories()
        {
            List<Categories> lstCategories = null;
            try
            {
                lstCategories = (from c in context.Categories
                                 orderby c.CategoryId ascending
                                 select c).ToList<Categories>();
            }
            catch (Exception)
            {
                lstCategories = null;
            }
            return lstCategories;
        }
        #endregion

        #region get a category detail by using CategoryId
        public Categories GetCategoryById(byte categoryId)
        {
            Categories categories = new Categories();
            try
            {

                categories = (from c in context.Categories
                              where c.CategoryId.Equals(categoryId)
                              select c).FirstOrDefault();
            }
            catch (Exception)
            {
                categories = null;
            }
            return categories;
        }
        #endregion

        #region-To generate new category id
        public byte GenerateNewCategoryId()
        {
            byte categoryId;
            try
            {
                var newCategoryId = (from p in context.Categories select ShoppersHubDBContext.ufn_GenerateNewCategoryId()).FirstOrDefault();
                categoryId = Convert.ToByte(newCategoryId);
            }
            catch (Exception)
            {
                categoryId = 0;
            }
            return categoryId;

        }
        #endregion

        #region-To add a new category
        public bool AddCategory(Categories category)
        {
            bool status = false;
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region-To add a new category using Params
        public bool AddCategory(string categoryName)
        {
            bool status = false;
            try
            {
                Categories catObj = new Categories();
                catObj.CategoryName = categoryName;
                context.Categories.Add(catObj);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region-To update the existing category details 
        public bool UpdateCategory(Categories category)
        {
            bool status = false;
            try
            {
                var catObj = (from ctgry in context.Categories
                              where ctgry.CategoryId == category.CategoryId
                              select ctgry).FirstOrDefault<Categories>();

                if (category != null)
                {
                    catObj.CategoryName = category.CategoryName;
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region-To delete a existing category
        public bool DeleteCategory(byte categID)
        {
            bool status = false;
            try
            {
                var category = (from ctgry in context.Categories
                                where ctgry.CategoryId == categID
                                select ctgry).FirstOrDefault<Categories>();
                context.Categories.Remove(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region-To get all categoriesPB
        public List<Categories> GetAllCategoriesPB()
        {
            List<Categories> lstcat = null;
            try
            {
                lstcat = (from c in context.Categories
                          orderby c.CategoryId
                          select c).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                lstcat = null;
            }
            return lstcat;
        }
        #endregion

        #endregion

        #region For UserController

        #region Check EmailId
        public byte CheckMail(string mail)
        {
            byte Id;
            try
            {
                var id = (from p in context.Users select ShoppersHubDBContext.ufn_CheckEmailId()).FirstOrDefault();
                Id = Convert.ToByte(id);
            }
            catch (Exception)
            {
                Id = 2;
            }
            return Id;

        }
        #endregion

        #region GetUsers
        public List<Users> GetUsers()
        {
            List<Users> users = null;
            try
            {
                users = (from u in context.Users
                         where u.RoleId == 2
                         select u).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                users = null;
            }
            return users;
        }
        #endregion

        #region GetAdmin
        public List<Users> GetAdmin()
        {
            List<Users> users = null;
            try
            {
                users = (from u in context.Users
                         where u.RoleId == 1
                         select u).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                users = null;
            }
            return users;
        }
        #endregion

        #region Register Users
        public int RegisterUser(Users users)
        {
            int status = 0;
            string mail = users.EmailId;
            try
            {
                var m = (from u in context.Users where u.EmailId == mail select u).FirstOrDefault();
                if(m == null)
                {
                    context.Users.Add(users);
                    context.SaveChanges();
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                
            }
            catch (Exception)
            {

                status = -1;

            }
            return status;
        }
        #endregion

        #region Update Users
        public bool UpdateUser(Users users)
        {
            bool status = false;
            try
            {
                var user = (from u in context.Users
                               where u.EmailId == users.EmailId
                               select u).FirstOrDefault<Users>();
                if (user != null)
                {
                    user.Address = users.Address;
                    user.DateOfBirth = users.DateOfBirth;
                    user.Gender = users.Gender;
                    user.RoleId = users.RoleId;
                    user.UserPassword = users.UserPassword;
                    context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #endregion
    }
}
