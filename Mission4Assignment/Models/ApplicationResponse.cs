using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Models
{   
    //Building out the model to collect information from the form
    //Making certain fields required and setting a max length to the Notes field
    public class MovieInfo
    {
        [Key]
        [Required]
        public int MovieID { get; set; }


        //Build Foreign Key Relationship
        [Required(ErrorMessage ="You must select a category")]
        public int CategoryId { get; set; }
        public MovieCategory Category { get; set; }
        
        [Required(ErrorMessage ="Please enter the title of the movie")]
        public string Title { get; set; }
        
        [Required(ErrorMessage ="Please enter the year of the film's release")]
        public int Year { get; set; }
        
        [Required(ErrorMessage ="Please enter the director of the film")]
        public string Director { get; set; }
        
        [Required(ErrorMessage ="You must select the film's rating")]
        public string Rating { get; set; }
        public bool IsEdited { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
        
    }
}
