using System.ComponentModel.DataAnnotations;
namespace CourseSelection.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
