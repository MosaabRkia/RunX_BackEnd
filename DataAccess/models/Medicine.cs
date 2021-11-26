using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Amount { get; set; }
        public List<Time> Times { get; set; }
        
        [Required]
        public int UserId { get; set; }
    }
}
