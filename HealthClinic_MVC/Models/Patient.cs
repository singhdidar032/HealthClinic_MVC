using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic_MVC.Models
{
    //stores the patients details
    public class Patient
    {
        //primary key
        public int Id { get; set; }

        //holds patients name
        [Required]
        public string Name { get; set; }

        //holds patients mobile number
        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
    }
}
