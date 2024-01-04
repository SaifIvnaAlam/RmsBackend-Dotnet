﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TokenKey { get; set; }

        [Required]
       
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        [Required]
        public string UserEmail { get; set; }



    }
} 
