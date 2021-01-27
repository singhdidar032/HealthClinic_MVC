using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthClinic_MVC.Models;

namespace HealthClinic_MVC.Data
{
    public class HealthClinic_DBContext : DbContext
    {
        public HealthClinic_DBContext (DbContextOptions<HealthClinic_DBContext> options)
            : base(options)
        {
        }

        public DbSet<HealthClinic_MVC.Models.Appointment> Appointment { get; set; }

        public DbSet<HealthClinic_MVC.Models.AppointmentReason> AppointmentReason { get; set; }

        public DbSet<HealthClinic_MVC.Models.Doctor> Doctor { get; set; }

        public DbSet<HealthClinic_MVC.Models.Patient> Patient { get; set; }
    }
}
