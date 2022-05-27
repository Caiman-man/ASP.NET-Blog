using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a text")]
        public string Body { get; set; }

        public string Image { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
