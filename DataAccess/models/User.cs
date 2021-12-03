using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        public List<Weight> Weights { get; set; }
        public List<Height> Heights { get; set; }
        public string Goal { get; set; }
        
        [Required]
        public double GoalWeight { get; set; }
        public List<FoodChoosen> ChoosenFood { get; set; }
        public List<Medicine> Meds { get; set; }
        public List<Steps> DailySteps { get; set; }
        public List<CupsOfWater> DailyWaterCups { get; set; }
        public List<Sleep> Sleeps { get; set; }       
        public List<Protein> DailyProtein { get; set; }
        public List<KCal> KCalDaily { get; set; }
        public List<Meal> Meals { get; set; }
        public PushNotifications notifications { get; set; }

    }
}
