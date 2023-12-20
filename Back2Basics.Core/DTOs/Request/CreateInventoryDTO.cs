using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back2Basics.Core.DTOs.Request
{
    public class CreateInventoryDTO
    {
        [Required(ErrorMessage = "You need to provide the name of the drug")]
        [MinLength(3)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
