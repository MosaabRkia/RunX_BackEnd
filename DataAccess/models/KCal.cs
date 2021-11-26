using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class KCal
    {
        public int Id { get; set; }

        [Required]
        public double Goal { get; set; }

        [Required]
        public double Done { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
