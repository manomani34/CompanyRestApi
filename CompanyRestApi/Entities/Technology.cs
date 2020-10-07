using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRestApi.Entities
{
    public class Technology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public DateTime Appeared { get; set; }


        //Navigation Property
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
