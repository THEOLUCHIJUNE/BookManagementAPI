using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementAPI.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        
        
        
        
        
        //Navigagtion Properties to define the relationship between the author model and the book model
        public List<Book> Books { get; set; } 
    }
    
    
}