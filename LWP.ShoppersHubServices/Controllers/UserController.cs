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
    [Route("api/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        Repository repository;
        public UserController()
        {
            repository = new Repository();
        }

        [HttpGet]
        public JsonResult Users()
        {
            List<Users> users = new List<Users>();
            try
            {
                users = repository.GetUsers();
            }
            catch (Exception)
            {
                users = null;
            }
            return Json(users);
        }

        [HttpGet]
        public JsonResult Admin()
        {
            List<Users> users = new List<Users>();
            try
            {
                users = repository.GetAdmin();
            }
            catch (Exception)
            {
                users = null;
            }
            return Json(users);
        }

        [HttpPost]
        public JsonResult Register(Users users)
        {
            int status = 0;
            string message = "";
            try
            {
                status = repository.RegisterUser(users);
                if (status == 1)
                {
                    message = "User added successfully!!!";
                }
                else if(status == 0)
                {
                    message = "Email ID is already present!";
                }else if(status == -1)
                {
                    message = "Error in DAL";
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return Json(message);
        }

        [HttpPut]
        public JsonResult Update(Users users)
        {
            string msg = "";
            bool status = false;
            try
            {
                status = repository.UpdateUser(users);
                if (status)
                {
                    msg = "Successfully updated!!!";
                }
                else
                {
                    msg = "Unsuccessful Operation!";
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return Json(msg);
        }
    }
}
