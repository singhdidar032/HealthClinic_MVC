using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClinic_MVC.Models
{
    //shows appointments booked
    public class Appointment
    {
        //Primary Key
        public int Id { get; set; }

        //Links to Patient Table
        public int PatientId { get; set; }

        //Links to doctor Table
        public int DoctorId { get; set; }

        //Links to Appointment reason Table
        public int ReasonForAppointmentId { get; set; }
      
        //Holds the Date of Appointment
        [Display(Name = "Appointment Date")]
        [ DataType(DataType.Date)]
        public DateTime AppDate { get; set; }

        //Patient Fk
        public Patient Patient { get; set; }
        //Doctor Fk
        public Doctor Doctor { get; set; }
        //Appointment reason FK
        [Display(Name = "Appointment Reason")]
        public AppointmentReason ReasonForAppointment { get; set; }
    }
}
