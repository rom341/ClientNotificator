using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public ClientContacts Contacts { get; set; }
        public ClientPersonalInfo PersonalInfo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public ICollection<Training> Trainings { get; set; }
    }
}
