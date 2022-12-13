<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> 373bc4bc4ebf8d0f765dfd09f44cf3368ff3f39a

namespace BookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DiaplayOrder { get; set; }
        public DateTime GetDateTime { get; set; }= DateTime.Now;
    }
}
