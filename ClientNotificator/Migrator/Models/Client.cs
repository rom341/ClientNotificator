using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrator.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public ClientContacts Contacts { get; set; }
        public ClientPersonalInfo PersonalInfo { get; set; }
        public string? Notes { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastEdit { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public ICollection<DateTime>? VisitHistory { get; set; }
        public ICollection<Service> ServiceList { get; set; }

        public Client()
        {
            Contacts = new ClientContacts();
            PersonalInfo = new ClientPersonalInfo();
            VisitHistory = new List<DateTime>();
            ServiceList = new List<Service>();
        }
    }
}
