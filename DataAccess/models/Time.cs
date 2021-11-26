using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class Time
    {
        public int Id { get; set; }

        [Required]
        public DateTime time { get; set; }

        public int MedicineId { get; set; }
    }
}
