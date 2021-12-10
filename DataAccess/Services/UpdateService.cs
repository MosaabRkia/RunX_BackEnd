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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
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

        public bool weightUpdate(Weight weight)
        {
            try
            {
                _context.Weight.Add(weight);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }


        public bool cupsOfWaterUpdate(CupsOfWater cupsObj)
        {
            try
            {
                _context.CupsOfWater.Add(cupsObj);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool kCalUpdate(KCal kcalObj)
        {
            try
            {
                _context.KCal.Add(kcalObj);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool stepsUpdate(Steps stepsObj)
        {
            try
            {
                _context.Steps.Add(stepsObj);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool sleepsUpdate(Sleep sleepObj)
        {
            try
            {
                _context.Sleep.Add(sleepObj);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }


        public bool mealsUpdate(Meal mealObj)
        {
            try
            {
                _context.Meal.Add(mealObj);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<FoodChoosen> ChoosenFoodGetter(int id)
        {
            try
            {
                return _context.User.Where(e => e.Id == id).Select(p => p.ChoosenFood).FirstOrDefault();     
            }
            catch
            {
                return null;
            }
        }
        public bool updateSteps(int steps, int stepsId)
        {

            try
            {
                var stepsToUpdate = _context.Steps.SingleOrDefault(e => e.Id == stepsId);
                stepsToUpdate.Done = steps;
                return _context.SaveChanges() > 0;
            }
            catch (System.Exception)
            {

                return false;
            }



        }

        public bool updateSleep(double sleepTime, int sleepId)
        {
            try
            {
                var sleepToUpdate = _context.Sleep.SingleOrDefault(e => e.Id == sleepId);
                sleepToUpdate.Done += sleepTime;
                return _context.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                return false;
            }



        }
    }
}
