using DataAccess.Context;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.models;

namespace DataAccess.Services
{
    public class UpdateService
    {
        private readonly RunXContext _context;
        public UpdateService(RunXContext context)
        {
            this._context = context;
        }

        public bool UpdateWaterCups(int P_Or_M,int id)
        {
            try {
                _context.CupsOfWater.FirstOrDefault(e => e.Id == id).Done += P_Or_M;
                _context.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
        }

        public double UpdateEatenFood( int mealId,int kCalId)
        {
            try
            {
                var meal = _context.Meal.Include(e=>e.ItemsList).Where(e=>e.Id == mealId).FirstOrDefault();
                    
                var kCal = _context.KCal.FirstOrDefault(e => e.Id == kCalId);
                double caloriesOfMeal = getTotalCalories(meal.ItemsList);
                if (meal.eaten == false)
                    kCal.Done += caloriesOfMeal;
                else
                    kCal.Done -= caloriesOfMeal;

                meal.eaten = !meal.eaten;
                _context.SaveChanges();
                return caloriesOfMeal;
            }
            catch
            {
                return -1;
            }
        }

        public double getTotalCalories(List<FoodChoosen> list)
        {
            double total = 0;
            try {
                for (int i = 0; i < list.Count; i++)
                {
                    total += _context.FoodItem.FirstOrDefault(e => e.Id == list[i].foodId).KCal;
                }
                return total;
            } catch
            {
                return 0;
            }
        }

        public bool addMedicine(Medicine med)
        {
            try
            {
                _context.Medicine.Add(med);
                  _context.SaveChanges();
              
                return true;
            }
            catch
            {
                return false;
            } 
        }

        public bool removeMedicine(int id)
        {
            try
            {
                _context.Time.RemoveRange(_context.Time.Where(e => e.MedicineId == id));
                _context.SaveChanges();
                var itemToRemove = _context.Medicine.SingleOrDefault(e => e.Id == id);
                _context.Medicine.Remove(itemToRemove);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
