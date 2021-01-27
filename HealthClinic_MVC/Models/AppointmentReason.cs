using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic_MVC.Models
{
    //stores Patients reason for appointment
    public class AppointmentReason
    {
        //Primary Key
        public int Id { get; set; }

        //Holds the reason for appointment
        [Required]
        public string Option { get; set; }

        //Holds the Price of the appointment
        [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

    }
}
