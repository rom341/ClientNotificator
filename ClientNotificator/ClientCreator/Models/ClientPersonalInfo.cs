using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.Models
{
    public class ClientPersonalInfo
    {
        [Key]
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Client Client { get; set; }
    }
}
