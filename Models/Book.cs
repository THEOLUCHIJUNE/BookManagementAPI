using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please insert the book Title...")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please insert the book Description...")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please insert the book Genre...")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Please insert the Book Author...")]
        public string Author { get; set; }
        public DateTime DateAdded { get; set; }

        //Navigation Properties
        [ForeignKey("PublisherId")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}