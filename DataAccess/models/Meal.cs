using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class Meal
    {
        public int Id { get; set; }
        
        [Required]
        public string mealName { get; set; }
        [Required]
        public DateTime Date { get; set; } 
        public List<FoodChoosen> ItemsList { get; set; }

        [Required]
        public bool eaten { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
