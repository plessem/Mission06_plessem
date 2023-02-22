using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_plessem.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        //Build foreign key relationship 
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public short Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }


    }
}
