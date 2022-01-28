using System;
using System.Collections.Generic;
using System.Linq;
using LWP.ShoppersHubDAL;
using LWP.ShoppersHubDAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LWP.ShoppersHubUI
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Repository rep = new Repository();
            var a = rep.GetAllCategories();
            foreach (var item in a)
            {
                Console.WriteLine(item.CategoryName);
            }
        }
    }
}
