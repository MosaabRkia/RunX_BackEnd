﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class Sleep
    {
        public int Id { get; set; }

        [Required]
        public int Goal { get; set; }

        [Required]
        public int Done { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}