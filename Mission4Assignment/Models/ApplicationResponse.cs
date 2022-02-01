using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Models
{   
    //Building out the model to collect information from the form
    //Making certain fields required and setting a max length to the Notes field
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }


        //Build Foreign Key Relationship
        [Required]
        public int CategoryId { get; set; }
        public MovieCategory Category { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public int Year { get; set; }
        
        [Required]
        public string Director { get; set; }
        
        [Required]
        public string Rating { get; set; }
        public bool IsEdited { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
        
    }
}
