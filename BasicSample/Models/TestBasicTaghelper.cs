using System.ComponentModel.DataAnnotations;

namespace BasicSample.Models
{
    public class TestBasicTaghelper
    {
        [Required]
        [Display(Name = "Car Name")]
        public string Car { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}