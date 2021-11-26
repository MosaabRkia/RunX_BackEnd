using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class FoodItem
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string Kind { get; set; }

        [Required]
        public List<MealTime> MealTimes { get; set; }

        [Required]
        public double KCal { get; set; }

        [Required]
        public double Gram { get; set; }

        [Required]
        public double Protein { get; set; }

        [Required]
        public double Fats { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public int photoId { get; set; }


    }
}
