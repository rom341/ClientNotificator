using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrator.Models
{
    public class Service
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Cost { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
