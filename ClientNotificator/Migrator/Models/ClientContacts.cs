using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrator.Models
{
    public class ClientContacts
    {
        [Key]
        public int ID { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelegramName { get; set; }
        public int? TelegramID { get; set; }
        public Client Client { get; set; }
    }
}
