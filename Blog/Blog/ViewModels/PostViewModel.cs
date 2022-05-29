using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class PostViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a text")]
        public string Body { get; set; }

        public IFormFile Image { get; set; } = null;

        public string CurrentImage { get; set; } = "";
    }
}
