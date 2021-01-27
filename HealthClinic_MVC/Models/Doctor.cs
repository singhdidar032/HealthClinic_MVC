using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic_MVC.Models
{
    //stores the doctors details
    public class Doctor
    {
        //primary key
        public int Id { get; set; }

        //holds the doctors name
        [Required]
        public string Name { get; set; }

        //bool to show if doctor is full time or false
        [Display(Name = "Is FullTime")]
        public bool IsFullTime { get; set; }
    }
}
