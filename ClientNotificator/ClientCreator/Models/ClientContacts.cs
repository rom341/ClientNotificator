using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCreator.Models
{
    public class ClientContacts
    {
        [Key]
        public int ID { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string TelegramName { get; set; }
        public int? TelegramID { get; set; }
        public Client Client { get; set; }
    }
}
