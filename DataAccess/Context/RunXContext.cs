using DataAccess.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{ 
    public class RunXContext : DbContext
    {
        public RunXContext(DbContextOptions options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<PushNotifications> PushNotifications { get; set; }
        public DbSet<CupsOfWater> CupsOfWater { get; set; }
        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<Height> Height { get; set; }
        public DbSet<KCal> KCal { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Sleep> Sleep { get; set; }
        public DbSet<Steps> Steps { get; set; }
        public DbSet<Time> Time { get; set; }
        public DbSet<Weight> Weight { get; set; }
        public DbSet<MealTime> MealTimes { get; set; }
        public DbSet<Protein> Protein { get; set; }
    }
}
