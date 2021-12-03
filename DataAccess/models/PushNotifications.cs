using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.models
{
    public class PushNotifications
    {
        public int Id { get; set; }

        public string Token { get; set; }

        [Required]
        public bool Accepted { get; set; }
    }
}
