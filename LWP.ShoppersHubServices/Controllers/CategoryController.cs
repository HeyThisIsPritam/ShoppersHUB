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
    public class CategoryController : Controller
    {
        Repository repository;
        public CategoryController()
        {
            repository = new Repository();
        }

        [HttpGet]
        #region GetAllCategory
        public JsonResult GetAllCategory()
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                categories = repository.GetAllCategories();
            }
            catch (Exception)
            {
                categories = null;
            }
            return Json(categories);
        }

        #endregion

        [HttpPost]
        #region AddCategory
        public JsonResult AddCategory(Categories cat)
        {
            bool status = false;
            string message;

            try
            {
                status = repository.AddCategory(cat);
                if (status)
                {
                    message = "Successful addition operation, CategoryId = " + cat.CategoryId;
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
        #region Update Category
        public bool UpdateCategories(Models.Categories categories)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Categories catObj = new Categories();
                    catObj.CategoryId = categories.CategoryId;
                    catObj.CategoryName = categories.CategoryName;
                    status = repository.UpdateCategory(catObj);
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
        public JsonResult DeleteCategory(byte categtoryId)
        {
            bool status = false;
            try
            {
                status = repository.DeleteCategory(categtoryId);
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
