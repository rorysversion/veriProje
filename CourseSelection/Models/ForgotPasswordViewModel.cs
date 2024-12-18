using System.ComponentModel.DataAnnotations;

namespace CourseSelection.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

