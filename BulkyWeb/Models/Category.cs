using System;
using System.ComponentModel.DataAnnotations; // we need to add this extension of key


namespace BulkyWeb.Models
{
	public class Category
	{
        //[Key]   it will definied the primary key 
	    public int Id { get; set; }

        //[Required] name is required 
        public string Name { get; set; }
        public int DisplayOrder { get; set;
        }
     

    }
}

