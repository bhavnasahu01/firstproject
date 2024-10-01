using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; // we need to add this extension of key


namespace Bulky.Models
{
	public class Category
	{
        [Key] //it will definied the primary key 
	    public int Id { get; set; }

        [Required] //name is required Data Annotation 
        [MaxLength(30)] // validation
        [DisplayName("Category Name")] // It will display the name acc to the it will help full for client side Ui or validation.
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "Display orde must be 1 - 100")] // Custom error msg and validation 
       
        public int DisplayOrder { get; set;}
     

    }
}

