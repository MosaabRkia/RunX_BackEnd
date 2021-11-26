using DataAccess.Context;
using DataAccess.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Web.Http;

namespace DataAccess.Services
{
    public class ItemsService
    {
        private readonly RunXContext _context;
        public ItemsService(RunXContext context)
        {
            this._context = context;
        }

     
        public List<FoodItem> Get()
        {
            var allList = _context.FoodItem
                .Include(e => e.MealTimes)     
            .ToList();

            return allList;            
        }

       
        public FoodItem Get(int id)
        {            
            return _context.FoodItem
                .Include(e=>e.MealTimes)
                        .SingleOrDefault(item => item.Id == id);
            
        }

    }
}
