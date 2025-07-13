﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";
        
        public string Email { get; set; } = "";
        
        public string Password { get; set; } = "";
            
        public string Phone { get; set; } = "";


    }
}
