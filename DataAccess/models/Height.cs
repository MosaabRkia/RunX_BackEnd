using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class Height
    {
        public int Id { get; set; }

        [Required]
        public double CurrentHeight { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
